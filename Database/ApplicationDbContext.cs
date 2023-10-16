using Microsoft.EntityFrameworkCore;

namespace UntitledRPG.Database
{
    public class ApplicationDbContext : DbContext
    {
        // public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql( "Server=your_mysql_server;Database=your_database_name;User=your_username;Password=your_password;");
            }
        }
    }
}
