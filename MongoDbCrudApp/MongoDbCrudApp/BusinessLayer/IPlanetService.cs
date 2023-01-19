using MongoDB.Bson;

namespace MongoDbCrudApp.BusinessLayer
{
    public interface IPlanetService
    {
        Task<IEnumerable<BsonDocument>> ReadAllAsync();
        Task<BsonDocument> ReadAsync(string name);
        Task<BsonDocument> CreateAsync(BsonDocument planet);
        Task<BsonDocument> UpdateAsync(string id, BsonDocument planet);
        Task<BsonDocument> DeleteAsync(string name);

    }
}
