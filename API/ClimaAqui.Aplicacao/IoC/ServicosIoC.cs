using Microsoft.Extensions.DependencyInjection;
using ClimaAqui.Aplicacao.Servicos;
using ClimaAqui.Aplicacao.Servicos.Domain;
using ClimaAqui.Dominio.Interfaces.Servicos;
using ClimaAqui.Dominio.Interfaces.Servicos.Domain;

namespace ClimaAqui.Aplicacao.IoC
{
    public static class ServicosIoC
    {
        public static void ServicosAplicacaoIoC(this IServiceCollection services)
        {
            services.AddScoped<IConsultaServico, ConsultaServico>();
        }
    }
}
