namespace IdentitySystem.Application;

public interface IJwtTokenService
{
    string GenerateToken(UserDTO user, DateTime iat, DateTime exp);
}