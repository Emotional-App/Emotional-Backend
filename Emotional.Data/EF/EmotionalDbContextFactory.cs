using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Emotional.Data.EF
{
    public class EmotionalDbContextFactory : IDesignTimeDbContextFactory<EmotionalDbContext>
    {
        public EmotionalDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("emotional");

            var optionsBuilder = new DbContextOptionsBuilder<EmotionalDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EmotionalDbContext(optionsBuilder.Options); 
        }
    }
}
