using Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public interface IApplicationDBContext
    {
        DbSet<Customer> Customer {  get; set; } 

        Task<int> SaveChangesAsync( CancellationToken cancellationtoken = default);
    }
}
