using AutoMapper;
using Automapper_UnitTests.OpenGenerics.Types;

namespace Automapper_UnitTests.OpenGenerics.Profiles;

internal class OpenGenerics_Profile : Profile
{
    public OpenGenerics_Profile()
    {
        //CreateMap<Source<>, Destination<>>(); This does not compile.
        CreateMap(typeof(Source<>), typeof(Destination<>));
    }
}
