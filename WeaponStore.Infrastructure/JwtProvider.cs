﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeaponStore.Core.Abstractions;
using WeaponStore.Core.Models;

namespace WeaponStore.Infrastructure;

public class JwtProvider : IJwtProvider
{
    private readonly JWTOptions _options;
    public JwtProvider(IOptions<JWTOptions> options)
    {
        _options = options.Value;
    }
    public string GenerateToken(User user)
    {
        Claim[] claims = [new("UserId", user.Id.ToString())];
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256Signature);
        
        var token = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpitesHours)
            );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}