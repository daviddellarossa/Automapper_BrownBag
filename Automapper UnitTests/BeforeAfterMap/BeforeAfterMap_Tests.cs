using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.BeforeAfterMap.Profiles;
using Automapper_UnitTests.BeforeAfterMap.Types;
using FluentAssertions;

namespace Automapper_UnitTests.BeforeAfterMap;

public class BeforeAfterMap_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void BeforeAfterMap()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BeforeAfterMap_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();

        var destination = mapper.Map<Destination>(source);

        destination.Value1.Should().Be(source.Value1);
        destination.Value2.Should().Be(source.Value2 + 20);
    }
}