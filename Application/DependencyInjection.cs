
using Application.Behaver;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection  AddApplication (this  IServiceCollection services)
        {


            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
            services.AddScoped(
                    typeof(IPipelineBehavior<,>),
                    typeof(ValidationBehavior<,>)
                );


            return services;
        }
    }
}
