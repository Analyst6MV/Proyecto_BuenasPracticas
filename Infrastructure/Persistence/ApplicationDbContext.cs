

using Application.Data;
using Domain.Customer;
using Domain.Primitive;
using MongoDB.Driver;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IApplicationDBContext
    {
        private readonly IPublisher _publisher;
        private readonly IMongoDatabase _database;
        public ApplicationDbContext(IMongoDatabase database, IPublisher publisher)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }


        IMongoCollection<CustomerPersona> IApplicationDBContext.Customer { get; set; }
        public IMongoCollection<CustomerPersona> Customer => _database.GetCollection<CustomerPersona>("Usuarios");


  


    }

      
}
