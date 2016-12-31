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
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();
            var titleLabel = new asd.TextObject2D();
            titleLabel.Font = Resource.Big;
            titleLabel.Text = "monaka";
            titleLabel.Position = new asd.Vector2DF(200.0f, 200.0f);
            layer.AddObject(titleLabel);
            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (Input.isPushed(Input.Button.Button1))
                asd.Engine.ChangeScene(new Scene.Game());
        }
    }
}
