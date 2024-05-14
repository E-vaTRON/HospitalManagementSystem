using Microsoft.AspNetCore.Identity;
using CoreUser = IdentitySystem.Domain.User;
using DTOUser = IdentitySystem.Application.UserDTO;

namespace IdentitySystem.ServiceProvider;

public class UserServiceProvider : IdentityServiceProviderBase<DTOUser, CoreUser>, IUserServiceProvider
{
    #region [ Field ]
    private readonly IUserDataProvider DataProvider;
    private readonly ISignInProvider SignInProvider;
    #endregion

    #region [ CTor ]
    public UserServiceProvider(IUserDataProvider dataProvider, ISignInProvider signInProvider, IMapper mapper) : base(mapper)
    {
        DataProvider = dataProvider;
        SignInProvider = signInProvider;
    }
    #endregion

    #region [ Public - Method ]
    public async Task<SignInResult> CheckPasswordSignInAsync(DTOUser userDto, string password, LoginMode mode, bool lockoutOnFailure, CancellationToken cancellationToken = default)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        switch (mode)
        {
            case LoginMode.Email:
                if (user.Email is not null)
                {
                    var result = await DataProvider.FindByEmailAsync(user.Email, cancellationToken);
                    return result is not null ? await SignInProvider.CheckPasswordSignInAsync(result, password, lockoutOnFailure)
                                              : SignInResult.Failed;
                }
                break;
            case LoginMode.PhoneNumber:
                if (user.PhoneNumber is not null)
                {
                    var result = await DataProvider.FindByPhoneNumberAsync(user.PhoneNumber, cancellationToken);
                    return result is not null ? await SignInProvider.CheckPasswordSignInAsync(result, password, lockoutOnFailure)
                                              : SignInResult.Failed;
                }
                break;
        }
        return SignInResult.Failed;
    }

    public IQueryable<DTOUser> FindAll(Expression<Func<DTOUser, bool>>? dtoPredicate = null)
    {
        var entityPredicate = dtoPredicate != null ? MapToEntityPredicate(dtoPredicate) : null;
        var entities = DataProvider.FindAll(entityPredicate);
        return MapToDTOs(entities).AsQueryable();
    }

    public async Task<DTOUser?> FindByGuidAsync(string guid, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(guid, "Id Is null");
        var user = await DataProvider.FindByGuidAsync(guid, cancellationToken);
        return MapToDTO(user);
    }

    public async Task<IReadOnlyCollection<DTOUser>> FindByMultipleGuidsAsync(string[] userGuids, CancellationToken cancellationToken = default)
    {
        var users = await DataProvider.FindByMultipleGuidsAsync(userGuids, cancellationToken);
        return MapToDTOs(users).ToList().AsReadOnly();
    }

    public async Task<DTOUser?> FindByNameAsync(string userName)
    {
        ArgumentNullException.ThrowIfNull(userName, nameof(userName));
        var user = await DataProvider.FindByNameAsync(userName);
        return MapToDTO(user);
    }

    public async Task<DTOUser?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(email, nameof(email));
        var user = await DataProvider.FindByPhoneNumberAsync(email);
        return MapToDTO(user);
    }

    public async Task<DTOUser?> FindByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(phoneNumber, nameof(phoneNumber));
        var user = await DataProvider.FindByPhoneNumberAsync(phoneNumber);
        return MapToDTO(user);
    }

    public Task<IdentityResult> CreateAsync(DTOUser userDto, string password)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return DataProvider.CreateAsync(user, password);
    }

    public Task<IdentityResult> UpdateAsync(DTOUser userDto)
    {
        var user = MapToEntity(userDto);
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        return DataProvider.UpdateAsync(user);
    }
    #endregion
}
