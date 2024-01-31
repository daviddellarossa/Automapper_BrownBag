using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.Flattening.Profiles;
using Automapper_UnitTests.Flattening.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Flattening;

public class Flattening_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    // Here, to map Total on the destination, Automapper uses a property on the source matching the "Get" + <property name> pattern.
    // If for any property on the destination type a property, method, or a method prefixed with “Get” does not exist on the source type, AutoMapper splits the destination member name into individual words (by PascalCase conventions).
    // This is what it does for CustomerName.
    public void Flattening()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Flattening_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var customer = this.fixture.Create<Customer>();
        var product = this.fixture.Create<Product>();
        var order = this.fixture
            .Build<Order>()
            .With(x => x.Customer, customer)
            .Do(x => x.AddOrderLineItem(product, this.fixture.Create<byte>()))
            .Create();

        var orderDto = mapper.Map<OrderDto>(order);

        orderDto.CustomerName.Should().Be(customer.Name);
        orderDto.Total.Should().Be(order.GetTotal());
    }

    [Fact]
    // If you need more control when flattening, you can use IncludeMembers.
    // You can map members of a child object to the destination object when you already have a map from the child type to the destination type (unlike the classic flattening that doesn’t require a map for the child type).
    // The order of the parameters in the IncludeMembers call is relevant. When mapping a destination member, the first match wins, starting with the source object itself and then with the included child objects in the order you specified.
    // So in the example above, Name is mapped from the source object itself and Description from InnerSource because it’s the first match.
    public void Flattening_With_IncludeMember()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Flattening_With_IncludeMember_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture
            .Build<Source>()
            .With(x => x.InnerSource, this.fixture
                .Build<InnerSource>()
                .Without(x => x.Name)
                .Create())
            .With(x => x.OtherInnerSource, this.fixture
                .Build<OtherInnerSource>()
                .Without(x => x.Description)
                .Without(x => x.Name)
                .Create())
            .Create();

        var destination = mapper.Map<Destination>(source);

        destination.Name.Should().Be(source.Name);
        destination.Description.Should().Be(source.InnerSource.Description);
        destination.Title.Should().Be(source.OtherInnerSource.Title);
    }

    [Fact]
    // By calling ReverseMap, AutoMapper creates a reverse mapping configuration that includes unflattening
    // Unflattening is only configured for ReverseMap. If you want unflattening, you must configure Entity -> Dto then call ReverseMap to create an unflattening type map configuration from the Dto -> Entity.
    public void Unflattening()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Unflattening_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var order = this.fixture.Create<SimpleOrder>();

        var orderDto = mapper.Map<OrderDto>(order);

        orderDto.CustomerName.Should().Be(order.Customer.Name);
        orderDto.Total.Should().Be(order.Total);

        orderDto.CustomerName = this.fixture.Create<string>();

        mapper.Map(orderDto, order);

        order.Customer.Name.Should().Be(orderDto.CustomerName);
    }

    [Fact]
    // With ReverseMap, validation is disabled, therefore, not specifying mappings for the reversed properties (FirstName and LastName), these would not be mapped.
    public void Unflattening_With_Customization()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Unflattening_With_Customization_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var order = this.fixture.Create<SimpleOrderV2>();

        var orderDto = mapper.Map<OrderDto>(order);

        orderDto.CustomerName.Should().Be($"{order.Customer.FirstName} {order.Customer.LastName}");
        orderDto.Total.Should().Be(order.Total);

        orderDto.CustomerName = "James Brown";

        mapper.Map(orderDto, order);

        order.Customer.FirstName.Should().Be("James");
        order.Customer.LastName.Should().Be("Brown");
    }
}