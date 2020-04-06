using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClimaAqui.Dominio.Entidades;

namespace ClimaAqui.Infra.Configuracao.EFCore
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseMySQL(ConexaoBanco.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options) : base(options)
        {
        }

        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Clouds> Clouds { get; set; }
        public DbSet<Coord> Coord { get; set; }
        public DbSet<List> List { get; set; }
        public DbSet<Main> Main { get; set; }
        public DbSet<Rain> Rain { get; set; }
        public DbSet<Sys> Sys { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Wind> Wind { get; set; }

    }
}