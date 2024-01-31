using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.CustomConverters.Profiles;
using Automapper_UnitTests.CustomConverters.Types;
using FluentAssertions;

namespace Automapper_UnitTests.CustomConverters;

public class CustomConverters_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void CustomValueConverters()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CustomValueConverterProfile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture
            .Build<Source>()
            .With(x => x.Value1, this.fixture.Create<int>().ToString())
            .With(x => x.Value2, this.fixture.Create<DateTime>().ToString())
            .Create();

        var destination = mapper.Map<Destination>(source);

        destination.Value1.ToString().Should().Be(source.Value1);
        destination.Value2.ToString().Should().Be(source.Value2);
    }

    [Fact]
    public void CustomTypeConverters()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CustomTypeConverterProfile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture
            .Build<Source>()
            .With(x => x.Value1, this.fixture.Create<int>().ToString())
            .With(x => x.Value2, this.fixture.Create<DateTime>().ToString())
            .Create();

        var destination = mapper.Map<Destination>(source);

        destination.Value1.ToString().Should().Be(source.Value1);
        destination.Value2.ToString().Should().Be(source.Value2);
    }
}