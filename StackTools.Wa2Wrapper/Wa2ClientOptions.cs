using System;
using System.Net.Http;
using StackTools.Wa2Wrapper.wa2Configs;

namespace StackTools.Wa2Wrapper
{
    public class Wa2ClientOptions
    {
        public bool UseMemoryCache { get; set; }
        public uint FoolProofExpiration { get; set; }
        public bool UseOverridedTimestamp { get; set; }        
        

        private Wa2ConnectOptions Connection { get; set; }
        private Wa2ResourceOptions ResourcePath { get; set; }
        private Wa2CacheOptions CacheExpiration { get; set; }

        public Wa2ClientOptions()
        {
            this.Connection = new Wa2ConnectOptions();
            this.ResourcePath = new Wa2ResourceOptions();
            this.CacheExpiration = new Wa2CacheOptions();
        }

        // Get http client for the request
        public HttpClient GetRequestClient(IHttpClientFactory aHttpClientFactory)
        {
            var httpClient = aHttpClientFactory.CreateClient();
            this.Connection.ConfigConnection(httpClient);
            return httpClient;
        }

        // get resource path
        // return '' instead of any exception thrown
        public string GetPath<TResource>()
        {
            return this.ResourcePath.GetPath<TResource>();
        }

        public string GetPath(Type resourceType)
        {
            return this.ResourcePath.GetPath(resourceType);
        }
        
        // get resource cache expiration time
        // return 'foolproof' time or '0' instead of any exception thrown 
        public TimeSpan GetExpiration<TResource>() 
        {
            var expSeconds = Math.Max(this.CacheExpiration.GetExpTime<TResource>(), this.FoolProofExpiration);
            return TimeSpan.FromSeconds(expSeconds);
        }

        public TimeSpan GetExpiration(Type resourceType)
        {
            var expSeconds = Math.Max(this.CacheExpiration.GetExpTime(resourceType), this.FoolProofExpiration);
            return TimeSpan.FromSeconds(expSeconds);
        }
                       
    }
}
