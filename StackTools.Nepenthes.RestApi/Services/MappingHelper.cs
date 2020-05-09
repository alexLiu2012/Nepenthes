using System.Collections.Generic;
using AutoMapper;
using StackTools.Wa2Wrapper;

namespace StackTools.Nepenthes.RestApi.Services
{
    public class MappingHelper
    {
        private IMapper _mapper;                       

        public MappingHelper(IMapper aMapper, Wa2Client aClient)
        {
            _mapper = aMapper;            
        }        
        
        // map original web access resources to DTO type
        public IEnumerable<TDto> GetDtos<TOrigin, TDto>(IEnumerable<TOrigin> rscOrigin) 
        {            
            var dtos = new List<TDto>();                        

            foreach (var item in rscOrigin)
            {
                dtos.Add(_mapper.Map<TDto>(item));
            }

            return dtos as IEnumerable<TDto>;
        }
    }
}
