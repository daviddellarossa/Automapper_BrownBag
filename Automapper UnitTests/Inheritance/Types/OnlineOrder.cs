using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper_UnitTests.Inheritance.Types
{
    internal class OnlineOrder : Order
    {
        public string DerivedValue { get; set; }
    }
}
