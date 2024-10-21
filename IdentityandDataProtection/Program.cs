using IdentityandDataProtection.Context;
using IdentityandDataProtection.Managers;
using IdentityandDataProtection.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cn = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<IdentityandDataProtectionDbContext>(options => options.UseSqlServer(cn));

builder.Services.AddScoped<IIdentityService, IdentityManager>();

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
