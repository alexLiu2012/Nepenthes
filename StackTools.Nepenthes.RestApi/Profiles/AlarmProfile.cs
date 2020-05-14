using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class AlarmProfile : Profile
    {
        public AlarmProfile()
        {
            CreateMap<Wa2Alarm, AlarmDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src =>src.Location.Trim("/wa/2/locations/".ToCharArray())));
        }
    }
}
