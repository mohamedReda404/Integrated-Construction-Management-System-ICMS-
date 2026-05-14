using Integrated_Construction_Management_System_ICMS.Services;
using LoginRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.LoginRequest;
using RegisterRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.RegisterRequest;

namespace Integrated_Construction_Management_System_ICMS.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{

    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(
    [FromBody] LoginRequest request,
    CancellationToken cancellationToken)
    {
        var result = await _authService.GetTokenAsync(
            request.Email,
            request.Password,
            cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }


    [HttpPost("MemberLogin")]
    public async Task<IActionResult> LoginMemberAsync(
   [FromBody] LoginMemberRequest request,
   CancellationToken cancellationToken)
    {
        var result = await _authService.GetTokenAsync(
            request.Email,
            request.PermissionNumber,
            cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }



    //[HttpPost("refresh")]
    //public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    //{
    //    var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

    //    return authResult.IsSuccess ? Ok(authResult.Value) : Problem(statusCode: StatusCodes.Status400BadRequest, title: authResult.Error.Code, detail: authResult.Error.Description);
    //}

    //[HttpPost("revoke-refresh-token")]
    //public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    //{
    //    var result = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);

    //    return result.IsSuccess ? Ok() : Problem(statusCode: StatusCodes.Status400BadRequest, title: result.Error.Code, detail: result.Error.Description);
    //}
    [HttpPost("register")]
    public async Task<IActionResult> Register(
     [FromBody] RegisterRequest request,
     CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(request, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    
}