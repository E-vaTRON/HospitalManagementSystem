//using Azure.Core;
//using CommunityToolkit.Diagnostics;

using IdentitySystem.Application;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace IdentitySystem.ServiceProvider;

public class AuthenticationService : IAuthenticationService
{
    #region [ Fields ]
    private readonly IMapper Mapper;
    private readonly IUserServiceProvider UserServiceProvider;
    private readonly IDatabaseServiceProvider DatabaseServiceProvider;
    private readonly IJwtTokenService JwtTokenService;
    #endregion

    #region [ CTor ]
    public AuthenticationService( IMapper mapper,
                                  IUserServiceProvider userServiceProvider,
                                  IDatabaseServiceProvider databaseServiceProvider,
                                  IJwtTokenService jwtTokenService )
    {
        Mapper = mapper;
        UserServiceProvider = userServiceProvider;
        DatabaseServiceProvider = databaseServiceProvider;
        JwtTokenService = jwtTokenService;
    }
    #endregion

    #region [ Public - Methods ]
    public async Task<OneOf<ServiceSuccess, ServiceError>> LoginWithUserName( UserNameLoginRecord dto,  string consumerName, CancellationToken cancellationToken = default)
    {
        //Guard.IsNotNull(dto);
        ArgumentNullException.ThrowIfNull(dto, nameof(UserNameLoginRecord));
        
        var userDtoOut = await UserServiceProvider.FindByNameAsync(dto.userName.ToUpper());
        if (userDtoOut is null)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithUserName))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };

        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);
        var passwordCheck = await UserServiceProvider.CheckPasswordSignInAsync(userDtoIn, dto.password, LoginMode.UserName, false);
        if (!passwordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithUserName))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };

        var requestAt = DateTime.UtcNow;
        var expiredIn = requestAt.AddDays(1);   // TODO: define expire time
        var accessToken = JwtTokenService.GenerateToken(userDtoIn, requestAt, expiredIn);
        // TODO: define refresh token

        return new ServiceSuccess(nameof(AuthenticationService), nameof(LoginWithUserName), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_LOGGED_IN_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow,
            AttachedData = new AuthenticatedResponse(userDtoIn.Id, requestAt, accessToken, expiredIn)
        };
    }

    public async Task<OneOf<ServiceSuccess, ServiceError>> LoginWithPhoneNumber(PhoneNumberLoginRecord dto, string consumerName, CancellationToken cancellationToken)
    {
        //Guard.IsNotNull(dto);
        ArgumentNullException.ThrowIfNull(dto, nameof(PhoneNumberLoginRecord));

        var userDtoOut = await UserServiceProvider.FindByPhoneNumberAsync(dto.phoneNumber);
        if (userDtoOut is null)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithPhoneNumber))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };

        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);
        var passwordCheck = await UserServiceProvider.CheckPasswordSignInAsync(userDtoIn, dto.password, LoginMode.PhoneNumber, false);
        if (!passwordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithPhoneNumber))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };
        var requestAt = DateTime.UtcNow;
        var expiredIn = requestAt.AddDays(1);   // TODO: define expire time
        var accessToken = JwtTokenService.GenerateToken(userDtoIn, requestAt, expiredIn);

        return new ServiceSuccess(nameof(AuthenticationService), nameof(LoginWithPhoneNumber), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_LOGGED_IN_WITH_PHONE_NUMBER_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow,
            AttachedData = new AuthenticatedResponse(userDtoIn.Id, requestAt, accessToken, expiredIn)
        };
    }

    public async Task<OneOf<ServiceSuccess, ServiceError>> LoginWithEmail(EmailLoginRecord dto, string consumerName, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(EmailLoginRecord));

        var userDtoOut = await UserServiceProvider.FindByEmailAsync(dto.email.ToUpper());
        if (userDtoOut is null)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithEmail))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };

        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);
        var passwordCheck = await UserServiceProvider.CheckPasswordSignInAsync(userDtoIn, dto.password, LoginMode.Email, false);
        if (!passwordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithEmail))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };
        var requestAt = DateTime.UtcNow;
        var expiredIn = requestAt.AddDays(1);
        var accessToken = JwtTokenService.GenerateToken(userDtoIn, requestAt, expiredIn);

        return new ServiceSuccess(nameof(AuthenticationService), nameof(LoginWithEmail), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_LOGGED_IN_WITH_PHONE_NUMBER_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow,
            AttachedData = new AuthenticatedResponse(userDtoIn.Id, requestAt, accessToken, expiredIn)
        };
    }
    public async Task<OneOf<ServiceSuccess, ServiceError>> AdminLoginWithEmail(EmailLoginRecord dto, string consumerName, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(EmailLoginRecord));

        var userDtoOut = await UserServiceProvider.FindByEmailAsync(dto.email.ToUpper());
        if (userDtoOut is null)
            return new ServiceError(nameof(AuthenticationService), nameof(AdminLoginWithEmail))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };

        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);
        var userRoles = await UserServiceProvider.GetRolesAsync(userDtoIn);

        if (!userRoles.Contains("Admin"))
            return new ServiceError(nameof(AuthenticationService), nameof(AdminLoginWithEmail))
            {
                ErrorMessage = IdentityConstants.USER_IS_NOT_ADMIN,
                ErrorCode = nameof(IdentityConstants.USER_IS_NOT_ADMIN),
                EventOccuredAt = DateTime.Now
            };

        var passwordCheck = await UserServiceProvider.CheckPasswordSignInAsync(userDtoIn, dto.password, LoginMode.Email, false);
        if (!passwordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(AdminLoginWithEmail))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };
        var requestAt = DateTime.UtcNow;
        var expiredIn = requestAt.AddDays(1);
        var accessToken = JwtTokenService.GenerateToken(userDtoIn, requestAt, expiredIn);

        return new ServiceSuccess(nameof(AuthenticationService), nameof(AdminLoginWithEmail), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_LOGGED_IN_WITH_PHONE_NUMBER_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow,
            AttachedData = new AuthenticatedResponse(userDtoIn.Id, requestAt, accessToken, expiredIn)
        };
    }

    public async Task<OneOf<ServiceSuccess, ServiceError>> Register(SignUpRecord dto, string consumerName, CancellationToken cancellationToken = default)
    {
        //Guard.IsNotNull(dto);

        await DatabaseServiceProvider.BeginTransactionAsync(cancellationToken);

        InputUserDTO userCreateDto = new()
        {
            Email = dto.email ?? dto.email,
            UserName = dto.userName,
            FirstName = dto.firstName,
            LastName = dto.lastName,
            PhoneNumber = dto.phoneNumber ?? dto.phoneNumber
        };
        userCreateDto.CreatedOn = DateTime.UtcNow;
        var userDto = Mapper.Map<InputUserDTO>(userCreateDto);
        var createResult = await UserServiceProvider.CreateAsync(userDto, dto.password);

        if (createResult.Errors.Any())
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithPhoneNumber))
            {
                ErrorMessage = string.Join(", ", createResult.Errors.Select(error => error.Description)),
                ErrorCode = createResult.Errors
                                    .Sum(error => int.Parse(error.Code))
                                    .ToString(),
                EventOccuredAt = DateTime.Now
            };


        //To do
        //if (dto.AvatarFile is not null && identityMediaService.IsImage(dto.AvatarFile!))
        //{
        //    var uploadedAvatarInfomation = await identityMediaService.UploadFileAsync(dto.AvatarFile, cancellationToken);
        //    user.ProfileImageUrl = uploadedAvatarInfomation.MediaUrl;
        //    await petaverseUserRepository.UpdateAsync(user);
        //}

        //await transaction.CommitAsync(cancellationToken);
        await DatabaseServiceProvider.CommitTransactionAsync(cancellationToken);
        return new ServiceSuccess(nameof(AuthenticationService), nameof(Register), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_CREATED_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow
        };
    }

    public async Task<OneOf<ServiceSuccess, ServiceError>> ChangePasswordAsync(string userId, string currentPassword, string newPassword, string consumerName, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(userId, nameof(EmailLoginRecord));

        var userDtoOut = await UserServiceProvider.FindByIdAsync(userId);
        if (userDtoOut is null)
            return new ServiceError(nameof(AuthenticationService), nameof(ChangePasswordAsync))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };

        var userDtoIn = Mapper.Map<InputUserDTO>(userDtoOut);
        var oldPasswordCheck = await UserServiceProvider.CheckPasswordSignInAsync(userDtoIn, currentPassword, LoginMode.UserName, false);
        if (!oldPasswordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(ChangePasswordAsync))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };

        await UserServiceProvider.ChangePasswordAsync(userDtoIn, currentPassword, newPassword);
        return new ServiceSuccess(nameof(AuthenticationService), nameof(ChangePasswordAsync), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_CHANGED_PASSWORD_SUCCESSFULLY,
            SuccessCode = nameof(IdentityConstants.USER_CHANGED_PASSWORD_SUCCESSFULLY),
            EventOccuredAt = DateTime.Now
        };
    }
    #endregion

}