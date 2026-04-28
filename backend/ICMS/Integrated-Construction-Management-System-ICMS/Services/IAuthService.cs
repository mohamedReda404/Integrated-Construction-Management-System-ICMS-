using Integrated_Construction_Management_System_ICMS.Abstractions;
using RegisterRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.RegisterRequest;


namespace Integrated_Construction_Management_System_ICMS.Services;

public interface IAuthService
{
    Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> GetTokenMemberAsync(string email, string PermissionNumber,string Section, CancellationToken cancellationToken = default);
    //Task<OneOf<AuthResponse, Error>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    Task<Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    //Task<Result> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> RegisterAsync(
       RegisterRequest request,
       CancellationToken cancellationToken = default);
    Task<Result<AuthResponse>> RegisterAsyncMember(
       AddMembersRequest request,
       CancellationToken cancellationToken = default);
    Task<int> NumbrOfMemebers(CancellationToken cancellationToken = default);
    Task<AccountInfoReponse> Getprofile(string UserId,CancellationToken cancellationToken = default);
    Task<Result> UpdateUserprofile(string UserId, UpdateAccountUserRequest updateAccountUserRequest, CancellationToken cancellationToken = default);
}