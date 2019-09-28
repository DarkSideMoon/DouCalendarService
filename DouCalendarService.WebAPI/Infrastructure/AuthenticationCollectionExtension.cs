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
        public static IServiceCollection AddJwtTokenAuthentication(this IServiceCollection services, TokenConfig tokenConfig)
        {
            var signKey = new SignSymmetricKey(tokenConfig.SignSecretKey);
            var encryptKey = new EncryptSymmetricKey(tokenConfig.EncodingSecretKey);

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

                    ValidIssuer = tokenConfig.Issuer,
                    ValidateIssuer = true,

                    ValidAudience = tokenConfig.Audience,
                    ValidateAudience = true,

                    ClockSkew = TimeSpan.FromSeconds(5)
                };
            });

            return services;
        }
    }
}
