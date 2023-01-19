namespace MongoDbCrudApp
{
    public class DataChecker
    {
        public int StringToNumber(string input)
        {
            if (!int.TryParse(input, out int number))
            {
                return 0;
            }
            return number;
        }
        public bool StringToBoolean(string input)
        {
            return input != "y" ? false : true;
        }

    }
}
