using Microsoft.EntityFrameworkCore;
using System;
using TicketSystem.Data;
using TicketSystem.Helper;
using TicketSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 🔹 Đọc chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MyDb");

// 🔹 Đăng ký DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddScoped<IUserRepository, UserRepository>();
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
