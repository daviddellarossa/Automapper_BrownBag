﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper_UnitTests.OpenGenerics.Types
{
    internal class Destination<T>
    {
        public T Value { get; set; }
    }
}
