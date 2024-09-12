using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Services;

namespace desafio_back.api.IoC.Services
{
    public static class ServicesIoC
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMotorcycleService, MotorcycleService>();
            services.AddScoped<IDeliverymanService, DeliverymanService>();
            services.AddScoped<IRentalPlanService, RentalPlanService>();
            services.AddScoped<IRentalService, RentalService>();
        }
    }
}
