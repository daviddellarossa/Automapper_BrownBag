using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.Conditions.Profiles;
using Automapper_UnitTests.Conditions.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Conditions;

public class Conditions_Tests
{
    private Fixture fixture = new Fixture();

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(1, 1)]
    [InlineData(0, 0)]
    public void PreConditions(int sourceValue, uint destinationValue)
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<PreConditions_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture
            .Build<Source>()
            .With(x => x.Value, sourceValue)
            .Create();

        var destination = mapper.Map<Destination>(source);

        destination.Value.Should().Be(destinationValue);
    }

    [Theory]
    [InlineData(-1, null)]
    [InlineData(1, "1.0")]
    [InlineData(0, ".0")]
    public void Conditions(int sourceValue, string? destinationValue)
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Conditions_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture
            .Build<Source>()
            .With(x => x.Value, sourceValue)
            .Create();

        var destination = mapper.Map<DestinationV2>(source);

        destination.Value.Should().Be(destinationValue);
    }
}