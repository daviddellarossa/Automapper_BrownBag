using AutoMapper;
using Automapper_UnitTests.BeforeAfterMap.Types;

namespace Automapper_UnitTests.BeforeAfterMap.Profiles;

internal class BeforeAfterMap_Profile : Profile
{
    public BeforeAfterMap_Profile()
    {
        CreateMap<Source, Destination>()
            .BeforeMap((src, dest) => src.Value1 *= 10)
            .AfterMap((src, dest) => dest.Value2 += 20)
            ;
    }
}
