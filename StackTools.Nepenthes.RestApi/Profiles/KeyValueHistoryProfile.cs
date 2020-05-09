using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class KeyValueHistoryProfile : Profile
    {
        public KeyValueHistoryProfile()
        {
            CreateMap<Wa2KeyValueHistory, KeyValueHistoryDto>();
        }
    }
}
