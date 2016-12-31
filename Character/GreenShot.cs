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
using monaka.Character.Enemy;

namespace monaka.Character
{
    class GreenShot : Shot
    {
        public GreenShot(Player player)
        {
            Shape = new asd.RectangleShape();
            this.player = player;
        }

        protected override void OnUpdate()
        {
            var rect = new asd.RectF(player.Position - new asd.Vector2DF(width/2.0f, 0.0f), new asd.Vector2DF(width, -480.0f));
            width += 0.5f;
            width /= 1.2f;
            (Shape as asd.RectangleShape).DrawingArea = rect;

            counter++;
            var d = (float)counter / 30.0f;
            var angle = 2.0f * Math.PI * d;
            Color = new asd.Color((byte)(Math.Cos(angle) * 100.0 + 100.0), 255, (byte)(Math.Cos(angle) * 100.0 + 100.0));

            if (counter > 30)
                Dispose();
        }

        public override bool isHit(Enemy.Enemy e)
        {
            return Math.Abs(player.Position.X - e.Position.X) < width;
        }

        Player player;
        float width = 160.0f;
        int counter = 0;
    }
}
