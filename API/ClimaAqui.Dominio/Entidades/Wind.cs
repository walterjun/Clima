namespace ClimaAqui.Dominio.Entidades
{
    public class Wind : EntidadeBase
    {
        public int Id { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
    }
}