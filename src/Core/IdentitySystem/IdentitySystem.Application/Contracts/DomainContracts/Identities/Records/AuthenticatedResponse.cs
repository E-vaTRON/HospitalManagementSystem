namespace IdentitySystem.Application;

public record AuthenticatedResponse( string userId,
                                     DateTime requestAt,
                                     string accessToken,
                                     DateTime expiredIn);