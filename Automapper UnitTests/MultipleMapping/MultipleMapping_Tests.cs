using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.MultipleMapping.Profiles;
using Automapper_UnitTests.MultipleMapping.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Test1;

public class MultipleMapping_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void MultipleMapping()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MultipleMapping_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source1 = this.fixture.Create<Source1>();
        var source2 = this.fixture.Create<Source2>();

        var destination = mapper.Map<Destination>(source1);
        destination = mapper.Map(source2, destination);

        destination.ValueFromSource1.Should().Be(source1.ValueFromSource1);
        destination.ValueFromSource2.Should().Be(source2.ValueFromSource2);
    }
}