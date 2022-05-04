using AdventureApp.DataAccess;
using AdventureApp.DataAccess.Repositories;
using AdventureApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AdventureDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureDatabase")));
builder.Services.AddScoped<IAdventureRepository, AdventureRepository>();
builder.Services.AddScoped<IAdventureService, AdventureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
