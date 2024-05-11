﻿//using Azure.Core;
//using CommunityToolkit.Diagnostics;

namespace IdentitySystem.ServiceProvider;

public class AuthenticationService : IAuthenticationService
{
    #region [ Fields ]
    private readonly IUserDataProvider UserDataProvider;
    //private readonly IRoleDataProvider RoleDataProvider;
    private readonly IJwtTokenService JwtTokenService;
   // private readonly IIdentityMediaService identityMediaService;
    private readonly IdentitySystemDbContext DbContext;
    #endregion

    #region [ CTor ]
    public AuthenticationService( IUserDataProvider userDataProvider,
                                  //IRoleDataProvider roleDataProvider,
                                  IJwtTokenService jwtTokenService,
                                  IdentitySystemDbContext dbContext )
    {
        this.UserDataProvider = userDataProvider;
        //this.RoleDataProvider = roleDataProvider;
        this.JwtTokenService = jwtTokenService;
        this.DbContext = dbContext;
    }
    #endregion

    #region [ Methods ]

    public async Task<OneOf<ServiceSuccess, ServiceError>> Login(UserLogin dto,
                                                                 string consumerName,
                                                                 CancellationToken cancellationToken = default)
    {
        //Guard.IsNotNull(dto);

        var user = await UserDataProvider.FindByNameAsync(dto.username);
        if (user is null)
            return new ServiceError(nameof(AuthenticationService), nameof(Login))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };

        var passwordCheck = await UserDataProvider.CheckPasswordSignInAsync(user, dto.password, LoginMode.Email, false);
        if (!passwordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(Login))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };

        var requestAt = DateTime.UtcNow;
        var expiredIn = requestAt.AddDays(1);   // TODO: define expire time
        //var accessToken = JwtTokenService.GenerateToken(user, requestAt, expiredIn);
        // TODO: define refresh token


        return new ServiceSuccess(nameof(AuthenticationService), nameof(Login), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_LOGGED_IN_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow,
            //AttachedData = new AuthenticatedResponse(user.Id, requestAt, accessToken, expiredIn)
        };
    }

    public async Task<OneOf<ServiceSuccess, ServiceError>> LoginWithPhoneNumber(PhoneNumberUserLogin dto,
                                                                                string consumerName,
                                                                                CancellationToken cancellationToken)
    {
        //Guard.IsNotNull(dto);

        var user = await UserDataProvider.FindByPhoneNumberAsync(dto.phoneNumber);
        if (user is null)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithPhoneNumber))
            {
                ErrorMessage = IdentityConstants.USER_NOT_FOUND,
                ErrorCode = nameof(IdentityConstants.USER_NOT_FOUND),
                EventOccuredAt = DateTime.Now
            };
        var passwordCheck = await UserDataProvider.CheckPasswordSignInAsync(user, dto.password, LoginMode.PhoneNumber, false, cancellationToken);
        if (!passwordCheck.Succeeded)
            return new ServiceError(nameof(AuthenticationService), nameof(LoginWithPhoneNumber))
            {
                ErrorMessage = IdentityConstants.PASSWORD_INVALID,
                ErrorCode = nameof(IdentityConstants.PASSWORD_INVALID),
                EventOccuredAt = DateTime.Now
            };
        var requestAt = DateTime.UtcNow;
        var expiredIn = requestAt.AddDays(1);   // TODO: define expire time
        //var accessToken = JwtTokenService.GenerateToken(user, requestAt, expiredIn);

        return new ServiceSuccess(nameof(AuthenticationService), nameof(Login), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_LOGGED_IN_WITH_PHONE_NUMBER_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow,
            //AttachedData = new AuthenticatedResponse(user.Id, requestAt, accessToken, expiredIn)
        };
    }

    public async Task<OneOf<ServiceSuccess, ServiceError>> Register(UserSignUp dto, string consumerName, CancellationToken cancellationToken = default)
    {
        //Guard.IsNotNull(dto);

        using var transaction = await DbContext.Database.BeginTransactionAsync(cancellationToken);

        UserDTO user = new()
        {
            //Email = dto.email,
            UserName = dto.userName,
            FirstName = dto.firstName,
            LastName = dto.lastName,
            //PhoneNumber = dto.phoneNumber ?? dto.phoneNumber
        };
        user.CreatedOn = DateTime.UtcNow;

        //var createResult = await UserDataProvider.CreateAsync(user, dto.password);

        //if (createResult.Errors.Any())
        //    return new ServiceError(nameof(AuthenticationService), nameof(LoginWithPhoneNumber))
        //    {
        //        ErrorMessage = string.Join(", ", createResult.Errors.Select(error => error.Description)),
        //        ErrorCode = createResult.Errors
        //                            .Sum(error => int.Parse(error.Code))
        //                            .ToString(),
        //        EventOccuredAt = DateTime.Now
        //    };


        //To do
        //if (dto.AvatarFile is not null && identityMediaService.IsImage(dto.AvatarFile!))
        //{
        //    var uploadedAvatarInfomation = await identityMediaService.UploadFileAsync(dto.AvatarFile, cancellationToken);
        //    user.ProfileImageUrl = uploadedAvatarInfomation.MediaUrl;
        //    await petaverseUserRepository.UpdateAsync(user);
        //}

        await transaction.CommitAsync(cancellationToken);
        return new ServiceSuccess(nameof(AuthenticationService), nameof(Login), consumerName)
        {
            SuccessMessage = IdentityConstants.USER_CREATED_SUCCESSFULLY,
            EventOccuredAt = DateTime.UtcNow
        };
    }
    #endregion

}