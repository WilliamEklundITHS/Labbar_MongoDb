using MongoDB.Driver;
namespace MongoDbCrudApp.DataAccess
{
    public class PlanetDbContext
    {
        private readonly IMongoDatabase _db;
        private readonly ConfigManager _configManager;
        public PlanetDbContext()
        {
            _configManager = new ConfigManager();
            var secret = _configManager.GetPassword();
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://atlasUser:{secret}@cluster0.t8yxerj.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            _db = client.GetDatabase("sample_guides");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }



    }
}
