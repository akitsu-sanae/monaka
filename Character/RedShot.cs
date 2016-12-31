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
    class RedShot : Shot
    {
        public RedShot(asd.Vector2DF pos)
        {
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(-size / 2.0f, size);
            rect.CenterPosition = size / 2;
            Shape = rect;
            Color = new asd.Color(255, 100, 100);

            Position = pos;
        }

        protected override void OnUpdate()
        {
            Position = Position + new asd.Vector2DF(0.0f, -8.0f);

            counter = (counter + 1) % 30;
            var d = (float)counter / 30.0f;
            var angle = 2.0f * Math.PI * d;
            Color = new asd.Color(255, (byte)(Math.Cos(angle)*100.0 + 100.0), (byte)(Math.Cos(angle)*100.0 + 100.0));

            if (Position.Y < 0)
                Dispose();
        }

        asd.Vector2DF size = new asd.Vector2DF(4.0f, 32.0f);
        int counter = 0;
    }
}
