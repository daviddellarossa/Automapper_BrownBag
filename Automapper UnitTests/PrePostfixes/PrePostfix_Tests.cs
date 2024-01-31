using AutoFixture;
using AutoMapper;
using Automapper_UnitTests.PrePostfixes.Profiles;
using Automapper_UnitTests.PrePostfixes.Types;
using FluentAssertions;

namespace Automapper_UnitTests.PrePostfixes
{
    public class PrePostfix_Tests
    {
        private Fixture fixture = new Fixture();

        [Fact]
        public void NoPrePostfixes()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_NoPrePost>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<Source>();

            var destination = mapper.Map<Destination>(source);

            destination.Value1.Should().Be(source.Value1);
            destination.Value2.Should().Be(source.Value2);
        }

        [Fact]
        public void WithSrcPre()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithSrcPre>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<SourceWPre>();

            var destination = mapper.Map<Destination>(source);

            destination.Value1.Should().Be(source.srcpre_Value1);
            destination.Value2.Should().Be(source.srcpre_Value2);
        }

        [Fact]
        public void WithSrcPost()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithSrcPost>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<SourceWPost>();

            var destination = mapper.Map<Destination>(source);

            destination.Value1.Should().Be(source.Value1_srcpost);
            destination.Value2.Should().Be(source.Value2_srcpost);
        }

        [Fact]
        public void WithDstPre()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithDstPre>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<Source>();

            var destination = mapper.Map<DestinationWPre>(source);

            destination.dstpre_Value1.Should().Be(source.Value1);
            destination.dstpre_Value2.Should().Be(source.Value2);
        }

        [Fact]
        public void WithDstPost()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithDstPost>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<Source>();

            var destination = mapper.Map<DestinationWPost>(source);

            destination.Value1_dstpost.Should().Be(source.Value1);
            destination.Value2_dstpost.Should().Be(source.Value2);
        }

        [Fact]
        public void WithSrcPreDstPost()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithSrcPreDstPost>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<SourceWPre>();

            var destination = mapper.Map<DestinationWPost>(source);

            destination.Value1_dstpost.Should().Be(source.srcpre_Value1);
            destination.Value2_dstpost.Should().Be(source.srcpre_Value2);
        }

        [Fact]
        public void WithSrcPostDstPre()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<Profile_WithSrcPostDstPre>());
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            var source = this.fixture.Create<SourceWPost>();

            var destination = mapper.Map<DestinationWPre>(source);

            destination.dstpre_Value1.Should().Be(source.Value1_srcpost);
            destination.dstpre_Value2.Should().Be(source.Value2_srcpost);
        }
    }
}