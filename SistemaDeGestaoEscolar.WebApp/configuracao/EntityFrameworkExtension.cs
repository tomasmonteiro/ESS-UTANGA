using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeGestaoEscolar.Common;
using SistemaDeGestaoEscolar.Data.Mapping;
namespace SistemaDeGestaoEscolar.WebApp
{
    public static class EntityFrameworkExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(AppConfiguration.ConnectionStringTag);

            //conexao principal do entity framework
            services.AddDbContext<ApplicationDbContext>(Options =>
            {
                Options.UseSqlServer(connectionString, op => op.MigrationsAssembly(typeof(BaseEntityMap<>).Assembly.FullName));
            });
            //contexto Identity do entity framework
            services.AddDbContext<ApplicationIdentityDbContext>(Options =>
            {
                Options.UseSqlServer(connectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName));
            });
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}

