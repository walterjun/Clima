namespace ClimaAqui.Dominio.Entidades
{
    public class City : EntidadeBase
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}