using Domain.Customer;
using MongoDB.Driver;

namespace Application.Data
{
    public interface IApplicationDBContext
    {
        
        //DbSet<Customer> Customer {  get; set; }
        IMongoCollection<Customer> Customer { get; set; }

        Task<int> SaveChangesAsync( CancellationToken cancellationtoken = default);
    }
}
