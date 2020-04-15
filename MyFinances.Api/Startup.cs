using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFinances.CrossCutting.IoC;
using MyFinances.Infra.IoC;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace MyFinances.Api
{
    public class Startup
    {
        public readonly IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();



            this._configurationRoot = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(this._configurationRoot);
            services.AdicionaConfiguracoes();
            services.AddInfraIoC();
            services.AddMediatR(AppDomain.CurrentDomain.Load("MyFinances.Domain"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    (resolver as DefaultContractResolver).NamingStrategy = null;
                }
            });

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "MyFinances - Api",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Leonardo Pianta",
                        Url = "https://github.com/leopianta"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFinances");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:44395").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.UseMvc();
            //app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());





        }

    }
}
