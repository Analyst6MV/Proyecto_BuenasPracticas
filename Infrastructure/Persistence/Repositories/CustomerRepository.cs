using Domain.Customer;
using MongoDB.Driver;


namespace Infrastructure.Persistence.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
      
       // private readonly ApplicationDbContext _context;
        private readonly IMongoCollection<Customer> _customersCollection;
        public CustomerRepository(IMongoDatabase context) {

           // _context = context ?? throw new ArgumentNullException(nameof(context));
           // _customersCollection = context.Customer ?? throw new ArgumentNullException(nameof(context));
            _customersCollection = context.GetCollection<Customer>("Usuarios");

        }

        //public async Task Add(Customer customer) => await _context.Customer.AddAsync(customer);

        //public async Task<Customer?> GetCustomerById(CustomerId id) => await _context.Customer.SingleOrDefaultAsync(x => x.Id == id);
        public async Task Add(Customer customer) => await _customersCollection.InsertOneAsync(customer);

        public async Task<Customer?> GetCustomerById(int id) =>
            await _customersCollection.Find(x => x.Id == id).SingleOrDefaultAsync();

    }
}
