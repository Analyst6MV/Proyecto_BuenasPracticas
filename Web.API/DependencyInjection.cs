using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web.API.Middlewares;

namespace Web.API;

public static class DependencyInjection
{


    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {



        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
        return services;
    }
}