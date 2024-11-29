using System.Security.Claims;

namespace BookstoreApp.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole("Admin");
        }
    }
}
