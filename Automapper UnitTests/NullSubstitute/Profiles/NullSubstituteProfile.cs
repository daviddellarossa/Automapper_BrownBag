using AutoMapper;
using Automapper_UnitTests.NullSubstitute.Types;

namespace Automapper_UnitTests.NullSubstitute.Profiles;

internal class NullSubstitute_Profile : Profile
{
    public NullSubstitute_Profile()
    {
        CreateMap<Source, Destination>()
            .ForMember(dst => dst.Value1, opt => opt.NullSubstitute(String.Empty));    
    }
}
