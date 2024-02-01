using AutoMapper;
using Automapper_UnitTests.Construction.Types;

namespace Automapper_UnitTests.Construction.Profiles;

internal class DefaultConstruction_Profile : Profile
{
    public DefaultConstruction_Profile() // Configuration not valid. Throws.
    {
        CreateMap<Source, DestinationWithDefaultConstructor>();
    }

}
internal class NonDefaultConstruction_CtorParam_Profile : Profile
{
    public NonDefaultConstruction_CtorParam_Profile()
    {
        CreateMap<Source, DestinationWithDefaultConstructor>()
            .ForCtorParam(nameof(DestinationWithDefaultConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }

}

internal class DefaultConstruction_Member_Profile : Profile
{
    public DefaultConstruction_Member_Profile()
    {
        CreateMap<Source, DestinationWithDefaultConstructor>()
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value));
    }
}

internal class NonDefaultConstruction_Member_CtorParam_Profile : Profile
{
    public NonDefaultConstruction_Member_CtorParam_Profile()
    {
        CreateMap<Source, DestinationWithDefaultConstructor>()
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value))
            .ForCtorParam(nameof(DestinationWithDefaultConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }
}

internal class NonDefaultConstruction_CtorParam_Member_Profile : Profile
{
    public NonDefaultConstruction_CtorParam_Member_Profile()
    {
        CreateMap<Source, DestinationWithDefaultConstructor>()
            .ForCtorParam(nameof(DestinationWithDefaultConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value))
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value));
    }
}

internal class NonEmptyConstruction_CtorParam_Profile : Profile
{
    public NonEmptyConstruction_CtorParam_Profile()
    {
        CreateMap<Source, DestinationWithNonDefaultConstructor>()
            .ForCtorParam(nameof(DestinationWithNonDefaultConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }
}

internal class NonEmptyConstruction_Member_Profile : Profile // Configuration not valid. Throws.
{
    public NonEmptyConstruction_Member_Profile()
    {
        CreateMap<Source, DestinationWithNonDefaultConstructor>()
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value));
    }
}

internal class Construction_With_ConstructUsing_Profile: Profile
{
    public Construction_With_ConstructUsing_Profile()
    {
        CreateMap<Source, Destination>()
            .ConstructUsing(x => DestinationFactory.CreateDestination())
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => src.Value));
    }
}

internal class Construction_With_ForMember_And_ForCtorParam_Profile: Profile
{
    public Construction_With_ForMember_And_ForCtorParam_Profile()
    {
        CreateMap<Source, Destination>()
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member: " + src.Value))
            .ForCtorParam(nameof(Destination.Id), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }
}