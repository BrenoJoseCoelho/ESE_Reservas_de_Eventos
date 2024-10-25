using ESEIdentity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ESEIdentity;

public class JwtTokenHandler
{
    public const string JWT_SECURITY__KEY = "faSLkdfpasolkdaASFNNppasS";
    public const int JWT_TOKEN_VALIDITY = 20;
    private readonly List<User> _users;

    public JwtTokenHandler()
    {
        _users = new List<User>
        {
            new User{Document= "0000000", Email="admin@admin.com", Password = "admin123",Name="admin",Role="Administrator"},
            new User{Document= "user01", Email="user01@user01.com", Password="user123", Name="user01",Role="User"}
        };
    }

    public AuthenticationResponse GenerateJwtToken(AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password)) { return null; }

        var user = _users.Where(c => c.Name == authenticationRequest.UserName && c.Password == authenticationRequest.Password).FirstOrDefault();
        if (user == null) return null;

        var tookenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY__KEY);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tookenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            UserName = user.Name,
            ExpiresIn = (int)tookenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            JwtToken = token,
        };
    }
}
