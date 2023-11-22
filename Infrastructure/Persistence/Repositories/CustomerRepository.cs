using Domain.Customer;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Infrastructure.Persistence.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {

        // private readonly ApplicationDbContext _context;
        private readonly IMongoCollection<CustomerPersona> _customersCollectionPersona;
        private readonly IMongoCollection<CustomerEmpresa> _customersCollectionEmpresa;
        private readonly IMongoCollection<DataLogin> _DataLogin;

        public CustomerRepository(IMongoDatabase context) {

            _customersCollectionPersona = context.GetCollection<CustomerPersona>("Usuarios");
            _customersCollectionEmpresa = context.GetCollection<CustomerEmpresa>("Usuarios");
            _DataLogin = context.GetCollection<DataLogin>("Usuarios");

        }


        public async Task AddPersona(CustomerPersona customer) => await _customersCollectionPersona.InsertOneAsync(customer);
        public async Task AddEmpresa(CustomerEmpresa customer) => await _customersCollectionEmpresa.InsertOneAsync(customer);

        public async Task<CustomerPersona?> GetCustomerPersonaById(int id) =>await _customersCollectionPersona.Find(x => x.Id == id).SingleOrDefaultAsync();
        public async Task<CustomerEmpresa?> GetCustomerEmpresaById(int id) =>await _customersCollectionEmpresa.Find(x => x.Id == id).SingleOrDefaultAsync();

        public async Task<DataLogin?> Login(string usuario, string password)
        {
            var filter = Builders<DataLogin>.Filter.And(
                    Builders<DataLogin>.Filter.Or(
                        Builders<DataLogin>.Filter.Eq(x => x.Email, usuario),
                        Builders<DataLogin>.Filter.Eq(x => x.NombreUsuario, usuario)
                    ),Builders<DataLogin>.Filter.Eq(x => x.Password, password));
            
            var projection = Builders<DataLogin>.Projection
            .Include(x => x.NombreUsuario)
            .Include(x => x.TipoUsuario)
            .Include(x => x.TokenAcceso)
            .Include(x => x.FechaCreacionTokenAcceso)
            .Include(x => x.SesionActiva);


            var r =  await _DataLogin.Find(filter).Project<DataLogin>(projection).SingleOrDefaultAsync();
            return r;
        }

        public async Task<string> ValidarEmailYNombreUsuario(string nombreUsuario, string email) {

            var projection = Builders<DataLogin>.Projection
            .Include(x => x.NombreUsuario)
            .Include(x => x.TipoUsuario)
            .Include(x => x.TokenAcceso)
            .Include(x => x.FechaCreacionTokenAcceso)
            .Include(x => x.SesionActiva);
            var result =  _DataLogin.Find(e => e.Email == email).Project(projection).SingleOrDefault();

            if(result != null)
            {
                return "Ya existe un usuario con este correo";
            }
            result =  _DataLogin.Find(e => e.NombreUsuario == nombreUsuario).Project(projection).SingleOrDefault();

            if (result != null)
            {
                return "Ya existe un usuario con este nombre de usuario";
            }


            return string.Empty;



        }
        public async Task<bool> RegistarToken(int id, string token, DateTime FechaCreacion) 
        {
            var filter = Builders<DataLogin>.Filter.Eq(u => u._id, id);
            var update = Builders<DataLogin>.Update
                .Set(u => u.TokenAcceso, token)
                .Set(u => u.FechaCreacionTokenAcceso, FechaCreacion)
                .Set(u => u.SesionActiva, true);

            var updateResult = await _DataLogin.UpdateOneAsync(filter, update);

            if (updateResult.ModifiedCount == 0)
            {
                return false;

            }
            return true;

        }

        public async Task<DataLogin?> ActualizarToken(int id)
        {
            var filter = Builders<DataLogin>.Filter.Eq(u => u._id, id);

            var projection = Builders<DataLogin>.Projection
             .Include(x => x.NombreUsuario)
             .Include(x => x.TipoUsuario)
             .Include(x => x.TokenAcceso)
             .Include(x => x.FechaCreacionTokenAcceso)
             .Include(x => x.SesionActiva);

            return await _DataLogin.Find(filter).Project<DataLogin>(projection).SingleOrDefaultAsync(); 
        }
    }
}
