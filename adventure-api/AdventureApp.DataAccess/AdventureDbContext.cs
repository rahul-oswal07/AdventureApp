using AdventureApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.DataAccess
{
    public class AdventureDbContext : DbContext
    {
        public AdventureDbContext(DbContextOptions<AdventureDbContext> options) : base(options)
        {

        }

        public DbSet<Adventure> Adventure { get; set; }

        public DbSet<Question> Question { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
