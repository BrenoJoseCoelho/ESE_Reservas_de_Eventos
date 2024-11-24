using ESEIdentity.Models;
using ESEIdentity.Services.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenHandler
{
    public const string JWT_SECURITY__KEY = "EstaEUmaChave32Bytes12345678aaaa";
    public const int JWT_TOKEN_VALIDITY = 20;
    private readonly List<User> _users;
    IUserService _userService;

    public JwtTokenHandler(IUserService userService)
    {
        _userService = userService;
        _users = new List<User>
        {
            new User{Document= "0000000", Email="admin@admin.com", Password = "admin123", Name="admin", Role="Administrator"},
            new User{Document= "user01", Email="user01@user01.com", Password="user123", Name="user01", Role="User"}
        };
    }

    public AuthenticationResponse GenerateJwtToken(AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
        {
            return null;
        }

        var user = _userService.GetUserByNameAndPassWord(authenticationRequest);
        if (user.Result == null) return null;

        var now = DateTime.UtcNow;
        var tokenExpiryTimeStamp = now.AddMinutes(JWT_TOKEN_VALIDITY);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY__KEY);

        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
        });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            NotBefore = now,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            UserName = user.Result.Name,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(now).TotalSeconds,
            JwtToken = token,
        };
    }
}
