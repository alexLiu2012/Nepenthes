using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class KeyInfoProfile : Profile
    {
        public KeyInfoProfile()
        {
            CreateMap<Wa2KeyInfo, KeyInfoDto>()
                .ForMember(dest => dest.DispCategory, opt => opt.MapFrom(src => src.Display.Category))
                .ForMember(dest => dest.DispGroup, opt => opt.MapFrom(src => src.Display.Group))
                .ForMember(dest => dest.DispName, opt => opt.MapFrom(src => src.Display.Name))
                .ForMember(dest => dest.DispDescription, opt => opt.MapFrom(src => src.Display.Description));
        }
    }
}
