﻿namespace IdentitySystem.ServiceProvider;

public class JWTTokenService : IJwtTokenService
{
    #region [ Fields ]
    private readonly JwtTokenConfig TokenConfig;
    #endregion

    #region [CTor]
    public JWTTokenService( IOptionsMonitor<JwtTokenConfig> tokenConfigOptionsAccessor)
    {
        this.TokenConfig = tokenConfigOptionsAccessor.CurrentValue;
    }
    #endregion

    #region [Methods]
    public string GenerateToken(InputUserDTO user, DateTime iat, DateTime exp)
    {
        var handler = new JwtSecurityTokenHandler();

        var identity = new ClaimsIdentity(
            new GenericIdentity(user.UserName, "TokenAuth"),
            new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("guid", user.Id)
                  }
            // TODO: add more user's claims
            );

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfig.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = TokenConfig.Issuer,
            Audience = "",  // TODO: client's name/id
            SigningCredentials = creds,
            Subject = identity,
            IssuedAt = iat,
            Expires = exp
        });

        return handler.WriteToken(securityToken);
    }

    #endregion
}