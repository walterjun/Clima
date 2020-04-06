using AutoMapper;
using ClimaAqui.API.Models;
using ClimaAqui.Dominio.Entidades;
using ClimaAqui.Dominio.Interfaces.Servicos.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClimaAqui.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private IConsultaServico servico;
        private readonly IMapper mapper;
        private IConfiguration Configuration;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="_servico">Serviço para acesso aos dados</param>
        /// <param name="_mapper">AutoMapper</param>
        /// <param name="_Configuration">Configuration para busca da strig dentro do appsettings</param>
        public PesquisaController(IConsultaServico _servico, IMapper _mapper, IConfiguration _Configuration)
        {
            this.servico = _servico;
            this.mapper = _mapper;
            this.Configuration = _Configuration;
        }
        /// <summary>
        /// Método que busca as informações solicitadas pelo Front-end e salva as consultas no banco de dados MySQL
        /// </summary>
        /// <param name="cidade">Nome da cidade de pesquisa</param>
        /// <returns>Retorna as temperaturas mínima e máxima dos próximos 5 dias</returns>
        [HttpGet]
        public async Task<ActionResult<List<Temperatura>>> GetAsync(string cidade)
        {
            List<Temperatura> temperaturas = new List<Temperatura>();

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(string.Format(this.Configuration.GetSection("API").Value, cidade));
                var consulta = JsonSerializer.Deserialize<Consulta>(await response.Result.Content.ReadAsStringAsync());
                
                foreach (var item in consulta.list)
                {
                    temperaturas.Add(mapper.Map<Temperatura>(item));
                }

                await servico.AddAsync(consulta);

                return temperaturas;
            }
        }
    }
}