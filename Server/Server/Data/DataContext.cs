using Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
