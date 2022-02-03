using JwtWebApi.DTOs.User;

namespace JwtWebApi.Services.AuthService
{
    public interface IAuthService
    {
        UserRegistrationResponse Register(UserRegistrationRequest user);

        UserLoginResponse Login(UserLoginRequest user);
    }

}
