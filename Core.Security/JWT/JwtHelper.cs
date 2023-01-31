using Core.Domain.Entities;
using Core.Security.Encryption;
using Core.Security.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //Microsoft.Extensions.Configuration.Binder Get<> işelemrinde yükleniyor!!!!
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public RefreshToken CreateRefreshToken(User user, string ipAddress)
        {
          
            throw new NotImplementedException();

        }

        public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials,operationClaims);
            JwtSecurityTokenHandler handler = new();
            string? token = handler.WriteToken(jwt);
           AccessToken accessToken = new() { Token=token,Expiration=_accessTokenExpiration};
            return accessToken;
        }


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,
            SigningCredentials signingCredentials,IList<OperationClaim> operationClaims)
        {
            JwtSecurityToken jwt = new(
               issuer: tokenOptions.Issuer,
               audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetCliams(user, operationClaims),
                signingCredentials:signingCredentials);
            return jwt;
        }
        private IEnumerable<Claim>SetCliams(User user,IList<OperationClaim> operationClaims)
        {
            List<Claim> claims = new();
            claims.AddNameIdentfier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName(user.FirstName);
            claims.AddLastName(user.LastName);
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
    }
}
