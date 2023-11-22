using Domain.Customer;
using MongoDB.Driver;

namespace Application.Data
{
    public interface IApplicationDBContext
    {

        IMongoCollection<CustomerPersona> Customer { get; set; }

    }
}
