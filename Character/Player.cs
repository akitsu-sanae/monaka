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

namespace monaka.Character
{
    class Player : asd.GeometryObject2D
    {
        public Player()
        {
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(-size/2.0f, size);
            rect.CenterPosition = size / 2;
            Shape = rect;
            Color = new asd.Color(255, 255, 255);
            Position = new asd.Vector2DF(320, 240);
        }

        protected override void OnUpdate()
        {
            var diff = new asd.Vector2DF();
            if (Input.isPushed(Input.Button.Left))
                diff.X -= 4.0f;
            if (Input.isPushed(Input.Button.Right))
                diff.X += 4.0f;
            if (Input.isPushed(Input.Button.Up))
                diff.Y -= 4.0f;
            if (Input.isPushed(Input.Button.Down))
                diff.Y += 4.0f;
            var newPos = Position + diff;
            if (newPos.X > 0 && newPos.X < 640 && newPos.Y > 0 && newPos.Y < 480)
                Position = newPos;

            Scale = Scale * 1.01f;
            if (Scale.X > 1.5f)
                Scale = new asd.Vector2DF(1.0f, 1.0f);

            var c = (byte)(2.0f * 255.0f * (Scale.X - 1.0f));
            Color = new asd.Color(c, 255, c);
        }

        asd.Vector2DF size = new asd.Vector2DF(32.0f, 32.0f);
    }
}
