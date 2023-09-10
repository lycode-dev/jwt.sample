using ly.jwt.Models;

namespace ly.jwt.Services.Contracts
{
    public interface IUserService
    {
        User Get(string username, string password);
    }
}
