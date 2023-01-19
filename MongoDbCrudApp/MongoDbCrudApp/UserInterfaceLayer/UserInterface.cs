using MongoDB.Bson;

namespace MongoDbCrudApp.UserInterfaceLayer
{
    public class UserInterface : IUserInterface
    {
        DataChecker _dataTypeHelper;
        public UserInterface()
        {
            _dataTypeHelper = new();
        }
        public int GetMenuChoice()
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out var num);
            return num;
        }

        public BsonDocument GetItem()
        {
            Console.Write("Enter planet: ");
            string planetName = Console.ReadLine();

            Console.Write("Enter order from sun: ");
            string orderFromSun = Console.ReadLine();

            Console.Write("Enter has rings (y/n): ");
            string rings = Console.ReadLine();
            // Insert code to save Planet to database here
            var planet = new BsonDocument()
            {
                { "name", planetName },
                { "orderFromSun", _dataTypeHelper.StringToNumber(orderFromSun) },
                { "hasRings", _dataTypeHelper.StringToBoolean(rings) },
           };
            //return (T)Convert.ChangeType(planet, typeof(T));
            return planet;
        }

        public string GetName()
        {
            Console.Write("Enter the name: ");
            var name = Console.ReadLine();
            return name;
        }
        public string GetId()
        {
            Console.Write("Enter the id: ");
            var id = Console.ReadLine();
            return id;
        }

        public void ShowItem(BsonDocument item)
        {
            Console.WriteLine(item);
        }
    }

}
