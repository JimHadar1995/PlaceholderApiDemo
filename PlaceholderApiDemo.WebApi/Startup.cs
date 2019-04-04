using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;
using PlaceholderApiDemo.Library.Repositories.Abstract;
using PlaceholderApiDemo.Library.Repositories.Concrete;
using PlaceholderApiDemo.Library.Services;
using PlaceholderApiDemo.WebApi.App_Code;
using Swashbuckle.AspNetCore.Swagger;

namespace PlaceholderApiDemo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //https://stackoverflow.com/questions/38316358/why-wont-my-asp-net-core-web-api-controller-return-xml
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => { options.RespectBrowserAcceptHeader = true; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddXmlSerializerFormatters()
                .AddXmlDataContractSeria‌​lizerFormatters();
            services.AddSingleton<ILogService, NLogLoggerService>();
            services.AddHttpClient();
            services.AddScoped<ApiQueryService>(s => {
                var clientFactory = s.GetService<IHttpClientFactory>();
                var logService = s.GetService<ILogService>();
                return new ApiQueryService(logService, clientFactory.CreateClient());
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "PlaceholderApiDemo", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaceholderApiDemo");
            });

            app.UseMvc();
        }
    }
}
