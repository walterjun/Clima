using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Xunit;
using ClimaAqui.Dominio.Interfaces.Infra.Domain;
using ClimaAqui.Infra.Configuracao.EFCore;
using ClimaAqui.Infra.Repositorios.EFCore;
using ClimaAqui.Testes.ConfiguracaoDB.EFCore;
using ClimaAqui.Testes.DataBuilder;

namespace ClimaAqui.Testes
{
    public class ConsultaTeste : IClassFixture<EntityConexao>, IDisposable
    {
        private AplicacaoContexto dbContext;
        private ConsultaBuilder builder;
        private IConsultaRepositorio userEntityFramework;

        public ConsultaTeste(EntityConexao entityConexao)
        {
            dbContext = entityConexao.DataBaseConfiguration();
            userEntityFramework = new ConsultaRepositorio(dbContext);
            this.builder = new ConsultaBuilder();
        }

        [Fact]
        public async Task AddAsync()
        {
            var result = await userEntityFramework.Add(builder.CriarConsulta());
            Assert.True(result.Id > 0);
        }

        public void Dispose()
        {
            // Banco de dados InMemory não usa transação
            //transaction.Rollback();
        }
    }
}
