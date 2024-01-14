using Microsoft.EntityFrameworkCore;

namespace TokenBasedAuthentication.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options): base(options)
        {}

        public DbSet<Models.Domain.UserEntity> Users { get; set; }
    }
}
