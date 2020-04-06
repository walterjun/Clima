using Microsoft.Extensions.Configuration;
using ClimaAqui.Infra.Configuracao;

namespace ClimaAqui.Aplicacao.IoC.ORMs
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? ConexaoBanco.ConnectionConfiguration;
        }
    }
}
