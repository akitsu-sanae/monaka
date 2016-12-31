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
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var nyan = System.Windows.Forms.MessageBox.Show(
                "ふるすくりーんにする？",
                "monaka",
                System.Windows.Forms.MessageBoxButtons.YesNo);
            var option = new asd.EngineOption();
            option.IsFullScreen = nyan == System.Windows.Forms.DialogResult.Yes;

            asd.Engine.Initialize("monaka", 640, 480, option);
            Resource.Initialize();
            Input.Initialize();
            asd.Engine.ChangeScene(new Scene.Title());
            while (asd.Engine.DoEvents())
            {
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                    break;
                asd.Engine.Update();
            }
            asd.Engine.Terminate();
        }
    }
}
