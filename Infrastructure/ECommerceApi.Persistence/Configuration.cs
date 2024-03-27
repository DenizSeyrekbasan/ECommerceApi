using Microsoft.Extensions.Configuration;
using System.IO;

namespace ECommerceApi.Persistence
{
    public static class Configuration
    {
        private static IConfiguration _configuration;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("PostgreSQL");
            }
        }
    }
}
