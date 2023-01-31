using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Core.Security.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
            => claims.Add(new Claim("Email", email));

        public static void AddName(this ICollection<Claim> claims, string name)
            => claims.Add(new Claim("Name", name));

        public static void AddLastName(this ICollection<Claim> claims, string lastName)
           => claims.Add(new Claim("LastName", lastName));
        public static void AddNameIdentfier(this ICollection<Claim> claims,string nameIdentifier)
            =>claims.Add(new Claim("UserId", nameIdentifier));

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
            => roles.ToList().ForEach(role => claims.Add(new Claim("Role", role)));

        //yeni eklendi.TCNO için kullanılabilir.
        public static void AddNameUniqueIdentifier(this ICollection<Claim> claims,string nameUniqueIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.SerialNumber, nameUniqueIdentifier));
        }
    }
}
