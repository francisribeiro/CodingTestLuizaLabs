using Microsoft.EntityFrameworkCore;

namespace CodingTestLuizaLabs.Model.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Wish> Whishes { get; set; }
    }
}
