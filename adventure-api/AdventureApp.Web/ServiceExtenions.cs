using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;

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
    }
}
