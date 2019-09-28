using Microsoft.IdentityModel.Tokens;

namespace DouCalendarService.Service.Security.Sign
{
    /// <summary>
    /// Ключ для создания подписи (приватный)
    /// </summary>
    public interface IJwtSignEncodingKey
    {
        string SigningAlgorithm { get; }

        SecurityKey GetKey();
    }
}
