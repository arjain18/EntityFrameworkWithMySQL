using EntityFrameworkWithMySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWithMySQL.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options){ }
        public DbSet<Product> Products { get; set; }    

    }
}
