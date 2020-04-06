using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClimaAqui.Aplicacao.IoC.ORMs
{
    public interface IOrmTypes
    {
        IServiceCollection ResolveOrm(IServiceCollection services, IConfiguration configuration = null);
    }
}
