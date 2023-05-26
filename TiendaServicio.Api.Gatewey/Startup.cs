using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.Gatewey.ImplementRemote;
using TiendaServicio.Api.Gatewey.InterfacesRemote;
using TiendaServicio.Api.Gatewey.MessageHandler;

namespace TiendaServicio.Api.Gatewey
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
            services.AddHttpClient("AutorService", cofing =>
             {
                 cofing.BaseAddress = new Uri(Configuration["Services:Autor"]);
             });
            services.AddOcelot().AddDelegatingHandler<LibroHandler>();
            services.AddSingleton<IAutorRemote, AutorRemote>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public   void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
             app.UseOcelot().Wait();
        }
    }
}
