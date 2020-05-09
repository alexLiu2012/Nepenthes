using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Wa2Wrapper
{
    public class Wa2Client
    {
        private Wa2ClientOptions _wa2ClientOpt;
        private IHttpClientFactory _httpClientFactory;
        private IMemoryCache _memoryCache;

        public Wa2Client(
            Wa2ClientOptions aWa2ClientOpt, 
            IHttpClientFactory aHttpFactory, 
            IMemoryCache aMemoryCache)
        {
            this._wa2ClientOpt = aWa2ClientOpt;
            this._httpClientFactory = aHttpFactory;
            this._memoryCache = aMemoryCache;
        }

        private string GetResources(string path, TimeSpan expiration)
        {
            var reqClient = this._wa2ClientOpt.GetRequestClient(this._httpClientFactory);            

            if (this._wa2ClientOpt.UseMemoryCache == true)
            {
                return this._memoryCache.GetOrCreate(path, factory =>
                {
                    factory.SetAbsoluteExpiration(expiration);
                    return reqClient.GetStringAsync(path).Result;
                });                
            }
            else
            {
                return reqClient.GetStringAsync(path).Result;
            }            
        }
              
        /// <summary>
        /// Get resources by the generic type of the resource itself
        /// </summary>
        /// <typeparam name="TResource">Type of resource required</typeparam>
        /// <param name="query">Query string for such request of resource</param>
        /// <param name="filter">Expression to filter resource by</param>
        /// <returns></returns>
        public IEnumerable<TResource> Retrieve<TResource>(string query = null, Func<TResource, bool> filter = null) /*where TResource : Wa2ResourceItem*/
        {
            // query should start with '?', be like '?queryKey=queryValue'

            var path = this._wa2ClientOpt.GetPath<TResource>() + query;
            var expiration = this._wa2ClientOpt.GetExpiration<TResource>();

            var rsc = this.GetResources(path, expiration);
            var rscObjs = JsonConvert.DeserializeObject<Wa2ResourceCollection<TResource>>(rsc).Items;            

            // filter objects
            if (filter != null)
            {
                rscObjs = rscObjs.Where(filter);
            }
            
            // override timestamp for real-time timestamp
            if (typeof(TResource) == typeof(Wa2KeyValue) && this._wa2ClientOpt.UseOverridedTimestamp == true) 
            {
                var objs = (IEnumerable<Wa2KeyValue>)rscObjs;
                foreach (var obj in objs)
                {
                    obj.Timestamp = DateTime.Now;
                }
            }

            return rscObjs;
        }
                
        /*           
         * get keyvalue history
         * by {id}?query
         * also by keyinfo name in the batch?
         */
        public Wa2KeyValueHistory RetrieveKeyValueHistory()
        {
            var path = "";
            var query = "";
            var expiration = TimeSpan.Zero;

            var rsc = this.GetResources(path, expiration);
            var rscObj = JsonConvert.DeserializeObject<Wa2KeyValueHistory>(rsc);

            return rscObj;
        }
    }
}
