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

namespace monaka
{
    class Status : asd.Layer2D
    {
        public Status()
        {
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(0.0f, 0.0f, 1.0f, 1.0f);
            greenCharge.Shape = rect;
            blueCharge.Shape = rect;
            redCharge.Shape = rect;

            greenCharge.Color = new asd.Color(0, 255, 0);
            greenCharge.Position = new asd.Vector2DF(32.0f, 32.0f);
            greenCharge.Scale = new asd.Vector2DF(Green, 32.0f);

            blueCharge.Color = new asd.Color(0, 0, 255);
            blueCharge.Position = new asd.Vector2DF(32.0f, 64.0f);
            blueCharge.Scale = new asd.Vector2DF(Blue, 32.0f);

            redCharge.Color = new asd.Color(255, 0, 0);
            redCharge.Position = new asd.Vector2DF(32.0f, 96.0f);
            redCharge.Scale = new asd.Vector2DF(Red, 32.0f);

            AddObject(greenCharge);
            AddObject(blueCharge);
            AddObject(redCharge);

            hpLabel.Font = Resource.PixelMPlus;
            hpLabel.Text = String.Format("HP: {0}", Hp);
            hpLabel.Position = new asd.Vector2DF(32.0f, 0.0f);
            AddObject(hpLabel);

            scoreLabel.Font = Resource.PixelMPlus;
            scoreLabel.Text = String.Format("Score: {0}", Score);
            scoreLabel.Position = new asd.Vector2DF(32.0f, 16.0f);
            AddObject(scoreLabel);
        }

        protected override void OnUpdated()
        {
            greenCharge.Scale = new asd.Vector2DF(Green, 32.0f);
            blueCharge.Scale = new asd.Vector2DF(Blue, 32.0f);
            redCharge.Scale = new asd.Vector2DF(Red, 32.0f);

            hpLabel.Text = String.Format("HP: {0}", Hp);
            scoreLabel.Text = String.Format("Score: {0}", Score);

            if (Green < max)
                Green++;
            if (Blue < max)
                Blue++;
            if (Red < max)
                Red++;
        }

        const int max = 120;
        public int Green { get; set; } = max;
        public int Blue { get; set; } = max;
        public int Red { get; set; } = max;
        public int Hp { get; set; } = 5;
        public int Score { get; set; } = 0;

        private asd.GeometryObject2D greenCharge = new asd.GeometryObject2D();
        private asd.GeometryObject2D blueCharge = new asd.GeometryObject2D();
        private asd.GeometryObject2D redCharge = new asd.GeometryObject2D();

        private asd.TextObject2D hpLabel = new asd.TextObject2D();
        private asd.TextObject2D scoreLabel = new asd.TextObject2D();
    }
}
