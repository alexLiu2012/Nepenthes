using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class ControllerProfile : Profile
    {
        public ControllerProfile()
        {
            CreateMap<Wa2Controller, ControllerDto>();
        }
    }
}
