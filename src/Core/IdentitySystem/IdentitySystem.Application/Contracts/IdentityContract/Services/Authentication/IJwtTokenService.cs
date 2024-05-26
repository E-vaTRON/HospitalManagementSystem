namespace IdentitySystem.Application;

public interface IJwtTokenService
{
    string GenerateToken(InputUserDTO user, DateTime iat, DateTime exp);
}