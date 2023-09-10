using ly.jwt.Models;

namespace ly.jwt.Services.Contracts
{
    public interface IJwtAuthentication
    {
        string GetToken(User user);
    }
}
