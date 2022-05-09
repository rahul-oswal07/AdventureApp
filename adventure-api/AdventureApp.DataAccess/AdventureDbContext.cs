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

        public DbSet<User> User { get; set; }

        public DbSet<UserAdventure> UserAdventure { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>()
                .HasMany(question => question.Questions)
                .WithOne(question => question.ParentQuestion)
                .HasForeignKey(question => question.ParentQuestionId);

            base.OnModelCreating(builder);
        }
    }
}
