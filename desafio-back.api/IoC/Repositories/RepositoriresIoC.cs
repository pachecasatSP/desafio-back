using desafio_back.domain.Abstractions.Repositories;
using desafio_back.infrastructure.Repositories.Audit;
using desafio_back.web.api.Repositories;


namespace desafio_back.api.IoC.Repositories
{
    public static class RepositoriresIoC
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();
        }
    }
}
