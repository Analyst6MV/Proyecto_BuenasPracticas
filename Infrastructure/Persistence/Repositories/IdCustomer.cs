using Domain.Customer;
using ErrorOr;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Infrastructure.Persistence.Repositories
{
    internal class IdCustomer : IIdCustomer
    {

        // private readonly ApplicationDbContext _context;
        private readonly IMongoCollection<BsonDocument> _IdsCollection;
        public IdCustomer(IMongoDatabase context)
        {

            _IdsCollection = context.GetCollection<BsonDocument>("IdTiendaAPI");


        }

        public async Task ActualizarID(int ultimoid) {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", "IdUsuarios");
            var update = Builders<BsonDocument>.Update.Set("UltimoId", ultimoid);



            await _IdsCollection.UpdateOneAsync(filter, update); 
        }

        public async Task<int> UltimoID() {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "IdUsuarios");
            var id = await _IdsCollection.Find(filter).SingleOrDefaultAsync();

            if (id == null || !id.Contains("UltimoId") || !id["UltimoId"].IsInt32) 
            {
                return 0;
            }

            return id["UltimoId"].AsInt32;

        }


    }
}
