using SignupApp.API.Models;

public interface IUserRepository
{
    void Add(User user);
    User GetByEmail(string email);
}