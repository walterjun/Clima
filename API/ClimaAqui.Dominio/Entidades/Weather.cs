namespace ClimaAqui.Dominio.Entidades
{
    public class Weather : EntidadeBase
    {
        public int Id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}