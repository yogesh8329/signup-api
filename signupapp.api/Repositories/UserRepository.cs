using SignupApp.API.Models;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User GetByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }
}