using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchmersalGlobalTask.Domain.Repositories;
using SchmersalGlobalTask.Infrastructure;
using SchmersalGlobalTask.Infrastructure.Repositories;
using SchmersalGlobalTask.Services;
using SchmersalGlobalTask.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchmersalConnectionString")),
    ServiceLifetime.Singleton
    );
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
