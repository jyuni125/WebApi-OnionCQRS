
using Microsoft.EntityFrameworkCore;
using OnionApi.Domain.Contracts;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Infrastructure;
using OnionApi.Infrastructure.Databases.Context;
using OnionApi.Infrastructure.Databases.Repositories;

var builder = WebApplication.CreateBuilder(args);

//for swagger
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Bert API v1",
        Description = "THIS IS A SAMPLE API ONLY"
    });
});




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

/*
//for dbContext
var config = builder.Configuration;
const string FAMILYTDB_CONTEXT_CONNSTRING = "_Family";


builder.Services.AddDbContext<FamilyDBContext>(option =>
{
    option.UseSqlServer(config.GetConnectionString(FAMILYTDB_CONTEXT_CONNSTRING));
});
*/

builder.Services.AddPersistence(builder.Configuration);


//for Dependency Injection
//builder.Services.AddScoped(typeof(IFamilyRepository<>), typeof(FamilyRepository<>));



var app = builder.Build();

// Configure the HTTP request pipeline.  new one ito
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample Web Api Only");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
