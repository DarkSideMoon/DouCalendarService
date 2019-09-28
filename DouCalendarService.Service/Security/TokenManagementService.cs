using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DouCalendarService.Service.Configuration;
using DouCalendarService.Service.Security.Encrypt;
using DouCalendarService.Service.Security.Sign;
using Microsoft.IdentityModel.Tokens;

namespace DouCalendarService.Service.Security
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IJwtSignEncodingKey _jwtSignEncodingKey;
        private readonly IJwtEncryptEncodingKey _jwtEncryptEncodingKey;
        private readonly TokenConfig _tokenConfig;

        public TokenManagementService(
            IJwtSignEncodingKey jwtSignEncodingKey,
            IJwtEncryptEncodingKey jwtEncryptEncodingKey,
            TokenConfig tokenConfig)
        {
            _jwtSignEncodingKey = jwtSignEncodingKey;
            _jwtEncryptEncodingKey = jwtEncryptEncodingKey;
            _tokenConfig = tokenConfig;
        }

        public string GenerateToken()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "Full Name")
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateJwtSecurityToken(
                _tokenConfig.Issuer,
                _tokenConfig.Audience,
                new ClaimsIdentity(claims),
                DateTime.Now,
                DateTime.Now.AddMinutes(_tokenConfig.AccessExpiration),
                DateTime.Now,
                new SigningCredentials(_jwtSignEncodingKey.GetKey(), _jwtSignEncodingKey.SigningAlgorithm),
                new EncryptingCredentials(_jwtEncryptEncodingKey.GetKey(), _jwtEncryptEncodingKey.SigningAlgorithm,
                    _jwtEncryptEncodingKey.EncryptingAlgorithm));

            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
