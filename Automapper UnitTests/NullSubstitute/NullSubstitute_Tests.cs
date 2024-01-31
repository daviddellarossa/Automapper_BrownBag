using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.NullSubstitute.Profiles;
using Automapper_UnitTests.NullSubstitute.Types;
using FluentAssertions;

namespace Automapper_UnitTests.NullSubstitute;

public class NullSubstitute_Tests
{
    private Fixture fixture = new Fixture();

    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    [InlineData("Any string", "Any string")]
    public void NullSubstitute(string? actual, string expected)
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NullSubstitute_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture
            .Build<Source>()
            .With(x => x.Value1, actual)
            .Create();

        var destination = mapper.Map<Destination>(source);

        destination.Value1.Should().Be(expected);
    }
}