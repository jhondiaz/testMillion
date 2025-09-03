using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TestMillion.UseCases.CreateOwner;
using TestMillion.UseCases.CreateProperty;
using TestMillion.UseCases.CreatePropertyImage;
using TestMillion.UseCases.GetLogIn;
using TestMillion.UseCases.GetOwners;
using TestMillion.UseCases.GetProperties;
using TestMillion.UseCases.GetProperty;
using TestMillion.UseCases.GetPropertyImages;
using TestMillion.UseCases.Mappings;
using TestMillion.UseCases.UpdateProperty;
using TestMillion.UseCasesPorts.LogInPorts;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;
using TestMillion.UseCasesPorts.OwnerPorts;
using TestMillion.UseCasesPorts.PropertiesPorts;
using TestMillion.UseCasesPorts.PropertyImagesPorts;


namespace TestMillion.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {

     
            services.AddTransient<ICreatePropertyInputPort, CreatePropertyInteractor>();
            services.AddTransient<IUpdatePropertyInputPort, UpdatePropertyInteractor>();
            services.AddTransient<IGetPropertiesInputPort, GetPropertiesInteractor>();
         
            services.AddTransient<IGetPropertyInputPort, GetPropertyInteractor>();
            services.AddTransient<ICreatePropertyImageInputPort, CreatePropertyImageInteractor>();
            services.AddTransient<IGetPropertyImagesInputPort, GetPropertyImagesInteractor>();

            services.AddTransient<ICreateOwnerInputPort, CreateOwnerInteractor>();
            services.AddTransient<IGetOwnersInputPort, GetOwnersInteractor>();

            services.AddTransient<IGetLogInInputPort, GetLogInInteractor>();


            return services;
        }
    }
}
