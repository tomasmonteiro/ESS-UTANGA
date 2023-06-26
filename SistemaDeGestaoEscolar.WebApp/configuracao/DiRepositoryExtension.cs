using Microsoft.Extensions.DependencyInjection;
using SistemaDeGestaoEscolar.Repository.Concrete;
using SistemaDeGestaoEscolar.Repository.Interface;

namespace SistemaDeGestaoEscolar.WebApp
{
    public static class DiRepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IRepAluno, RepAluno>();
        }
    }
}

