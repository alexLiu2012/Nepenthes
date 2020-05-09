using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.Net;
using StackTools.Wa2Wrapper.wa2Resource;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace StackTools.Wa2Wrapper.Test
{
    public class Wa2ClientTest
    {
        public HttpListener Wa2TestListener { get; set; }

        public List<Wa2Alarm> DummyAlarms { get; set; }
        public List<Wa2Application> DummyApplications { get; set; }
        public List<Wa2Batch> DummyBatches { get; set; }
        public List<Wa2Controller> DummyControllers { get; set; }
        public List<Wa2KeyInfo> DummyKeyInfos { get; set; }
        public List<Wa2KeyValue> DummyKeyValules { get; set; }
        public List<Wa2Location> DummyLocations { get; set; }
        public List<Wa2Server> DummyServers { get; set; }
       
        public Wa2Client Client { get; set; }

        public Wa2ClientTest()
        {
            this.Wa2TestListener = new HttpListener()
            {
                //AuthenticationSchemes = AuthenticationSchemes.Basic
            };

            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/alarms/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/applications/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/batches/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/controllers/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/keyinfos/locations/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/keyvalues/locations/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/locations/");
            this.Wa2TestListener.Prefixes.Add("http://localhost:8080/wa/2/servers/");
            
            this.Wa2TestListener.Start();

            var configNormal = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.dummy-normal.json", false, true).Build();

            var sp = new ServiceCollection()
                .Configure<Wa2ClientOptions>(configNormal, binder => binder.BindNonPublicProperties = true)
                .AddScoped(cfg => cfg.GetService<IOptionsSnapshot<Wa2ClientOptions>>().Value)
                .AddHttpClient()
                .AddMemoryCache()
                .AddScoped<Wa2Client>()
                .BuildServiceProvider();

            this.Client = sp.GetService<Wa2Client>();
        }

        

        [Fact]
        public void TestGetNormal()
        {
            var alarmsObj = new List<Wa2Alarm>()
            {
                new Wa2Alarm()
                {
                     AcknowledgedBy="hh"
                },
                new Wa2Alarm()
                {

                }
            };

            var alarmsStr = new List<string>();

            foreach (var item in alarmsObj)
            {
                alarmsStr.Add(JsonSerializer.Serialize<Wa2Alarm>(item, new JsonSerializerOptions() { WriteIndented = true }));
            }

            var tt = new Task(() => this.GettingContext());
            tt.Start();
            var client = new HttpClient();
            //Console.ReadLine();
            var r = client.GetStringAsync("http://localhost:8080/wa/2/alamrs").Result;            
            
        }

        private void GettingContext()
        {
            var result = this.Wa2TestListener.BeginGetContext(Reply, Wa2TestListener);
            result.AsyncWaitHandle.WaitOne();
        }

        private void Reply(IAsyncResult result)
        {
            var listener = (HttpListener)result.AsyncState;

            var context = this.Wa2TestListener.EndGetContext(result);

            switch(context.Request.Url.AbsoluteUri)
            {
                case "1":
                    break;
                default:
                    break;
            }

        }

        
    }
}
