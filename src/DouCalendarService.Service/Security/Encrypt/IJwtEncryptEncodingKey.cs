using Microsoft.IdentityModel.Tokens;

namespace DouCalendarService.Service.Security.Encrypt
{
    /// <summary>
    /// Ключ для шифрования данных (публичный)
    /// </summary>
    public interface IJwtEncryptEncodingKey
    {
        string SigningAlgorithm { get; }

        string EncryptingAlgorithm { get; }

        SecurityKey GetKey();
    }
}
