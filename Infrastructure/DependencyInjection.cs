using Application.Data;
using Domain.Customer;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure( this  IServiceCollection services,  IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;

        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {



            string mongoConnectionString = configuration.GetConnectionString("MongoDB");

            // Asegúrate de ajustar las opciones de MongoDB según tus necesidades
            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(configuration.GetConnectionString("DB"));

            services.AddSingleton<IMongoClient>(_ => mongoClient);
            services.AddScoped<IMongoDatabase>(_ => mongoDatabase);

            services.AddScoped<IApplicationDBContext, ApplicationDbContext>();
            services.AddScoped<IIdCustomer, IdCustomer>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }



    }
}
