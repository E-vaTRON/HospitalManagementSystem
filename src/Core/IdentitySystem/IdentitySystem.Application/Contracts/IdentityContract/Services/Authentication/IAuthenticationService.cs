﻿namespace IdentitySystem.Application;

/// <summary>
/// This is interface defining supported methods for authentication process
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Attempts to log in a user based on the provided credentials.
    /// </summary>
    /// <param name="dto">The <see cref="UserNameLoginRecord"/> containing user login information, including username and password.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while processing the login request.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous login operation. The task result is a <see cref="OneOf{T0, T1}"/> representing either
    /// a successful login with an <see cref="ServiceSuccess"/> or an error with a <see cref="ServiceError"/>.
    /// </returns>
    Task<OneOf<ServiceSuccess, ServiceError>> LoginWithUserName ( UserNameLoginRecord dto, string conumerName, CancellationToken cancellationToken );

    /// <summary>
    /// Attempts to log in a user based on the provided phone number credentials.
    /// </summary>
    /// <param name="dto">The <see cref="PhoneNumberLoginRecord"/> containing user login information, including phone number and password.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while processing the login request.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous login operation. The task result is a <see cref="OneOf{T0, T1}"/> representing either
    /// a successful login with an <see cref="ServiceSuccess"/> or an error with a <see cref="ServiceError"/>.
    /// </returns>
    Task<OneOf<ServiceSuccess, ServiceError>> LoginWithPhoneNumber ( PhoneNumberLoginRecord dto, string consumerName, CancellationToken cancellationToken );

    /// <summary>
    /// Attempts to log in a user based on the provided email credentials.
    /// </summary>
    /// <param name="dto">The <see cref="EmailLoginRecord"/> containing user login information, including email and password.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while processing the login request.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous login operation. The task result is a <see cref="OneOf{T0, T1}"/> representing either
    /// a successful login with an <see cref="ServiceSuccess"/> or an error with a <see cref="ServiceError"/>.
    /// </returns>
    Task<OneOf<ServiceSuccess, ServiceError>> LoginWithEmail( EmailLoginRecord dto, string consumerName, CancellationToken cancellationToken);

    /// <summary>
    /// Attempts to log in a user based on the provided email credentials but only for admin role.
    /// </summary>
    /// <param name="dto">The <see cref="EmailUserLoginDTO"/> containing user login information, including email and password.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while processing the login request.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous login operation. The task result is a <see cref="OneOf{T0, T1}"/> representing either
    /// a successful login with an <see cref="ServiceSuccess"/> or an error with a <see cref="ServiceError"/>.
    /// </returns>
    Task<OneOf<ServiceSuccess, ServiceError>> AdminLoginWithEmail(EmailLoginRecord dto, string consumerName, CancellationToken cancellationToken);

    /// <summary>
    /// Registers a new user with the provided sign-up information.
    /// </summary>
    /// <param name="dto">The <see cref="UserSignUpDTO"/> containing user registration information, including username, email, and password.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while processing the registration request.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous registration operation. The task result is either a successful registration or an error,
    /// and specific details can be obtained by awaiting the task.
    /// </returns>
    Task<OneOf<ServiceSuccess, ServiceError>> Register( SignUpRecord dto, string consumerName, CancellationToken cancellationToken );

    /// <summary>
    /// Changes the password for the authenticated user.
    /// </summary>
    /// <param name="dto">The <see cref="ChangePasswordDTO"/> containing information for changing the password, including the current password and the new password.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while processing the password change request.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous password change operation. The task result is a <see cref="OneOf{T0, T1}"/> representing either
    /// a successful password change with a <see cref="ServiceSuccess"/> or an error with a <see cref="ServiceError"/>.
    /// </returns>
    Task<OneOf<ServiceSuccess, ServiceError>> ChangePasswordAsync(string userId, string currentPassword, string newPassword, string consumerName, CancellationToken cancellationToken);
}