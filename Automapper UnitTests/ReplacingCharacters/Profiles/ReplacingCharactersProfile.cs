using AutoMapper;
using Automapper_UnitTests.ReplacingCharacters.Types;

namespace Automapper_UnitTests.ReplacingCharacters.Profiles;

internal class Profile_NoCharacterMapping : Profile
{
    public Profile_NoCharacterMapping()
    {
        CreateMap<Source, Destination>();
    }
}

internal class Profile_WithCharacterMapping : Profile
{
    public Profile_WithCharacterMapping()
    {
        this.ReplaceMemberName("Ä", "A");
        this.ReplaceMemberName("í", "i");
        this.ReplaceMemberName("Airlina", "Airline");

        CreateMap<Source, Destination>();
    }
}