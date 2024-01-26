using AutoMapper;
using RainfallApi.Models;
using RainfallApi.Responses;

namespace RainfallApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReadingApiModel, RainfallReadingResponse>()
                .ForMember(dest => dest.Readings, src => src.MapFrom(x => x.Items))
                .ReverseMap();

            CreateMap<ReadingApiItemModel, RainfallReading>()
                .ForMember(dest => dest.DateMeasured, src => src.MapFrom(x => x.DateTime))
                .ForMember(dest => dest.AmountMeasured, src => src.MapFrom(x => x.Value))
                .ReverseMap();
        }
    }
}
