using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbCrudApp.DataAccess;

namespace MongoDbCrudApp.BusinessLayer
{

    public class PlanetService : IPlanetService
    {
        private IMongoCollection<BsonDocument> _dbContext;

        public PlanetService()
        {
            _dbContext = new PlanetDbContext().GetCollection<BsonDocument>("planets");
        }
        IFindFluent<BsonDocument, BsonDocument> ProjectedDocument(FilterDefinition<BsonDocument>? filter)
        {
            var projection = Builders<BsonDocument>.Projection.Exclude("mainAtmosphere").Exclude("surfaceTemperatureC");
            var result = _dbContext.Find(filter).Project(projection);
            return result;
        }
        public async Task<IEnumerable<BsonDocument>> ReadAllAsync()
        {
            return await ProjectedDocument(new BsonDocument()).ToListAsync();
        }
        public async Task<BsonDocument> ReadAsync(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("name", name);
            var result = await ProjectedDocument(filter).SingleOrDefaultAsync();
            return result;
        }

        public async Task<BsonDocument> CreateAsync(BsonDocument newPlanet)
        {
            await _dbContext.InsertOneAsync(newPlanet);
            if (newPlanet is null) return new BsonDocument();
            return newPlanet;
        }

        public async Task<BsonDocument> UpdateAsync(string id, BsonDocument updatedPlanet)
        {
            bool isValidId = ObjectId.TryParse(id, out var objectId);
            if (!isValidId) return new BsonDocument();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            await _dbContext.ReplaceOneAsync(filter, updatedPlanet);
            return updatedPlanet;
        }

        public async Task<BsonDocument> DeleteAsync(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("name", name);
            var result = await _dbContext.DeleteOneAsync(filter);
            return result.ToBsonDocument();
        }
    }
}



