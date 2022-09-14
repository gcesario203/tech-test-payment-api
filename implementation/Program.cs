using AutoMapper;
using implementation.Data;
using implementation.Data.ResponseObjects;
using implementation.Infrastructure.Config;
using implementation.Models;
using implementation.Repositories;
using implementation.Repositories.Interfaces;
using implementation.Services;
using implementation.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IRepository<Order>, OrderInMemoryRepository>();

builder.Services.AddScoped<IService<OrderDTO, ResultResponse>, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
