using Integrated_Construction_Management_System_ICMS.Abstractions;

namespace Integrated_Construction_Management_System_ICMS.Errors
{
    public static class UserErrors
    {
        public static readonly Error InvalidCredentials =
            new("User.InvalidCredentials", "Invalid email/password");

        public static readonly Error InvalidJwtToken =
            new("User.InvalidJwtToken", "Invalid Jwt token");

        public static readonly Error InvalidRefreshToken =
            new("User.InvalidRefreshToken", "Invalid refresh token");

        public static Error DuplicatedEmail =>
       new("User.DuplicatedEmail", "Email is already registered");
    }
}
