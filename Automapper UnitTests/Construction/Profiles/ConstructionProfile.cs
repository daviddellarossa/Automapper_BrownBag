using AutoMapper;
using Automapper_UnitTests.Construction.Types;

namespace Automapper_UnitTests.Construction.Profiles;

internal class EmptyConstruction_Profile : Profile
{
    public EmptyConstruction_Profile() // Configuration not valid. Throws.
    {
        CreateMap<Source, DestinationWithEmptyConstructor>();
    }

}
internal class EmptyConstruction_CtorParam_Profile : Profile
{
    public EmptyConstruction_CtorParam_Profile()
    {
        CreateMap<Source, DestinationWithEmptyConstructor>()
            .ForCtorParam(nameof(DestinationWithEmptyConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }

}

internal class EmptyConstruction_Member_Profile : Profile
{
    public EmptyConstruction_Member_Profile()
    {
        CreateMap<Source, DestinationWithEmptyConstructor>()
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value));
    }
}

internal class EmptyConstruction_Member_CtorParam_Profile : Profile
{
    public EmptyConstruction_Member_CtorParam_Profile()
    {
        CreateMap<Source, DestinationWithEmptyConstructor>()
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value))
            .ForCtorParam(nameof(DestinationWithEmptyConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }
}

internal class EmptyConstruction_CtorParam_Member_Profile : Profile
{
    public EmptyConstruction_CtorParam_Member_Profile()
    {
        CreateMap<Source, DestinationWithEmptyConstructor>()
            .ForCtorParam(nameof(DestinationWithEmptyConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value))
            .ForMember(dst => dst.OtherValue, opt => opt.MapFrom(src => "From member assignment: " + src.Value));
    }
}

internal class NonEmptyConstruction_CtorParam_Profile : Profile
{
    public NonEmptyConstruction_CtorParam_Profile()
    {
        CreateMap<Source, DestinationWithNonEmptyConstructor>()
            .ForCtorParam(nameof(DestinationWithNonEmptyConstructor.OtherValue), opt => opt.MapFrom(src => "From ctor: " + src.Value));
    }
}

internal class NonEmptyConstruction_Member_Profile : Profile // Configuration not valid. Throws.
{
    public NonEmptyConstruction_Member_Profile()
    {
        CreateMap<Source, DestinationWithNonEmptyConstructor>()
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