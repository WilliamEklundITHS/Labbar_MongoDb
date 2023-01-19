using MongoDB.Bson;

namespace MongoDbCrudApp.UserInterfaceLayer
{
    public interface IUserInterface
    {
        int GetMenuChoice();
        BsonDocument GetItem();
        string GetName();
        string GetId();
        void ShowItem(BsonDocument item);
    }
}
