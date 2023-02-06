using System.Security.Claims;

namespace Core.Security.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims("Role");
        }
        //FirstOrDefault dememizin sebebi kullanıcının sadece bir adı bir emaili bir UserId'si olamsıdır.
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal?.Claims("UserId")?.FirstOrDefault());
        }
        public static string? GetName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims("Name")?.FirstOrDefault();
        }
        public static string? GetLastName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims("LastName")?.FirstOrDefault();
        }
        public static string? GetEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims("Email")?.FirstOrDefault();
        }
    }
}
