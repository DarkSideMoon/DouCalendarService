using Microsoft.IdentityModel.Tokens;

namespace DouCalendarService.Service.Security.Encrypt
{
    /// <summary>
    /// Ключ для дешифрования данных (приватный)
    /// </summary>
    public interface IJwtEncryptDecodingKey
    {
        SecurityKey GetKey();
    }
}
