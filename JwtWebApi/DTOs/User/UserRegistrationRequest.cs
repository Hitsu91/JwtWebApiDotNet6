namespace JwtWebApi.DTOs.User;

public class UserRegistrationRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    internal void Deconstruct(out string username, out string password)
    {
        username = Username;
        password = Password;
    }
}
