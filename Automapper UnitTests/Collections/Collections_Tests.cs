using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.Collections.Profiles;
using Automapper_UnitTests.Collections.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Collections;

public class Collections_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void PolimorphicElements_WrongMapping()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<PolimorphicElements_WrongMapping>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var sources = new[]
        {
            this.fixture.Create<ParentSource>(),
            this.fixture.Create<ChildSource>(),
            this.fixture.Create<ParentSource>()
        };

        var destinations = mapper.Map<ParentDestination[]>(sources);

        destinations[0].Should().BeOfType<ParentDestination>();
        destinations[1].Should().NotBeOfType<ChildDestination>(); // Not mapped to child element
        destinations[2].Should().BeOfType<ParentDestination>();
    }

    [Fact]
    public void PolimorphicElements_CorrectMapping()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<PolimorphicElements_CorrectMapping>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var sources = new[]
        {
            this.fixture.Create<ParentSource>(),
            this.fixture.Create<ChildSource>(),
            this.fixture.Create<ParentSource>()
        };

        var destinations = mapper.Map<ParentDestination[]>(sources);

        destinations[0].Should().BeOfType<ParentDestination>();
        destinations[1].Should().BeOfType<ChildDestination>(); // Mapped to child element
        destinations[2].Should().BeOfType<ParentDestination>();
    }
}