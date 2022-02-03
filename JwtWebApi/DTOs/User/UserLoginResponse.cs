namespace JwtWebApi.DTOs.User;

public class UserLoginResponse
{
    public string Token { get; set; }

    public UserLoginResponse(string token)
    {
        Token = token;
    }
}
