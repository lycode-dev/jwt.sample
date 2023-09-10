using ly.jwt.Models;

namespace ly.jwt.Constants;

public class UserConstant
{
    public static List<User> GetUsers() => new()
    {
        new User { Username = "Leon", Password = "pass123", Role = "Admin"},
        new User { Username = "Thomas", Password = "pass123", Role = "Client"},
        new User { Username = "Juan", Password = "pass123", Role = "Client"}
    };
}
