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
    class Result : asd.Scene
    {
        public Result(Status status)
        {
            var layer = new asd.Layer2D();

            var scoreLabel = new asd.TextObject2D();
            scoreLabel.Font = Resource.PixelMPlus;
            scoreLabel.Text = String.Format("Score: {0}\n Press Button1", status.Score);
            scoreLabel.CenterPosition = Resource.PixelMPlus.CalcTextureSize(scoreLabel.Text, asd.WritingDirection.Horizontal).To2DF()/2.0f;
            scoreLabel.Position = new asd.Vector2DF(320, 240);
            scoreLabel.Scale = new asd.Vector2DF(3.0f, 3.0f);
            layer.AddObject(scoreLabel);

            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (Input.isPushed(Input.Button.Button1))
                asd.Engine.ChangeScene(new Scene.Title());
        }
    }
}
