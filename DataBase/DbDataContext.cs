using Microsoft.EntityFrameworkCore;

namespace HansJhonnyAPI.DataBase
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbDataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
