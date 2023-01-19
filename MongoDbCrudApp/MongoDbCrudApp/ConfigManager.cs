using Microsoft.Extensions.Configuration;

namespace MongoDbCrudApp
{
    public class ConfigManager
    {
        private readonly IConfiguration _config;

        public ConfigManager()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo parentDirectory = Directory.GetParent(baseDirectory);
            var builder = new ConfigurationBuilder()
           .SetBasePath(parentDirectory.Parent.Parent.Parent.ToString())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            _config = config;
        }

        public string GetPassword()
        {
            return _config.GetSection("MongoDb:Password").Value;
            ;
        }

    }
}
