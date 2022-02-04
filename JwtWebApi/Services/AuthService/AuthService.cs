using JwtWebApi.Data;
using JwtWebApi.DTOs.User;
using JwtWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JwtWebApi.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _ctx;
    private readonly string _secret;

    public AuthService(DataContext ctx, IConfiguration config)
    {
        _ctx = ctx;
        _secret = config["AppSettings:Token"];
    }

    public UserRegistrationResponse Register(UserRegistrationRequest user)
    {
        var (username, password) = user;

        if (UserExists(username))
        {
            throw new Exception("User exists");
        }

        var (hash, salt) = HashPassword(password);

        User newUser = new()
        {
            Username = username,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        _ctx.Users.Add(newUser);
        _ctx.SaveChanges();

        return new UserRegistrationResponse { Username = username };
    }

    public UserLoginResponse Login(UserLoginRequest request)
    {
        var (username, password) = request;
        var user = _ctx.Users.FirstOrDefault(user => user.Username == username);

        if (user is null)
        {
            throw new Exception("User not found");
        }


        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new Exception("Bad credentials");
        }

        var token = CreateToken(user);
        return new UserLoginResponse(token);
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hms = new HMACSHA512(passwordSalt);
        var hash = hms.ComputeHash(Encoding.UTF8.GetBytes(password));

        return hash.SequenceEqual(passwordHash);
    }

    private (byte[] passwordHash, byte[] passwordSalt) HashPassword(string password)
    {
        using var hms = new HMACSHA512();
        var salt = hms.Key;
        var hash = hms.ComputeHash(Encoding.UTF8.GetBytes(password));
        return (hash, salt);
    }

    private bool UserExists(string username)
    {
        return _ctx.Users.Any(user => user.Username == username);
    }
}
