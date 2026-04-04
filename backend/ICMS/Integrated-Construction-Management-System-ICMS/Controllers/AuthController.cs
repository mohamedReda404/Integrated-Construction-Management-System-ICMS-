//using Integrated_Construction_Management_System_ICMS.Contracts.Authrization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Integrated_Construction_Management_System_ICMS.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class AuthController(IAuthServices authServices) : ControllerBase
//    {
//        private readonly IAuthServices _authServices = authServices;

//        [HttpPost("Login")]
//        public async Task<IActionResult> Login(LoginReques reques,CancellationToken cancellationToken)
//        {
//            var authresult=await _authServices.Login(reques.Email,reques.password, cancellationToken);

//            return authresult is null ? BadRequest("Invalid Email or Passord") : Ok(authresult);
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RejesterRequest request, CancellationToken cancellationToken)
//        {
//            var authResult = await _authServices.Rejester(request, cancellationToken);

//            if (authResult is null)
//                return BadRequest("Registration failed");

//            return Ok(authResult);
//        }
//    }
//}
