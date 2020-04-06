using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimaAqui.API.Models
{
    public class Temperatura
    {
        public string dt { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
    }
}
