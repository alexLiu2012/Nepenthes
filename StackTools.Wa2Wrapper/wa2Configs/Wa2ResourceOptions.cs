using System;
using System.Collections.Generic;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Wa2Wrapper.wa2Configs
{
    public class Wa2ResourceOptions
    {
        private string Alarms { get; set; }
        private string Applications { get; set; }
        private string Batches { get; set; }
        private string Controllers { get; set; }
        private string KeyInfos { get; set; }
        private string KeyValues { get; set; }        
        private string Locations { get; set; }
        private string Servers { get; set; }

        public Wa2ResourceOptions()
        {
            this.Alarms = string.Empty;
            this.Applications = string.Empty;
            this.Batches = string.Empty;
            this.Controllers = string.Empty;
            this.KeyInfos = string.Empty;
            this.KeyValues = string.Empty;
            this.Locations = string.Empty;
            this.Servers = string.Empty;
        }
                        
        // retrieve resource path by the generic type of resource
        public string GetPath<TResource>()
        {
            var paths = GetPathsDictionary();
            return paths.GetValueOrDefault(typeof(TResource).Name);
        }

        // retrieve resource path by the type of resource itself
        public string GetPath(Type resourceType)
        {
            var paths = GetPathsDictionary();
            return paths.GetValueOrDefault(resourceType.Name);
        }


        // a dynamic map for refactor purpose 
        private Dictionary<string,string> GetPathsDictionary()
        {
            // mapping input data to Resource Define Class
            var paths = new Dictionary<string, string>()
            {
                #region 
                {
                    typeof(Wa2Alarm).Name,
                    this.Alarms
                },
                {
                    typeof(Wa2Application).Name,
                    this.Applications
                },
                {
                    typeof(Wa2Batch).Name,
                    this.Batches
                },
                {
                    typeof(Wa2Controller).Name,
                    this.Controllers
                },
                {
                    typeof(Wa2KeyInfo).Name,
                    this.KeyInfos
                },
                {
                    typeof(Wa2KeyValue).Name,
                    this.KeyValues
                },                
                {
                    typeof(Wa2Location).Name,
                    this.Locations
                },
                {
                    typeof(Wa2Server).Name,
                    this.Servers
                }
                #endregion
            };            

            return paths;
        }
    }
}
