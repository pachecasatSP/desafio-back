using desafio_back.domain.Rules;
using desafio_back.domain.Specifications;

namespace desafio_back.api.IoC.Rules
{
    public static class RuleIoC
    {
        public static void RegisterRules(this IServiceCollection services)
        {
            services.AddSingleton(new Is2024MotorcycleRule(new Motorcycle2024Specification()));
        }
    }
}
