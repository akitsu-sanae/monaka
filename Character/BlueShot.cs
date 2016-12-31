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
    class BlueShot : Shot
    {
        public BlueShot(asd.Layer2D layer, asd.Vector2DF pos)
        {
            this.layer = layer;
            var circle = new asd.CircleShape();
            circle.NumberOfCorners = 36;
            Shape = circle;
            Position = pos;
        }

        protected override void OnUpdate()
        {
            diameter *= 1.02f;
            (Shape as asd.CircleShape).InnerDiameter = diameter;

            counter++;
            var d = (float)counter / 90.0f;
            var angle = 2.0f * Math.PI * d;
            Color = new asd.Color((byte)(Math.Cos(angle) * 100.0 + 100.0), (byte)(Math.Cos(angle) * 100.0 + 100.0), 255);

            if (counter > 90)
                Dispose();
        }

        public override bool isHit(Enemy.Enemy e)
        {
            if ((Position - e.Position).Length > diameter)
                return false;
            layer.AddObject(new BlueShot(layer, e.Position));
            return true;
        }

        asd.Layer2D layer;
        float diameter = 16.0f;
        int counter = 0;
    }
}
