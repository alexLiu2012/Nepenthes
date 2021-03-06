﻿using StackTools.Wa2Wrapper.wa2Resource;
using AutoMapper;

namespace StackTools.Nepenthes.RestApi.Dtos
{
    public class BatchProfile : Profile
    {
        public BatchProfile()
        {
            CreateMap<Wa2Batch, BatchDto>()
                .ForMember(dest=>dest.Location, opt => opt.MapFrom(src=>src.Location.Trim("/wa/2/locations/".ToCharArray())));
        }
    }
}
