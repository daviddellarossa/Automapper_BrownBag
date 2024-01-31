using AutoMapper;
using Automapper_UnitTests.MultipleMapping.Types;

namespace Automapper_UnitTests.MultipleMapping.Profiles;

internal class MultipleMapping_Profile : Profile
{
    public MultipleMapping_Profile()
    {
        CreateMap<Source1, Destination>()
            .IgnoreNonExistingMembers();
        CreateMap<Source2, Destination>()
            .IgnoreNonExistingMembers();
    }


}

internal static class AutoMapperExtensionMethods
{
    public static IMappingExpression<TSource, TDestination> IgnoreNonExistingMembers<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expr)
    {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        foreach (var property in destinationType.GetProperties())
        {
            if (sourceType.GetProperty(property.Name) != null)
                continue;
            expr.ForMember(property.Name, opt => opt.Ignore());
        }

        return expr;
    }
}

