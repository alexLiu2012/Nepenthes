using System;
using System.Collections.Generic;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Wa2Wrapper.wa2Configs
{
    public class Wa2CacheOptions
    {
        private uint Alarms { get; set; }
        private uint Applications { get; set; }
        private uint Batches { get; set; }
        private uint Controllers { get; set; }
        private uint KeyInfos { get; set; }
        private uint KeyValues { get; set; }
        private uint KeyValuesHistory { get; set; }
        private uint Locations { get; set; }
        private uint Servers { get; set; }
        
        public Wa2CacheOptions()
        {
            // scalar type has it's default as the type defined
        }

        // retrive cache expiration time in seconds by the generic type of resource
        public uint GetExpTime<TResource>()
        {
            var expirations = GetExpirationDictionary();
            return expirations.GetValueOrDefault(typeof(TResource).Name);
        }

        // retrieve cache expiration time in seconds by the type of resource iteself
        public uint GetExpTime(Type resourceType)
        {
            var expirations = GetExpirationDictionary();
            return expirations.GetValueOrDefault(resourceType.Name);
        }


        // a dynamic map for refactor purpose
        private Dictionary<string, uint> GetExpirationDictionary()
        {
            var expirations = new Dictionary<string, uint>()
            {
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
                    typeof(Wa2KeyValueHistory).Name,
                    this.KeyValuesHistory
                },
                {
                    typeof(Wa2Location).Name,
                    this.Locations
                },
                {
                    typeof(Wa2Server).Name,
                    this.Servers
                }
            };

            return expirations;
        }
    }
}
