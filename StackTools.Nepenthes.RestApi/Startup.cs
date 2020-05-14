using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using AutoMapper;
using StackTools.Wa2Wrapper;
using StackTools.Nepenthes.RestApi.Services;

namespace StackTools.Nepenthes.RestApi
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
            services.AddControllers()
                .AddJsonOptions(cfg =>
                {
                    cfg.JsonSerializerOptions.IgnoreNullValues = Configuration.GetValue("ignoreNullableValues", false);                    
                });

            services.AddHttpClient();
            services.AddMemoryCache();

            services.Configure<Wa2ClientOptions>(Configuration, binder => binder.BindNonPublicProperties = true);
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<Wa2ClientOptions>>().Value);
            services.AddScoped<Wa2Client>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<MappingHelper>();
            services.AddScoped<ResourceHelper>();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("wa2api", new OpenApiInfo()
                {
                    Title = "Web Access API",                    
                    Version = "2",
                });

                // including comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                setup.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseSwagger(setup =>
            {
                setup.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(setup =>
            {
                setup.RoutePrefix = string.Empty;
                setup.SwaggerEndpoint("/swagger/wa2api/swagger.json", "WebAccess API for Common");
                //setup.SwaggerEndpoint("/swagger/xxx-Title/swagger.json", "Another"); // for other extensions
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
