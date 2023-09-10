using ly.jwt.Constants;
using ly.jwt.Models;
using ly.jwt.Services.Contracts;

namespace ly.jwt.Services
{
    public class UserService : IUserService
    {
        public User Get(string username, string password)
        {
            return UserConstant.GetUsers().FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
