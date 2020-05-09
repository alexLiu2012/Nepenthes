using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class KeyValueProfile : Profile
    {
        public KeyValueProfile()
        {
            CreateMap<Wa2KeyValue, KeyValueDto>()
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Actual.Display))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Actual.Value))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Actual.Unit))
                .ForMember(dest => dest.Precision, opt => opt.MapFrom(src => src.Actual.Precision))
                .ForMember(dest => dest.IsReadonly, opt => opt.MapFrom(src => src.Actual.IsReadonly));
        }
    }
}
