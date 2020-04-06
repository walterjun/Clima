using System.Collections.Generic;

namespace ClimaAqui.Dominio.Entidades
{
    public class List : EntidadeBase
    {
        public int Id { get; set; }
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
    }
}