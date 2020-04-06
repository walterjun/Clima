using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ClimaAqui.Infra.Configuracao.EFCore;

namespace ClimaAqui.Testes.ConfiguracaoDB.EFCore
{
    public class EntityConexao
    {
        private IServiceProvider _provider;

        public AplicacaoContexto DataBaseConfiguration()
        {
            var services = new ServiceCollection();
            services.AddDbContext<AplicacaoContexto>(options => options.UseInMemoryDatabase(databaseName: "ClimaAqui"));
            _provider = services.BuildServiceProvider();
            return _provider.GetService<AplicacaoContexto>();
        }
    }
}
