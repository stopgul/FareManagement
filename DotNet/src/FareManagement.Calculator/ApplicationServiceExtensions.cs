using FareManagement.Calculator.MeterOperations;
using Microsoft.Extensions.DependencyInjection;

namespace FareManagement.Calculator
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddFareManagementCalculator(this IServiceCollection services)
        {
            services.AddTransient<ICalculatorProvider, FareCalculatorProvider>();

            return services;
        }
    }
}
