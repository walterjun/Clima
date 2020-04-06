using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClimaAqui.Dominio.Interfaces.Infra;
using ClimaAqui.Dominio.Interfaces.Infra.Domain;
using ClimaAqui.Infra.Configuracao.EFCore;
using ClimaAqui.Infra.Repositorios.EFCore;

namespace ClimaAqui.Aplicacao.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicacaoContexto>(options => options.UseMySQL(conn));

            services.AddScoped(typeof(IRepositorioAsync<>), typeof(RepositorioAsync<>));
            services.AddScoped<IConsultaRepositorio, ConsultaRepositorio>();

            return services;
        }
    }
}
