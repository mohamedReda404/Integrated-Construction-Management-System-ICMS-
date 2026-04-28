using Azure.Core;
using Integrated_Construction_Management_System_ICMS.Abstractions;
using Integrated_Construction_Management_System_ICMS.Authentication;
using Integrated_Construction_Management_System_ICMS.Errors;
using Microsoft.AspNetCore.Identity;

using System.Security.Cryptography;
using RegisterRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.RegisterRequest;


namespace Integrated_Construction_Management_System_ICMS.Services;

public class AuthService(UserManager<ApplicationUser> userManager,
    IJwtProvider jwtProvider,
    AppDbContext appDbContext) : IAuthService


{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly AppDbContext _appDbContext= appDbContext;

    private readonly int _refreshTokenExpiryDays = 14;

    public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        var isValidPassword = await _userManager.CheckPasswordAsync(user, password);

        if (!isValidPassword)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials); ;

        var (token, expiresIn) = _jwtProvider.GenerateToken(user);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await _userManager.UpdateAsync(user);

        var response = new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn, refreshToken, refreshTokenExpiration);

        return Result.Success(response);
    }

    public async Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);

        if (userId is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidJwtToken);

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidJwtToken);

        var userRefreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

        if (userRefreshToken is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidRefreshToken);

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        var (newToken, expiresIn) = _jwtProvider.GenerateToken(user);
        var newRefreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = newRefreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await _userManager.UpdateAsync(user);

        var response = new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, newToken, expiresIn, newRefreshToken, refreshTokenExpiration);

        return Result.Success(response);
    }

    public async Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtProvider.ValidateToken(token);

        if (userId is null)
            return Result.Failure(UserErrors.InvalidJwtToken);

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return Result.Failure(UserErrors.InvalidJwtToken);

        var userRefreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);

        if (userRefreshToken is null)
            return Result.Failure(UserErrors.InvalidRefreshToken);

        userRefreshToken.RevokedOn = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return Result.Success();
    }

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public async Task<Result<AuthResponse>> RegisterAsync(
     RegisterRequest request,
     CancellationToken cancellationToken = default)
    {
       
        var emailExists = await _userManager.Users
            .AnyAsync(x => x.Email == request.Email, cancellationToken);

        if (emailExists)
            return Result.Failure<AuthResponse>(UserErrors.DuplicatedEmail);

        
        var user = request.Adapt<ApplicationUser>();

      
        user.UserName = request.Email;

        user.EmailConfirmed = true;

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return Result.Failure<AuthResponse>(
                new Error("UserCreationFailed", errors));
        }

        var (token, expiresIn) = _jwtProvider.GenerateToken(user);

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await _userManager.UpdateAsync(user);

        // 6. Response
        var response = new AuthResponse(
            user.Id,
            user.Email!,
            user.FirstName,
            user.LastName,
            token,
            expiresIn,
            refreshToken,
            refreshTokenExpiration
        );

        return Result.Success(response);
    }

    public async Task<Result<AuthResponse>> RegisterAsyncMember(AddMembersRequest request, CancellationToken cancellationToken = default)
    {
        var emailExists = await _userManager.Users
            .AnyAsync(x => x.Email == request.Email, cancellationToken);

        if (emailExists)
            return Result.Failure<AuthResponse>(UserErrors.DuplicatedEmail);


        var user = request.Adapt<ApplicationUser>();


        user.UserName = request.Email;

        user.EmailConfirmed = true;

        var result = await _userManager.CreateAsync(user, request.PermissionNumber);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return Result.Failure<AuthResponse>(
                new Error("UserCreationFailed", errors));
        }

        var (token, expiresIn) = _jwtProvider.GenerateToken(user);

        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await _userManager.UpdateAsync(user);

        // 6. Response
        var response = new AuthResponse(
            user.Id,
            user.Email!,
            user.FirstName,
            user.LastName,
            token,
            expiresIn,
            refreshToken,
            refreshTokenExpiration
        );

        return Result.Success(response);
    }

    public async Task<Result<AuthResponse>> GetTokenMemberAsync(string email, string PermissionNumber, string Section, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        var isValidPassword = await _userManager.CheckPasswordAsync(user, PermissionNumber);

        if (!isValidPassword)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials); ;

        var (token, expiresIn) = _jwtProvider.GenerateToken(user);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiration
        });

        await _userManager.UpdateAsync(user);

        var response = new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn, refreshToken, refreshTokenExpiration);

        return Result.Success(response);
    }

    public async Task<int> NumbrOfMemebers(CancellationToken cancellationToken = default)
    {
       var countResult=await _userManager.Users.Where(s=>s.Section!=" ").CountAsync(cancellationToken);
        return countResult;
    }

    public async Task<AccountInfoReponse> Getprofile(string UserId, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.Users.
            Where(x=>x.Id==UserId)
            .SingleAsync();

        return (user.Adapt<AccountInfoReponse>());
    }

    public async Task<Result> UpdateUserprofile(string UserId, UpdateAccountUserRequest updateAccountUserRequest, CancellationToken cancellationToken = default)
    {
        await _userManager.Users
           .Where(x => x.Id == UserId)
           .ExecuteUpdateAsync(setters =>
               setters
                   .SetProperty(x => x.FirstName, updateAccountUserRequest.FirstName)
                   .SetProperty(x => x.LastName, updateAccountUserRequest.LastName)
           );

        return Result.Success();
    }
}