using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DouCalendarService.Service.Security.Sign
{
    public class SignSymmetricKey : IJwtSignEncodingKey, IJwtSignDecodingKey
    {
        private readonly SymmetricSecurityKey _secretKey;

        public string SigningAlgorithm { get; } = SecurityAlgorithms.HmacSha256;

        public SignSymmetricKey(string key)
        {
            _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public SecurityKey GetKey() => _secretKey;
    }
}
