using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace StackTools.Wa2Wrapper.wa2Configs
{
    public class Wa2ConnectOptions
    {
        private string Scheme { get; set; }
        private string Host { get; set; }
        private uint Port { get; set; }
        private string Account { get; set; }
        private string Password { get; set; }        
        private uint Timeout { get; set; }        
        public List<string> AdditionalHeaders { get; set; }

        public Wa2ConnectOptions()
        {
            this.Scheme = string.Empty;
            this.Host = string.Empty;           
            this.Account = string.Empty;
            this.Password = string.Empty;
            this.AdditionalHeaders = new List<string>();
        }

        // config httpClient with loaded parameters
        public void ConfigConnection(HttpClient aClient)
        {
            ConfigBaseAddress(aClient);
            ConfigAuthentication(aClient);
            ConfigRequestTimeout(aClient);
            ConfigAdditionalHeaders(aClient);
        }
        

        private void ConfigBaseAddress(HttpClient aClient)
        {
            aClient.BaseAddress = new Uri($"{this.Scheme}://{this.Host}:{this.Port}/");            
        }
            
        private void ConfigAuthentication(HttpClient aClient)
        {
            var parameter = Encoding.UTF8.GetBytes($"{this.Account}:{this.Password}");
            aClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(parameter));           
        }

        private void ConfigRequestTimeout(HttpClient aClient)
        {
            aClient.Timeout = TimeSpan.FromSeconds(this.Timeout);            
        }
                        
        private void ConfigAdditionalHeaders(HttpClient aClient)
        {
            var headers = this.GetHeadersDictionary();

            foreach (var header in headers)
            {
                aClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }            
        }
        
        private Dictionary<string,string> GetHeadersDictionary()
        {
            var headersDictionary = new Dictionary<string, string>();

            foreach (var header in this.AdditionalHeaders)
            {
                try
                {
                    var headerKey = header.Split(':')[0].Trim();
                    var headerValue = header.Split(':')[1].Trim();
                    headersDictionary.TryAdd(headerKey, headerValue);
                }
                catch(Exception ex)
                {
                }
            }

            return headersDictionary;
        }
           
    }
}
