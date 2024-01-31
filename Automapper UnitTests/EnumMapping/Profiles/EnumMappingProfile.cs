using AutoMapper;
using AutoMapper.Extensions.EnumMapping; // From separate extension package.
using Automapper_UnitTests.EnumMapping.Types;

namespace Automapper_UnitTests.EnumMapping.Profiles;

internal class EnumMapping_MapByName_Profile : Profile
{
    public EnumMapping_MapByName_Profile()
    {
        CreateMap<SourceEnum, DestinationEnum>()
            .ConvertUsingEnumMapping(opt =>
            {
                opt.MapByName();
                opt.MapValue(SourceEnum.First, DestinationEnum.Default); // Map unsupported value First onto Default.
            })
            .ReverseMap();
    }
}