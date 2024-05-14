namespace IdentitySystem.Application;

public interface IJwtTokenService
{
    string GenerateToken(UserCreateDTO user, DateTime iat, DateTime exp);
}