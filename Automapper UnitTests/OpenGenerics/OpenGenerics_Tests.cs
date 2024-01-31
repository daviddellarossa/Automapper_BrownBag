using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.OpenGenerics.Profiles;
using Automapper_UnitTests.OpenGenerics.Types;
using FluentAssertions;

namespace Automapper_UnitTests.OpenGenerics;

public class Test1_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void Test1()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<OpenGenerics_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source<int>>();

        var destination = mapper.Map<Destination<int>>(source);

        destination.Value.Should().Be(source.Value);
    }
}