﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_workshop.GameObjects
{
    class FoodHash : Food
    {
        public FoodHash(Wall wall) : base(wall, '#', 3)
        {
        }
    }
}
