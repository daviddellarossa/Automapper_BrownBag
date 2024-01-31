using AutoMapper;
using Automapper_UnitTests.Flattening.Types;

namespace Automapper_UnitTests.Flattening.Profiles;

internal class Flattening_Profile : Profile
{
    public Flattening_Profile()
    {
        CreateMap<Order, OrderDto>();
    }
}

internal class Flattening_With_IncludeMember_Profile : Profile
{
    public Flattening_With_IncludeMember_Profile()
    {
        CreateMap<Source, Destination>().IncludeMembers(s => s.InnerSource, s => s.OtherInnerSource);
        CreateMap<InnerSource, Destination>(MemberList.None); // MemberList.None or MemberList.Source is necessary because InnerSource has no Title member.
        CreateMap<OtherInnerSource, Destination>();
    }
}

internal class Unflattening_Profile : Profile
{
    public Unflattening_Profile()
    {
        CreateMap<SimpleOrder, OrderDto>()
            .ReverseMap();
    }
}

internal class Unflattening_With_Customization_Profile : Profile
{
    public Unflattening_With_Customization_Profile()
    {
        CreateMap<SimpleOrderV2, OrderDto>()
            .ForMember(dst => dst.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
            .ReverseMap()
            .ForPath(dst => dst.Customer.FirstName, opt => opt.MapFrom(src => src.CustomerName.Substring(0, src.CustomerName.IndexOf(" "))))
            .ForPath(dst => dst.Customer.LastName, opt => opt.MapFrom(src => src.CustomerName.Substring(src.CustomerName.IndexOf(" ") + 1)))
            ;
    }
}