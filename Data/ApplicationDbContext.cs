using Microsoft.EntityFrameworkCore;
using UntitledRPG.Models;

namespace UntitledRPG.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Retrieve connection string from IConfiguration
            var connectionString = _configuration.GetConnectionString("DATABASE_CONNECTION_STRING");

            // Use the connection string as needed
            optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion(new Version(8, 0, 34)));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
