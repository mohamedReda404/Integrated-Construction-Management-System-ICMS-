

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class AuthServices(UserManager<ApplicationUser> userManager,JwtProvider jwtProvider,AppDbContext appDbContext) : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly JwtProvider _jwtProvider = jwtProvider;
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<Authresponce?> Login(string Email, string Password, CancellationToken cancellationToken)
        {
          var user=await _userManager.FindByNameAsync(Email);
            if (user is null) { return null; }

            var isvalidPassword = await _userManager.CheckPasswordAsync(user, Password);
            if (isvalidPassword) { return null; }

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            return new Authresponce(user.Id,user.Email!,token,expiresIn);

        }

        public async Task<Authresponce?> Rejester(RejesterRequest user, CancellationToken cancellationToken)
        {
            var appUser = user.Adapt<ApplicationUser>();

            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (!result.Succeeded)
                return null;

            var (token, expiresIn) = _jwtProvider.GenerateToken(appUser);

            return new Authresponce(appUser.Id, appUser.Email!, token, expiresIn);
        }
    }
}
