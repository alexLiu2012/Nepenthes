using System;
using System.Globalization;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using StackTools.Nepenthes.GraphQL.GraphQL;
using StackTools.Nepenthes.GraphQL.GraphTypes;
using StackTools.Wa2Wrapper;

namespace StackTools.Nepenthes.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            
            services.AddHttpClient();
            services.AddMemoryCache();

            // register services for web access client
            services.Configure<Wa2ClientOptions>(Configuration, binder => binder.BindNonPublicProperties = true);
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<Wa2ClientOptions>>().Value);
            services.AddScoped<Wa2Client>();

            // register alias dictionary
            services.Configure<TypeFieldAlias>(Configuration);
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<TypeFieldAlias>>().Value);

            // register datetime format            
            services.AddScoped<DateTimeFormatInfo>(sp => new DateTimeFormatInfo()
            {                
                FullDateTimePattern = Configuration.GetValue<string>("dateTimeFormat") ?? "yyyy-MM-dd hh:mm:ss"
            }) ;

            // register graphql types
            services.AddScoped<GraphAlarm>();            
            services.AddScoped<GraphApplication>();
            services.AddScoped<GraphBatch>();            
            services.AddScoped<GraphController>();            
            /* services.AddScoped<GraphKeyInfo>(); */
            services.AddScoped<GraphKeyValue>();            
            services.AddScoped<GraphLocation>();
            services.AddScoped<TypeFieldAliasHelper>();

            // graph query args
            services.AddScoped<AlarmFieldArguments>();
            services.AddScoped<ApplicationFieldArguments>();
            services.AddScoped<BatchFieldArguments>();
            services.AddScoped<ControllerFieldArguments>();
            services.AddScoped<KeyInfoFieldArguments>();
            services.AddScoped<KeyValueFieldArguments>();
            services.AddScoped<LocationFieldArguments>();

            // register graphql queries
            services.AddScoped<Wa2Query>();
            services.AddScoped<CustomQuery>();

            // register graphql schema
            services.AddScoped<Wa2Schema>();

            var a = Configuration.GetValue<bool>("ignoreNullValues");
            // register graphql services            
            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = false;
                options.EnableMetrics = false;
            })
                .AddSystemTextJson(opt => opt.IgnoreNullValues = Configuration.GetValue<bool>("ignoreNullValues"));                      
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            */

            app.UseGraphQL<Wa2Schema>("/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
            {
                //Path = "/graphql/playground",
                //GraphQLEndPoint = "/graphql"
            });
        }
    }
}
