using DouCalendarService.Service.Configuration;
using DouCalendarService.Service.Security;
using DouCalendarService.Service.Security.Encrypt;
using DouCalendarService.Service.Security.Sign;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace DouCalendarService.WebAPI.Infrastructure
{
    public static class AuthenticationCollectionExtension
    {
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, ServiceConfig serviceConfig)
        {
            var signKey = new SignSymmetricKey(serviceConfig.TokenConfig.SignSecretKey);
            var encryptKey = new EncryptSymmetricKey(serviceConfig.TokenConfig.EncodingSecretKey);

            services.AddSingleton<IJwtSignEncodingKey>(signKey);
            services.AddSingleton<IJwtEncryptEncodingKey>(encryptKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = ((IJwtSignDecodingKey)signKey).GetKey(),
                    TokenDecryptionKey = ((IJwtEncryptDecodingKey)encryptKey).GetKey(),

                    ValidIssuer = serviceConfig.TokenConfig.Issuer,
                    ValidateIssuer = true,

                    ValidAudience = serviceConfig.TokenConfig.Audience,
                    ValidateAudience = true,

                    ClockSkew = TimeSpan.FromSeconds(5)
                };
            });

            return services;
        }
    }
}
