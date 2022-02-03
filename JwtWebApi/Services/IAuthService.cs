using JwtWebApi.DTOs.User;

namespace JwtWebApi.Services
{
    public interface IAuthService
    {
        UserRegistrationResponse Register(UserRegistrationRequest user);

        UserLoginResponse Login(UserLoginRequest user);
    }

}
