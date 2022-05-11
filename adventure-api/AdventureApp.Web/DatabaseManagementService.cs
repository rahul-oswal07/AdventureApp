using AdventureApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.Web
{
    public static class DatabaseManagementService
    {
        // Getting the scope of our database context
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<AdventureDbContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
