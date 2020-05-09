using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class AlarmProfile : Profile
    {
        public AlarmProfile()
        {
            CreateMap<Wa2Alarm, AlarmDto>();
        }
    }
}
