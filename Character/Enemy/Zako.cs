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
    class Zako : Enemy
    {
        public Zako(asd.Vector2DF pos)
        {
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(-size / 2.0f, size);
            rect.CenterPosition = size / 2;
            Shape = rect;
            Color = new asd.Color(255, 100, 100);

            Position = pos;
        }

        public Zako(asd.Vector2DF pos, asd.Vector2DF speed) :
            this(pos)
        {
            this.speed = speed;
        }

        protected override void OnUpdate()
        {
            Position = Position + speed;

            Scale = Scale * 1.01f;
            if (Scale.X > 1.5f)
                Scale = new asd.Vector2DF(1.0f, 1.0f);

            var c = (byte)(2.0f * 255.0f * (Scale.X - 1.0f));
            Color = new asd.Color(255, c, 255);

            if (Position.Y > 480+32 || Position.Y < -32 || Position.X > 640+32 || Position.X < -32)
                Dispose();
        }

        asd.Vector2DF speed = new asd.Vector2DF(0.0f, 8.0f);
        asd.Vector2DF size = new asd.Vector2DF(32.0f, 32.0f);
    }
}
