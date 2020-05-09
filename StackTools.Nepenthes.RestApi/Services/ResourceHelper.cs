using System;
using System.Collections.Generic;
using System.Linq;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.RestApi.Services
{
    public class ResourceHelper
    {
        private Wa2Client _client;
        private MappingHelper _mapHelper;

        public ResourceHelper(Wa2Client aClient, MappingHelper aMapHelper)
        {
            this._client = aClient;
            this._mapHelper = aMapHelper;
        }

        // get web access resource in DTO type
        public IEnumerable<TDto> GetResource<TOrigin, TDto>(Func<TDto, bool> filter, string queryOrigin = null, Func<TOrigin, bool> filterOrigin = null) where TOrigin : Wa2ResourceItem
        {
            var origins = this._client.Retrieve(queryOrigin, filterOrigin);
            var dtos = this._mapHelper.GetDtos<TOrigin, TDto>(origins);

            if(filter != null)
            {
                dtos = dtos.Where(filter);
            }

            return dtos;
        }
        
    }
}
