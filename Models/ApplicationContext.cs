using Microsoft.EntityFrameworkCore;
using TestCSharp.Models;

namespace TestCSharp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Goods> TGoods { get; set; }
        public DbSet<StorageRoom> TStorageRoom { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
