using AdventureApp.Web;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Adventure API", Version = "v1" });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure the db context
builder.AddAdventureDbContext();

builder.Services.ConfigureCors();

// Configure all the repositories
builder.Services.ConfigureRepositories();

// Configure all the services
builder.Services.ConfigureServices();
var app = builder.Build();

DatabaseManagementService.MigrationInitialisation(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Adventure API V1");
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionLoggerMiddleware>();

app.UseAuthorization();
app.UseCors("enableForAll");
app.MapControllers();
app.UseRouting();
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.Run();
