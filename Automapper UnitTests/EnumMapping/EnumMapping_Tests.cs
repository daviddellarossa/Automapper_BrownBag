using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.EnumMapping.Profiles;
using Automapper_UnitTests.EnumMapping.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Test1;

public class EnumMapping_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void EnumMapping_MapByName()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<EnumMapping_MapByName_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = SourceEnum.Second;

        var destination = mapper.Map<DestinationEnum>(source);

        destination.ToString().Should().Be(source.ToString());
    }

    [Fact]
    public void EnumMapping_MapByName_UnsupportedValue()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<EnumMapping_MapByName_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = SourceEnum.First;

        var destination = mapper.Map<DestinationEnum>(source);

        destination.ToString().Should().Be(DestinationEnum.Default.ToString());
    }
}