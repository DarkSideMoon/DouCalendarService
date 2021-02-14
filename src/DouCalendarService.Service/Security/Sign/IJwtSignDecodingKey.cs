using Microsoft.IdentityModel.Tokens;

namespace DouCalendarService.Service.Security.Sign
{
    /// <summary>
    /// Ключ для проверки подписи (публичный)
    /// </summary>
    public interface IJwtSignDecodingKey
    {
        SecurityKey GetKey();
    }
}
