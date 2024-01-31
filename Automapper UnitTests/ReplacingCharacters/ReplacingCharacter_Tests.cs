using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.ReplacingCharacters.Profiles;
using Automapper_UnitTests.ReplacingCharacters.Types;
using FluentAssertions;

namespace Automapper_UnitTests.ReplacingCharacters;

public class ReplacingCharacter_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void ReplacingCharacters_No_Configuration_Fails()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_NoCharacterMapping>());
       
        Assert.ThrowsAny<Exception>(config.AssertConfigurationIsValid);
    }

    [Fact]
    public void ReplacingCharacters_With_Configuration_OK()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithCharacterMapping>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = fixture.Create<Source>();

        var destination = mapper.Map<Destination>(source);

        source.Ävíator.Should().Be(destination.Aviator);
        source.SubAirlinaFlight.Should().Be(destination.SubAirlineFlight);
        source.Value.Should().Be(destination.Value);
    }
}