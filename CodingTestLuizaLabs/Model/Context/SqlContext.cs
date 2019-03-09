using Microsoft.EntityFrameworkCore;

namespace CodingTestLuizaLabs.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
