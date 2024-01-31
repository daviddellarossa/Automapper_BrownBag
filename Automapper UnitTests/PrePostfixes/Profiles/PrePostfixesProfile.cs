using AutoMapper;
using Automapper_UnitTests.PrePostfixes.Types;

namespace Automapper_UnitTests.PrePostfixes.Profiles;

internal class Profile_NoPrePost : Profile
{
    public Profile_NoPrePost()
    {
        CreateMap<Source, Destination>();
    }
}

internal class Profile_WithSrcPre : Profile
{
    public Profile_WithSrcPre()
    {
        this.RecognizePrefixes("srcpre_");

        CreateMap<SourceWPre, Destination>();
    }
}

internal class Profile_WithSrcPost : Profile
{
    public Profile_WithSrcPost()
    {
        this.RecognizePostfixes("_srcpost");

        CreateMap<SourceWPost, Destination>();
    }
}

internal class Profile_WithDstPre : Profile
{
    public Profile_WithDstPre()
    {
        this.RecognizeDestinationPrefixes("dstpre_");

        CreateMap<Source, DestinationWPre>();
    }
}

internal class Profile_WithDstPost : Profile
{
    public Profile_WithDstPost()
    {
        this.RecognizeDestinationPostfixes("_dstpost");

        CreateMap<Source, DestinationWPost>();
    }
}

internal class Profile_WithSrcPreDstPost : Profile
{
    public Profile_WithSrcPreDstPost()
    {
        this.RecognizePrefixes("srcpre_");
        this.RecognizeDestinationPostfixes("_dstpost");

        CreateMap<SourceWPre, DestinationWPost>();
    }
}

internal class Profile_WithSrcPostDstPre : Profile
{
    public Profile_WithSrcPostDstPre()
    {
        this.RecognizeDestinationPrefixes("dstpre_");
        this.RecognizePostfixes("_srcpost");

        CreateMap<SourceWPost, DestinationWPre>();
    }
}