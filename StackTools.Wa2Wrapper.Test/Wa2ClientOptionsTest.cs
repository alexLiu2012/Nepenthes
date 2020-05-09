using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using StackTools.Wa2Wrapper.wa2Resource;


namespace StackTools.Wa2Wrapper.Test
{
    public class Wa2ClientOptionsTest
    {
        public IConfiguration ConfigAllNormal { get; }
        public IConfiguration ConfigWithEmpty { get; }
        public IConfiguration ConfigWithIllegal { get; }
        public IConfiguration ConfigConnectWithEmpty { get; }
        public IConfiguration ConfigConnectWithIllegal { get; }
        public IConfiguration ConfigPathWithEmpty { get; }
        public IConfiguration ConfigPathWithIllegal { get; }
        public IConfiguration ConfigCacheWithEmpty { get; }
        public IConfiguration ConfigCacheWithIllegal { get; }
        public IServiceProvider Services { get; }

        public Wa2ClientOptionsTest()
        {
            ConfigAllNormal = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.test.normal.json"), false, true)
                .Build();            

            ConfigWithEmpty = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.test.empty.json"), false, true)
                .Build();

            ConfigWithIllegal = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.test.illegal.json"), false, true)
                .Build();

            ConfigConnectWithEmpty = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.connect-with-empty-item.json"), false, true)
                .Build();

            ConfigConnectWithIllegal = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.connect-with-illegal-item.json"), false, true)
                .Build();

            ConfigPathWithEmpty = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.path-with-empty-item.json"), false, true)
                .Build();

            ConfigPathWithIllegal = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.path-with-illegal-item.json"), false, true)
                .Build();

            ConfigCacheWithEmpty = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.cache-with-empty-item.json"), false, true)
                .Build();

            ConfigCacheWithIllegal = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "config.cache-with-illegal-item.json"), false, true)
                .Build();

