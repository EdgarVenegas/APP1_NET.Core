using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using APP1_NET.Core.Infraestructure; //CatalogoDbContext
using APP1_NET.Core.Mapper;
using APP1_NET.Core.Repository;
using APP1_NET.Core.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;             // Se agrego la líbrera por: UseSqlServer
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace APP1_NET.Core
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autenticar la identificación del API
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:TokenKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            //Configurar: Documentación Swagger
            services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("CatalogosAPI", new Microsoft.OpenApi.Models.OpenApiInfo()
                //{
                //    Title = "Catalogos Generales API",
                //    Description = "Contiene los catalogos genericos de aplicaciones",
                //    Version = "1.0",
                //    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                //    {
                //        Email = "soluciones@axsistec.com",
                //        Name = "Soporte Técnico a Desarrollos",
                //        Url = new Uri("http://www.axsistec.com/web/Index.html")
                //    },
                //    License = new Microsoft.OpenApi.Models.OpenApiLicense
                //    {
                //        Name = "BSD",
                //        Url = new Uri("https://bsd.axsistec.com")
                //    }
                //});

                options.SwaggerDoc("CatalogosCategoriasAPI", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Catalogos Generales API",
                    Description = "Contiene los catalogos genericos de aplicaciones",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "soluciones@axsistec.com",
                        Name = "Soporte Técnico a Desarrollos",
                        Url = new Uri("http://www.axsistec.com/web/Index.html")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }
                });

                options.SwaggerDoc("APIUsuariosCatalogo", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Catalogos Generales API",
                    Description = "Contiene los catalogos genericos de aplicaciones",
                    Version = "1.0",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "soluciones@axsistec.com",
                        Name = "Soporte Técnico a Desarrollos",
                        Url = new Uri("http://www.axsistec.com/web/Index.html")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "BSD",
                        Url = new Uri("https://bsd.axsistec.com")
                    }
                });

                //Ruta de Archivo XML
                var XMLComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var APIRutaComentarios = Path.Combine(AppContext.BaseDirectory, XMLComentarios);
                options.IncludeXmlComments(APIRutaComentarios);

                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authentication",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });

            });
            //Cors
               // services.AddCors(options =>
               //{
               //    options.AddPolicy(name: MyAllowSpecificOrigins,
               //        builder =>
               //        {
               //            builder.WithOrigins("http://google.com",
               //                                "http://facebook.com");
               //        });
               //});
            //Paquete Automapper
            services.AddAutoMapper(typeof(UsuarioMapper));
            services.AddAutoMapper(typeof(CategoriaMapper));
            //Referencia
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
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

            //Inicializar Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint("/swagger/CatalogosAPI/swagger.json", "API Catalogos");
                options.SwaggerEndpoint("/swagger/CatalogosCategoriasAPI/swagger.json", "Catalogos Generales API");
                options.SwaggerEndpoint("/swagger/APIUsuariosCatalogo/swagger.json", "API Usuarios Catalogo");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //CORS
            //Para cuando la API requiere consumir información desde diferentes sitios. 
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseCors(MyAllowSpecificOrigins);
        }   
    }
}
