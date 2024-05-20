using CoreUser = IdentitySystem.Domain.User;
using DataUser = IdentitySystem.DataProvider.User;

namespace IdentitySystem.DataProvider;

public class SignInProvider : SignInManager<CoreUser>, ISignInProvider
{
    public SignInProvider( UserManagerProvider userManager, 
                           IHttpContextAccessor contextAccessor, 
                           IUserClaimsPrincipalFactory<CoreUser> claimsFactory, 
                           IOptions<IdentityOptions> optionsAccessor, 
                           ILogger<SignInManager<CoreUser>> logger, 
                           IAuthenticationSchemeProvider schemes, 
                           IUserConfirmation<CoreUser> confirmation) 
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
    {
    }
}
