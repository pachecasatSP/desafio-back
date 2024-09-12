using desafio_back.domain.Abstractions.Repositories;
using desafio_back.infrastructure.Repositories;
using desafio_back.infrastructure.Repositories.Audit;

namespace desafio_back.api.IoC.Repositories
{
    public static class RepositoriresIoC
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();
            services.AddScoped<IRentalPlanRepository, RentalPlanRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
        }
    }
}
