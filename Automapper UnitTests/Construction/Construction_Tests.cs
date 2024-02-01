using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.Collections.Types;
using Automapper_UnitTests.Construction.Profiles;
using Automapper_UnitTests.Construction.Types;
using FluentAssertions;

namespace Automapper_UnitTests.Construction;

public class Construction_Tests
{
    private Fixture fixture = new Fixture();

    [Fact]
    public void DestinationWithEmptyConstructor_Param_NotMapped()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DefaultConstruction_Profile>());
        Assert.ThrowsAny<Exception>(config.AssertConfigurationIsValid);
    }

    [Fact]
    public void DestinationWithEmptyConstructor_CtorParam()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NonDefaultConstruction_CtorParam_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();

        var destination = mapper.Map<DestinationWithDefaultConstructor>(source);

        destination.OtherValue.Should().EndWith(source.Value);
    }

    [Fact]
    public void DestinationWithEmptyConstruction_Member()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DefaultConstruction_Member_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();

        var destination = mapper.Map<DestinationWithDefaultConstructor>(source);

        destination.OtherValue.Should().EndWith(source.Value);
    }

    [Fact]
    // In case both CtorParam and Member are specified, Constructor wins
    public void DestinationWithEmptyConstructor_CtorParam_Member()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NonDefaultConstruction_CtorParam_Member_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();

        var destination = mapper.Map<DestinationWithDefaultConstructor>(source);

        destination.OtherValue.Should().Be("From ctor: " + source.Value);
    }

    [Fact]
    // In case both CtorParam and Member are specified, Constructor wins
    public void DestinationWithEmptyConstructor_Member_CtorParam()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NonDefaultConstruction_Member_CtorParam_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();

        var destination = mapper.Map<DestinationWithDefaultConstructor>(source);

        destination.OtherValue.Should().Be("From ctor: " + source.Value);
    }


    [Fact]
    public void DestinationWithNonEmptyConstructor_CtorParam()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NonEmptyConstruction_CtorParam_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();

        var destination = mapper.Map<DestinationWithNonDefaultConstructor>(source);

        destination.OtherValue.Should().EndWith(source.Value);
    }

    [Fact]
    public void DestinationWithNonEmptyConstructor_Member_Param()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NonEmptyConstruction_Member_Profile>());
        Assert.ThrowsAny<Exception>(config.AssertConfigurationIsValid);
    }

    [Fact]
    public void Destination_With_ConstructUsing()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Construction_With_ConstructUsing_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();
        var destination = mapper.Map<Destination>(source);

        destination.Id.Should().NotBeNullOrEmpty();
        destination.OtherValue.Should().EndWith(source.Value);
    }

    [Fact]
    public void Construction_With_ForMember_And_ForCtorParam()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<Construction_With_ForMember_And_ForCtorParam_Profile>());
        config.AssertConfigurationIsValid();
        var mapper = new Mapper(config);

        var source = this.fixture.Create<Source>();
        var destination = mapper.Map<Destination>(source);

        destination.Id.Should().StartWith("From ctor: " + source.Value);
        destination.OtherValue.Should().Be("From member: " + source.Value);
    }
}