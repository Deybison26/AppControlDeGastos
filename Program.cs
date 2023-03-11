using Microsoft.OpenApi.Models;
using AppControlDeGatos.Domain.Interfaces;
using AppControlDeGatos.Domain.Services;
using AppControlDeGatos.Infrastructure;
using AppControlDeGatos.Infrastructure.Repositories;
//using AppControlDeGatos.Domain.Interfaces;
using AppControlDeGatos.Infrastructure.Finders;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserFinder, UserFinder>();
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
