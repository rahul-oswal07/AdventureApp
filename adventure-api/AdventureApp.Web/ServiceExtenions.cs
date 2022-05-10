using AdventureApp.DataAccess;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AdventureApp.Web
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("enableForAll",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdventureRepository, AdventureRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserAdventureRepository, UserAdventureRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAdventureService, AdventureService>();
            services.AddScoped<IUserAdventureService, UserAdventureService>();
        }
        public static void AddAdventureDbContext(this WebApplicationBuilder builder)
        {
            var server = builder.Configuration["DatabaseServer"] ?? "";
            var port = builder.Configuration["DatabasePort"] ?? "";
            var user = builder.Configuration["DatabaseUser"] ?? "";
            var password = builder.Configuration["DatabasePassword"] ?? "";
            var database = builder.Configuration["DatabaseName"] ?? "";

            var connectionString = $"Server={server},{port}; Initial Catalog={database}; User ID ={user};Password={password} ";

            builder.Services.AddDbContext<AdventureDbContext>(options => options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// Initialize the migration when running in docker for the first time
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<AdventureDbContext>().Database.Migrate();
            }
        }
    }
}
