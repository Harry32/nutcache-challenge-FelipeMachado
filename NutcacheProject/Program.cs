using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using AutoMapper;
using NutcacheProject.Mapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new MapperProfile()));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapperConfiguration.CreateMapper());
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

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
