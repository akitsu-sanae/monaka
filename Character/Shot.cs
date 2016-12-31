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
    class Shot : asd.GeometryObject2D
    {
        public virtual bool isHit(Enemy.Enemy e)
        {
            return (Position - e.Position).Length < 16.0f;
        }
    }
}
