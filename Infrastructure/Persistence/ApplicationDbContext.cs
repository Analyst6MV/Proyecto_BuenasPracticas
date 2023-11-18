

using Application.Data;
using Domain.Customer;
using Domain.Primitive;
using MongoDB.Driver;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IApplicationDBContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        private readonly IMongoDatabase _database;
        public ApplicationDbContext(IMongoDatabase database, IPublisher publisher)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }


        IMongoCollection<Customer> IApplicationDBContext.Customer { get; set; }
        public IMongoCollection<Customer> Customer => _database.GetCollection<Customer>("Usuarios");


  
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // No necesitas un método SaveChangesAsync en MongoDB, ya que es sin estado y no hay confirmación explícita
            // Aquí puedes manejar eventos de dominio si es necesario
            try
            {
                var domainEvents = Customer.AsQueryable().SelectMany(e => e.GetDomainEvent());



                var result = await SaveChangesAsync(cancellationToken);
                foreach (var domainEvent in domainEvents)
                {
                    await _publisher.Publish(domainEvent, cancellationToken);
                }

                // Devuelve 0 ya que MongoDB no tiene un concepto de número de cambios como en un contexto relacional
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
               
            }
        
        }

    }

        //public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options) 
        //{
        //    _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));

        //}     

        // public DbSet<Customer> Customer { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    var domainEvents = ChangeTracker.Entries<AggregateRoot>()
        //                        .Select(e => e.Entity)
        //                        .Where(e => e.GetDomainEvent().Any())
        //                        .SelectMany(e => e.GetDomainEvent());

        //    var result = await base.SaveChangesAsync(cancellationToken);
        //    foreach (var DomainEvent in domainEvents)
        //    {
        //        await _publisher.Publish(DomainEvent,cancellationToken);

        //    }

        //    return result;
        //}


   // }
}
