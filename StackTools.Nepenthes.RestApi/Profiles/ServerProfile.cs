using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class ServerProfile : Profile
    {
        public ServerProfile()
        {
            CreateMap<Wa2Server, ServerDto>();
        }
    }
}
