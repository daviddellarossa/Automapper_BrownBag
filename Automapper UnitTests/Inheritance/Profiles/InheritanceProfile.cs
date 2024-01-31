using AutoMapper;
using Automapper_UnitTests.Inheritance.Types;

namespace Automapper_UnitTests.Inheritance.Profiles;

internal class Inheritance_No_Include_Profile : Profile
{
    public Inheritance_No_Include_Profile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OnlineOrder, OnlineOrderDto>();
        CreateMap<MailOrder, MailOrderDto>();
    }
}

internal class Inheritance_With_Include_Profile : Profile
{
    public Inheritance_With_Include_Profile()
    {
        CreateMap<Order, OrderDto>()
            .Include<OnlineOrder, OnlineOrderDto>()
            .Include<MailOrder, MailOrderDto>()
            ;
        CreateMap<OnlineOrder, OnlineOrderDto>();
        CreateMap<MailOrder, MailOrderDto>();
    }
}

internal class Inheritance_With_IncludeBase_Profile : Profile
{
    public Inheritance_With_IncludeBase_Profile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OnlineOrder, OnlineOrderDto>()
            .IncludeBase<Order, OrderDto>();
        CreateMap<MailOrder, MailOrderDto>()
            .IncludeBase<Order, OrderDto>();
    }
}

internal class Inheritance_With_IncludeAllDerived_Profile : Profile
{
    public Inheritance_With_IncludeAllDerived_Profile()
    {
        CreateMap<Order, OrderDto>()
            .IncludeAllDerived();
        CreateMap<OnlineOrder, OnlineOrderDto>();
        CreateMap<MailOrder, MailOrderDto>();
    }
}