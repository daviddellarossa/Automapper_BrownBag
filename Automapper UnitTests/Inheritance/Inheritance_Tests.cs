using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.Inheritance.Profiles;
using Automapper_UnitTests.Inheritance.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Inheritance;

public class Inheritance_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    // Automapper doesn't know that there is a more specific mapping from OnlineOrder to OnlineOrderDto and uses the OrderDto base mapping.
    public void Inheritance_No_Include()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Inheritance_No_Include_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var order = this.fixture.Create<OnlineOrder>();
        var mapped = mapper.Map(order, order.GetType(), typeof(OrderDto));

        mapped.Should().NotBeOfType<OnlineOrderDto>();
        mapped.Should().BeOfType<OrderDto>();
    }

    [Fact]
    // Automapper knows that there is a more specific mapping from OnlineOrder to OnlineOrderDto and prefers this to the OrderDto base mapping.
    public void Inheritance_With_Include()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Inheritance_With_Include_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var order = this.fixture.Create<OnlineOrder>();
        var mapped = mapper.Map<OrderDto>(order);

        mapped.Should().BeOfType<OnlineOrderDto>();
    }

    [Fact]
    // Automapper knows that there is a more specific mapping from OnlineOrder to OnlineOrderDto and prefers this to the OrderDto base mapping.
    public void Inheritance_With_IncludeBase()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Inheritance_With_IncludeBase_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var order = this.fixture.Create<OnlineOrder>();
        var mapped = mapper.Map<OrderDto>(order);

        mapped.Should().BeOfType<OnlineOrderDto>();
    }

    [Fact]
    // Automapper knows that there is a more specific mapping from OnlineOrder to OnlineOrderDto and prefers this to the OrderDto base mapping.
    public void Inheritance_With_IncludeAllDerived()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Inheritance_With_IncludeAllDerived_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var order = this.fixture.Create<OnlineOrder>();
        var mapped = mapper.Map<OrderDto>(order);

        mapped.Should().BeOfType<OnlineOrderDto>();
    }
}