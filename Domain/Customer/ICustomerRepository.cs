using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customer
{
    public interface ICustomerRepository
    {

        Task<Customer?> GetCustomerById(CustomerId id);
   
        Task Add(Customer customer);
    }
}
