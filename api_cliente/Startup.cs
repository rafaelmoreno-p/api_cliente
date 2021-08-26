using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_cliente
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _hostingEnvironment;

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            var builder = new ConfigurationBuilder()
               .SetBasePath(hostingEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API CLIENTE",
                    Version = "V1"
                });

                /*
                //Comentario de Servicio
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                string vl_FileXML = string.Format(@"{0}\VIVIENDA.NETC.APIMasterData.Domain.xml", System.AppDomain.CurrentDomain.BaseDirectory);

                if (!System.IO.File.Exists(vl_FileXML))
                {
                    vl_FileXML = string.Format(@"{0}bin\VIVIENDA.NETC.APIMasterData.Domain.xml", System.AppDomain.CurrentDomain.BaseDirectory);
                }

                //Comentario de domain
                c.IncludeXmlComments(vl_FileXML, true);

                */

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            try
            {
                app.UseSwaggerUI(c =>
                {
                    if (env.IsDevelopment())
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API PEDIDOS");

                    }
                    else
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API PEDIDOS");
                    }

                    c.RoutePrefix = string.Empty;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
