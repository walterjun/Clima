using ClimaAqui.Dominio.Entidades;
using ClimaAqui.Dominio.Interfaces.Infra.Domain;
using ClimaAqui.Infra.Configuracao.EFCore;

namespace ClimaAqui.Infra.Repositorios.EFCore
{
    public class ConsultaRepositorio : RepositorioAsync<Consulta>, IConsultaRepositorio
    {
        public ConsultaRepositorio(AplicacaoContexto contexto): base(contexto)
        {

        }
    }
}
