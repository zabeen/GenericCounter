﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCounter.Library
{
    public class Apple : ICountable
    {
        public int Count => _count;

        private int _count = 1;
    }
}
