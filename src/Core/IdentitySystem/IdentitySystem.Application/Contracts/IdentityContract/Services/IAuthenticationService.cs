namespace IdentitySystem.Application;

/// <summary>
/// This is interface defining supported methods for authentication process
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Log user in based on provided username & password.
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<OneOf<ServiceSuccess, ServiceError>> Login( Login dto,
                                                     string conumerName,
                                                     CancellationToken cancellationToken);

    /// <summary>
    /// Log user in based on provided phonenumber & password.
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<OneOf<ServiceSuccess, ServiceError>> LoginWithPhoneNumber( PhoneNumberUserLogin dto,
                                                                    string consumerName,
                                                                    CancellationToken cancellationToken );

    /// <summary>
    /// Create new user
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<OneOf<ServiceSuccess, ServiceError>> Register( SignUp dto,
                                                        string consumerName,
                                                        CancellationToken cancellationToken );
}