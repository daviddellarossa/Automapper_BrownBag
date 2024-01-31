using AutoMapper;
using Automapper_UnitTests.Collections.Types;

namespace Automapper_UnitTests.Collections.Profiles;

internal class PolimorphicElements_WrongMapping : Profile
{
    public PolimorphicElements_WrongMapping()
    {
        CreateMap<ChildSource, ChildDestination>();
        CreateMap<ParentSource, ParentDestination>();
    }
}

internal class PolimorphicElements_CorrectMapping : Profile
{
    public PolimorphicElements_CorrectMapping()
    {
        CreateMap<ChildSource, ChildDestination>();
        CreateMap<ParentSource, ParentDestination>()
            .Include<ChildSource, ChildDestination>();
    }
}