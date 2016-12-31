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
    static class Resource
    {
        public static asd.Font Big { get; private set; }
        public static asd.Font PixelMPlus { get; private set; }
        public static System.Random Rand = new Random();
        public static void Initialize()
        {
            Big = asd.Engine.Graphics.CreateDynamicFont("Resource/PixelMplus10-Regular.ttf", 64, new asd.Color(255, 255, 255), 0, new asd.Color());
            PixelMPlus = asd.Engine.Graphics.CreateDynamicFont("Resource/PixelMplus10-Regular.ttf", 16, new asd.Color(255, 255, 255), 0, new asd.Color());
        }
    }
}
