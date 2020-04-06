using AutoMapper;
using ClimaAqui.API.Models;
using ClimaAqui.Dominio.Entidades;

namespace ClimaAqui.API.Mapeamentos
{
    public class MapeamentoProfile : Profile
    {
        public MapeamentoProfile()
        {
            CreateMap<List, Temperatura>().
                ForMember(x => x.temp_max, map => map.MapFrom(from => from.main.temp_max)).
                ForMember(x => x.temp_min, map => map.MapFrom(from => from.main.temp_min)).
                ForMember(x => x.dt, map => map.MapFrom(from => from.dt_txt));
            
        }
    }
}
