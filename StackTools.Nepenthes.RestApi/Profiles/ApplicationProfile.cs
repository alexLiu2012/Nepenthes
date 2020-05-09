using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Wa2Application, ApplicationDto>();
        }
    }
}
