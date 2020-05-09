using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Wa2Location, LocationDto>();
        }
    }
}
