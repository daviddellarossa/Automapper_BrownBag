using AutoMapper;
using Automapper_UnitTests.CustomConverters.Types;

namespace Automapper_UnitTests.CustomConverters.Profiles;

internal class CustomValueConverterProfile : Profile
{
    public CustomValueConverterProfile()
    {
        CreateMap<Source, Destination>()
            .ForMember(dst => dst.Value1, opt => opt.ConvertUsing<string>(new StringIntValueConverter(), src => src.Value1))
            .ForMember(dst => dst.Value2, opt => opt.ConvertUsing<string>(new StringDateTimeValueConverter(), src => src.Value2));
    }
}

internal class CustomTypeConverterProfile : Profile
{
    public CustomTypeConverterProfile()
    {
        CreateMap<Source, Destination>();
        CreateMap<string, int>().ConvertUsing(new StringIntTypeConverter());
        CreateMap<string, DateTime>().ConvertUsing(new StringDateTimeTypeConverter());
    }
}

internal class StringDateTimeTypeConverter : ITypeConverter<string, DateTime>
{
    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    {
        return System.Convert.ToDateTime(source);
    }
}

internal class StringIntTypeConverter : ITypeConverter<string, int>
{
    public int Convert(string source, int destination, ResolutionContext context)
    {
        return System.Convert.ToInt32(source);
    }
}

internal class StringIntValueConverter : IValueConverter<string, int>
{
    public int Convert(string sourceMember, ResolutionContext context)
    {
        return System.Convert.ToInt32(sourceMember);
    }
}

internal class StringDateTimeValueConverter : IValueConverter<string, DateTime>
{
    public DateTime Convert(string sourceMember, ResolutionContext context)
    {
        return System.Convert.ToDateTime(sourceMember);
    }
}
