/*============================================================================
  Copyright (C) 2016 akitsu sanae
  https://github.com/akitsu-sanae/monaka
  Distributed under the Boost Software License, Version 1.0. (See accompanying
  file LICENSE or copy at http://www.boost.org/LICENSE_1_0.txt)
============================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monaka.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            gameLayer.AddObject(player);

            AddLayer(gameLayer);
            AddLayer(statusLayer);
        }

        protected override void OnUpdated()
        {
            level *= 0.999;

            if (level < 1.5)
                level = 1.5;

            if (statusLayer.Hp < 0)
            {
                asd.Engine.ChangeScene(new Scene.Result(statusLayer));
                return;
            }

            enemies.RemoveAll(e => !e.IsAlive);
            shots.RemoveAll(s => !s.IsAlive);

            if (Resource.Rand.Next((int)level) == 0)
            {
                var enemy = new Character.Enemy.Zako(new asd.Vector2DF((float)Resource.Rand.NextDouble()*640.0f, 0.0f));
                gameLayer.AddObject(enemy);
                enemies.Add(enemy);
            }
            if (Resource.Rand.Next((int)level * 100) == 0)
            {
                var enemy = new Character.Enemy.Dekai(new asd.Vector2DF((float)Resource.Rand.NextDouble() * 640.0f, 0.0f), e =>
                {
                    gameLayer.AddObject(e);
                    enemies.Add(e);
                    return true;
                });
                gameLayer.AddObject(enemy);
                enemies.Add(enemy);
            }
            Hit();

            if (Input.isPushed(Input.Button.Button3) && statusLayer.Green > 100)
            {
                var shot = new Character.GreenShot(player);
                shots.Add(shot);
                statusLayer.Green -= 100;
                gameLayer.AddObject(shot);
            }
            if (Input.isPushed(Input.Button.Button2) && statusLayer.Blue > 30)
            {
                var shot = new Character.BlueShot(gameLayer, player.Position);
                shots.Add(shot);
                statusLayer.Blue -= 30;
                gameLayer.AddObject(shot);
            }
            if (Input.isPushed(Input.Button.Button1) && statusLayer.Red > 14)
            {
                statusLayer.Red -= 14;
                for (int i = 0; i < 5; i++)
                {
                    var shot = new Character.RedShot(player.Position + new asd.Vector2DF(-24.0f, 0.0f) + new asd.Vector2DF(12.0f, 0.0f) * i);
                    shots.Add(shot);
                    gameLayer.AddObject(shot);
                }
            }

        }

        private void Hit()
        {
            foreach (var shot in shots)
            {
                enemies.RemoveAll(e =>
                {
                    if (shot.isHit(e))
                    {
                        statusLayer.Score += 10;
                        e.Dispose();
                        return true;
                    }
                    return false;
                });
            }

            bool isPlayerHitWithEnemies = false;
            enemies.RemoveAll(e =>
            {
                if ((player.Position - e.Position).Length < 16.0f)
                {
                    isPlayerHitWithEnemies = true;
                    e.Dispose();
                    return true;
                }
                return false;
            });
            if (isPlayerHitWithEnemies)
            {
                statusLayer.Hp--;
            }
        }

        asd.Layer2D gameLayer = new asd.Layer2D();
        Status statusLayer = new Status();
        Character.Player player = new Character.Player();

        List<Character.Enemy.Enemy> enemies = new List<Character.Enemy.Enemy>();
        List<Character.Shot> shots = new List<Character.Shot>();
        double level = 100.0;
    }
}
