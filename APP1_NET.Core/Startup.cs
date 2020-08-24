using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP1_NET.Core.Infraestructure; //CatalogoDbContext
using APP1_NET.Core.Mapper;
using APP1_NET.Core.Repository;
using APP1_NET.Core.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;             // Se agrego la líbrera por: UseSqlServer
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APP1_NET.Core
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
            //Paquete Automapper
            services.AddAutoMapper(typeof(CategoriaMapper));
            //Referencia
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            // Se especifica que conexión se utilizará y que contexto en nuestra aplicación.
            services.AddDbContext<CatalogoDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Controladores
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
