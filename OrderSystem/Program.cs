using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using OrderSystem.Application;
using OrderSystem.Domain.DTO;
using OrderSystem.Domain.Interfaces;
using OrderSystem.Infrastructure.Context;
using OrderSystem.Infrastructure.Repositories;
using OrderSystem.Infrastructure.Validation; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderSystemDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<OrderDto>, OrderDtoValidator>();
builder.Services.AddScoped<IValidator<OrderRequestDto>, OrderRequestDtoValidator > ();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Bind Interfaces and implementations.
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();


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