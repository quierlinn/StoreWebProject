using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.IdentityModel.Tokens;
using WeaponStore.Application.Services;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Enums;
using WeaponStore.DataAccess;
using WeaponStore.DataAccess.Configurations;
using WeaponStore.DataAccess.Repositories;
using WeaponStore.Infrastructure;
using WeaponStore.Infrastructure.Authorization;
using AuthorizationOptions = WeaponStore.DataAccess.AuthorizationOptions;


var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection(nameof(JWTOptions)));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            "vasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGay"))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.AddRequirements(
        new PermissionRequirement([PermissionEnum.Create, PermissionEnum.Read, PermissionEnum.Update, PermissionEnum.Delete])));
    options.AddPolicy("UserPolicy", policy => policy.AddRequirements(new PermissionRequirement([PermissionEnum.Read])));
});
builder.Services.AddDbContext<WeaponStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(WeaponStoreDbContext)));
});
builder.Services.Configure<AuthorizationOptions>(builder.Configuration.GetSection(nameof(AuthorizationOptions)));
builder.Services.AddScoped<IWeaponsService, WeaponsService>();
builder.Services.AddScoped<IWeaponsRepository, WeaponsRepository>();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();
app.Run();