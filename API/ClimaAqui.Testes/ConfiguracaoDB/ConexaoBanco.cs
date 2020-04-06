using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClimaAqui.Testes.ConfiguracaoDB
{
    public class ConexaoBanco
    {
        public static IOptions<OptionFactory> ConnectionConfiguration
        {
            get
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder().AddInMemoryCollection()
                    .AddJsonFile("appsettings.test.json")
                    .Build();
                return Options.Create(Configuration.GetSection("ConnectionStrings").Get<OptionFactory>());
            }
        }
    }
}
