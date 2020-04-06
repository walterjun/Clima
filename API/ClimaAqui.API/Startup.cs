using AutoMapper;
using ClimaAqui.Aplicacao.IoC;
using ClimaAqui.Aplicacao.IoC.ORMs;
using ClimaAqui.Aplicacao.IoC.ORMs.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace ClimaAqui.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ClimaAqui",
                        Version = "v1",
                        Description = "API de de condições climáticas",
                        Contact = new OpenApiContact
                        {
                            Name = "Walter Junior",
                            Url = new Uri("https://github.com/walterjun")
                        }
                    });

                c.ResolveConflictingActions(x => x.First());
            });
            services.AddSingleton<IConfiguration>(Configuration);
            //Injeção de dependência da camada de servico
            services.ServicosAplicacaoIoC();
            // Inicialmente iria injetar outra ORM mas não deu tempo
            services.InfrastructureORM<EntityFrameworkIoC>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Evitar o problema de CORS pra debugg. Nunca usar assim em produção. Código apenas para teste ;D
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClimaAqui");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();

            
        }
    }
}
