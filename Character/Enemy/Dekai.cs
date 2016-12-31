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

namespace monaka.Character.Enemy
{
    class Dekai : Enemy
    {
        public Dekai(asd.Vector2DF pos, Func<Enemy, bool> addEnemy)
        {
            var circle = new asd.CircleShape();
            circle.NumberOfCorners = 36;
            circle.InnerDiameter = 64.0f;
            Shape = circle;
            Position = pos;
            this.addEnemy = addEnemy;
        }

        protected override void OnUpdate()
        {
            counter = (counter + 1) % 90;
            var d = (float)counter / 90.0f;
            var theta = 6.0f * Math.PI * d;
            Color = new asd.Color((byte)(Math.Cos(theta) * 100.0 + 100.0), (byte)(Math.Sin(theta) * 100.0 + 100.0), 255);

            Scale = Scale * 1.01f;
            if (Scale.X > 1.5)
                Scale = new asd.Vector2DF(1.0f, 1.0f);

            if (counter % 30 == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    var angle = 2.0f * Math.PI * (float)i / 6.0f;
                    var speed = new asd.Vector2DF((float)Math.Cos(angle), (float)Math.Sin(angle)) * 8.0f;
                    addEnemy(new Zako(Position + speed, speed));
                }
            }

            speed *= 0.9f;
            if (speed < 6.0f)
                speed = 6.0f;
            Position = Position + new asd.Vector2DF(0.0f, speed);
            if (Position.Y > 480 + 32 || Position.Y < -32 || Position.X > 640 + 32 || Position.X < -32)
                Dispose();
        }

        Func<Enemy, bool> addEnemy;
        float speed = 16.0f;
        int counter = 0;
    }
}
