using System;
using System.Collections.Generic;
using System.Text;

namespace ClimaAqui.Dominio.Entidades
{
    public class Consulta : EntidadeBase
    {
        public int Id { get; set; }
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }
}
