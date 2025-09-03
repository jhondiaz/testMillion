using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMillion.Presenters;
using TestMillion.Repository;
using TestMillion.UseCases;

namespace TestMillion.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddTestMillionDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices();
            services.AddPresenters();
         
            return services;
        }
    }

}
