using ClimaAqui.Dominio.Entidades;

namespace ClimaAqui.Testes.DataBuilder
{
    public class ConsultaBuilder
    {
        private Consulta consulta;

        public Consulta CriarConsulta()
        {
            this.consulta = new Consulta()
            {
                cnt = 2,
                cod = "3",
                message = 0
            };
            return this.consulta;
        }
    }
}
