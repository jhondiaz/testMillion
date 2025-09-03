using Microsoft.Extensions.DependencyInjection;
using TestMillion.Presenters.LogIn;
using TestMillion.Presenters.Owner;
using TestMillion.Presenters.Properties;
using TestMillion.Presenters.PropertyImages;
using TestMillion.UseCasesPorts.LogInPorts;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;
using TestMillion.UseCasesPorts.OwnerPorts;
using TestMillion.UseCasesPorts.PropertiesPorts;
using TestMillion.UseCasesPorts.PropertyImagesPorts;

namespace TestMillion.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {

            services.AddScoped<ICreatePropertyImageOutputPort, CreatePropertyImagePresenter>();
            services.AddScoped<ICreatePropertyOutputPort, CreatePropertyPresenter>();
          
            services.AddScoped<IGetPropertiesOutputPort, GetPropertiesPresenter>();
            services.AddScoped<IGetPropertyImagesOutputPort, GetPropertyImagesPresenter>();
            services.AddScoped<IUpdatePropertyOutputPort, UpdatePropertyPresenter>();
            services.AddScoped<IGetPropertyOutputPort, GetPropertyPresenter>();

            services.AddScoped<ICreateOwnerOutputPort, CreateOwnerPresenter>();
            services.AddScoped<IGetOwnersOutputPort, GetOwnersPresenter>();

            services.AddScoped<IGetLogInOutputPort, GetLogInPresenter>();


            return services;
        }
    }
}
