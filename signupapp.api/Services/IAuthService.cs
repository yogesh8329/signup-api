using SignupApp.API.DTOs;

public interface IAuthService
{
    bool Signup(SignupRequestDto request);
}