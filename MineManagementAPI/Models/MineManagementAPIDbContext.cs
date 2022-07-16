using Microsoft.EntityFrameworkCore;

namespace MineManagementAPI.Models
{
    public class MineManagementAPIDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public MineManagementAPIDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