            Services = new ServiceCollection()
                .Configure<Wa2ClientOptions>("allNormal", ConfigAllNormal, binder => binder.BindNonPublicProperties = true)                
                .Configure<Wa2ClientOptions>("withEmpty", ConfigWithEmpty, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("withIllegal", ConfigWithIllegal, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("connectWithEmpty", ConfigConnectWithEmpty, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("connectWithIllegal", ConfigConnectWithIllegal, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("pathWithEmpty", ConfigPathWithEmpty, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("pathWithIllegal", ConfigPathWithIllegal, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("cacheWithEmpty", ConfigCacheWithEmpty, binder => binder.BindNonPublicProperties = true)
                .Configure<Wa2ClientOptions>("cacheWithIllegal", ConfigCacheWithIllegal, binder => binder.BindNonPublicProperties = true)  
                .AddHttpClient()
                .BuildServiceProvider();            
        }

        // basic of client option
        [Fact]
        public void TestBaseOptionNormal()
        {
            var config = this.ConfigAllNormal;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("allNormal");
                                   
            Assert.Equal(config.GetValue<bool>("useMemoryCache"), options.UseMemoryCache);            
            Assert.Equal(config.GetValue<uint>("foolProofExpiration"), options.FoolProofExpiration);
            Assert.Equal(config.GetValue<bool>("useOverridedTimestamp"), options.UseOverridedTimestamp);           
        }

        [Fact]
        public void TestBaseOptionEmpty()
        {
            var config = this.ConfigWithEmpty;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("withEmpty");

            Assert.Equal(config.GetValue<bool>("useMemoryCache"), options.UseMemoryCache);
            Assert.Equal(config.GetValue<uint>("foolProofExpiration"), options.FoolProofExpiration);
            Assert.Equal(config.GetValue<bool>("useOverridedTimestamp"), options.UseOverridedTimestamp);

            /*
             properties will be default as they defined.
             should assign default value for all properties in options             
             */            
        }

        [Fact]
        public void TestBaseOptionIllegal()
        {
            var config = this.ConfigWithIllegal;

            Assert.Throws<InvalidOperationException>(
                () => this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("withIllegal"));    
            
            /*
             loading options will be failure and throw exception if the settings of property are illegal
             a default setting should be load first and any customized settings loaded later
             */
        }

        // connection option
        [Fact]
        public void TestConnectOptNormal()
        {
            var config = this.ConfigAllNormal;            
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("allNormal");
            var httpClientFactory = this.Services.GetService<IHttpClientFactory>();
            var reqClient = options.GetRequestClient(httpClientFactory);

            var connect = config.GetSection("Connection");
            var url = $"{connect.GetValue<string>("Scheme")}://{connect.GetValue<string>("Host")}:{connect.GetValue<uint>("Port")}/";
            var auth = $"{connect.GetValue<string>("Account")}:{connect.GetValue<string>("Password")}";

            Assert.Equal(url, reqClient.BaseAddress.OriginalString);
            Assert.Equal(Convert.ToBase64String(Encoding.UTF8.GetBytes(auth)),
                reqClient.DefaultRequestHeaders.GetValues("Authorization").First().Split(' ')[1]) ;
            Assert.Equal(TimeSpan.FromSeconds(connect.GetValue<uint>("Timeout")), reqClient.Timeout);
            
        }

        [Fact]
        public void TestConnectOptEmpty()
        {

        }

        [Fact]
        public void TestConnectOptIllegal()
        {

        }

        // path option
        [Fact]
        public void TestResourceOptNormal()
        {
            var config = this.ConfigAllNormal;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("allNormal");
            var resource = config.GetSection("ResourcePath");

            Assert.Equal(resource.GetValue<string>("alarms"), options.GetPath<Wa2Alarm>());
            Assert.Equal(resource.GetValue<string>("applications"), options.GetPath<Wa2Application>());
            Assert.Equal(resource.GetValue<string>("batches"), options.GetPath<Wa2Batch>());
            Assert.Equal(resource.GetValue<string>("controllers"), options.GetPath<Wa2Controller>());
            Assert.Equal(resource.GetValue<string>("keyInfos"), options.GetPath<Wa2KeyInfo>());
            Assert.Equal(resource.GetValue<string>("keyValues"), options.GetPath<Wa2KeyValue>());
            Assert.Equal(resource.GetValue<string>("locations"), options.GetPath<Wa2Location>());
            Assert.Equal(resource.GetValue<string>("servers"), options.GetPath<Wa2Server>());
        }

        [Fact]
        public void TestResourceOptEmpty()
        {
            var config = this.ConfigPathWithEmpty;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("pathWithEmpty");
            var resource = config.GetSection("ResourcePath");

            Assert.Equal(resource.GetValue<string>("alarms", string.Empty), options.GetPath<Wa2Alarm>());
            Assert.Equal(resource.GetValue<string>("applications", string.Empty), options.GetPath<Wa2Application>());
            Assert.Equal(resource.GetValue<string>("batches", string.Empty), options.GetPath<Wa2Batch>());
            Assert.Equal(resource.GetValue<string>("controllers", string.Empty), options.GetPath<Wa2Controller>());
            Assert.Equal(resource.GetValue<string>("keyInfos", string.Empty), options.GetPath<Wa2KeyInfo>());
            Assert.Equal(resource.GetValue<string>("keyValues", string.Empty), options.GetPath<Wa2KeyValue>());
            Assert.Equal(resource.GetValue<string>("locations", string.Empty), options.GetPath<Wa2Location>());
            Assert.Equal(resource.GetValue<string>("servers", string.Empty), options.GetPath<Wa2Server>());

            /*
             properties will be in default if they are empty in the configurations
             */
        }

        [Fact]
        public void TestResourceOptIllegal()
        {
            var config = this.ConfigPathWithIllegal;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("pathWithIllegal");
            var resource = config.GetSection("ResourcePath");

            Assert.Equal(resource.GetValue<string>("alarms"), options.GetPath<Wa2Alarm>());
            Assert.Equal(resource.GetValue<string>("applications"), options.GetPath<Wa2Application>());
            Assert.Equal(resource.GetValue<string>("batches"), options.GetPath<Wa2Batch>());
            Assert.Equal(resource.GetValue<string>("controllers"), options.GetPath<Wa2Controller>());
            Assert.Equal(resource.GetValue<string>("keyInfos"), options.GetPath<Wa2KeyInfo>());
            Assert.Equal(resource.GetValue<string>("keyValues"), options.GetPath<Wa2KeyValue>());
            Assert.Equal(resource.GetValue<string>("locations"), options.GetPath<Wa2Location>());
            Assert.Equal(resource.GetValue<string>("servers"), options.GetPath<Wa2Server>());

            /*
             config will load all parameters as string 
             so there will not be any exceptions to match such parameter to properties with type 'string'
             considerto add 'data annotation'
             */
        }

        // cache option
        [Fact]
        public void TestExpirationOptNormal()
        {
            var config = this.ConfigAllNormal;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("allNormal");
            var expiration = config.GetSection("CacheExpiration");

            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("alarms")), options.GetExpiration<Wa2Alarm>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("applications")), options.GetExpiration<Wa2Application>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("batches")), options.GetExpiration<Wa2Batch>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("controllers")), options.GetExpiration<Wa2Controller>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("keyInfos")), options.GetExpiration<Wa2KeyInfo>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("keyValues")), options.GetExpiration<Wa2KeyValue>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("keyValuesHistory")), options.GetExpiration<Wa2KeyValueHistory>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("locations")), options.GetExpiration<Wa2Location>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("servers")), options.GetExpiration<Wa2Server>());
        }

        [Fact]
        public void TestExpirationOptEmpty()
        {
            var config = this.ConfigCacheWithEmpty;
            var options = this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("cacheWithEmpty");
            var expiration = config.GetSection("CacheExpiration");
            var expDefault = config.GetValue<uint>("foolProofExpiration");

            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("alarms", expDefault)), options.GetExpiration<Wa2Alarm>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("applications", expDefault)), options.GetExpiration<Wa2Application>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("batches", expDefault)), options.GetExpiration<Wa2Batch>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("controllers", expDefault)), options.GetExpiration<Wa2Controller>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("keyInfos", expDefault)), options.GetExpiration<Wa2KeyInfo>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("keyValues", expDefault)), options.GetExpiration<Wa2KeyValue>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("keyValuesHistory", expDefault)), options.GetExpiration<Wa2KeyValueHistory>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("locations", expDefault)), options.GetExpiration<Wa2Location>());
            Assert.Equal(TimeSpan.FromSeconds(expiration.GetValue<uint>("servers", expDefault)), options.GetExpiration<Wa2Server>());

            /*
             properties will be default if there is nothing loaded from configuration
             default is actually 'foolProof' value
             */
        }

        [Fact]
        public void TestExpirationOptIllegal()
        {
            var config = this.ConfigCacheWithEmpty;
            Assert.Throws<InvalidOperationException>(() => 
            this.Services.GetService<IOptionsFactory<Wa2ClientOptions>>().Create("cacheWithIllegal"));                        
        }
        
    }
}
