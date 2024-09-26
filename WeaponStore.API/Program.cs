using System;
using Microsoft.EntityFrameworkCore;
using WeaponStore.Application.Services;
using WeaponStore.Core.Abstractions;
using WeaponStore.DataAccess;
using WeaponStore.DataAccess.Repositories;
using WeaponStore.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WeaponStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(WeaponStoreDbContext)));
});
builder.Services.AddScoped<IWeaponsService, WeaponsService>();
builder.Services.AddScoped<IWeaponsRepository, WeaponsRepository>();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();