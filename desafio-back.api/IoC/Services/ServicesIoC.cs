using desafio_back.api.Services;
using desafio_back.domain.Abstractions.Services;

namespace desafio_back.api.IoC.Services
{
    public static class ServicesIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMotorcycleService, MotorcycleService>();
        }
    }
}
