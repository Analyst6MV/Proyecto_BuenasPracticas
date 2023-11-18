namespace Domain.Customer
{
    public interface ICustomerRepository
    {

        Task<Customer?> GetCustomerById(int id);
   
        Task Add(Customer customer);



    }
}
