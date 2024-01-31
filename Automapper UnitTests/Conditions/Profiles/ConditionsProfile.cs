using AutoMapper;
using Automapper_UnitTests.Conditions.Types;

namespace Automapper_UnitTests.Conditions.Profiles;

internal class PreConditions_Profile : Profile
{
    public PreConditions_Profile()
    {
        CreateMap<Source, Destination>()
            .ForMember(dst => dst.Value, opt => opt.PreCondition(src => (src.Value >= 0)));
    }
}

internal class Conditions_Profile : Profile
{
    public Conditions_Profile()
    {
        CreateMap<Source, DestinationV2>()
            .ForMember(dst => dst.Value, opt =>
            {
                opt.Condition(src => (src.Value >= 0));
                opt.MapFrom(src => src.Value.ToString("#.0"));
            });
    }
}