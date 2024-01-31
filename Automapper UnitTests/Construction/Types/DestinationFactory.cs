using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper_UnitTests.Construction.Types
{
    internal static class DestinationFactory
    {
        public static Destination CreateDestination()
        {
            return new Destination(Guid.NewGuid().ToString());
        }
    }
}
