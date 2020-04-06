using ClimaAqui.Dominio.Entidades;
using ClimaAqui.Dominio.Interfaces.Infra.Domain;
using ClimaAqui.Dominio.Interfaces.Servicos.Domain;

namespace ClimaAqui.Aplicacao.Servicos.Domain
{
    class ConsultaServico : ServicoBase<Consulta>, IConsultaServico
    {
        private readonly IConsultaRepositorio _repository;

        public ConsultaServico(IConsultaRepositorio repository) : base(repository)
        {
            _repository = repository;
        }
    }
}