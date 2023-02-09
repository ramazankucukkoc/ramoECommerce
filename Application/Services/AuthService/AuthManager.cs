using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.EmailAuthenticator;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly TokenOptions _tokenOptions;
        private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper,
            IRefreshTokenRepository refreshTokenRepository, IEmailAuthenticatorHelper emailAuthenticatorHelper,IConfiguration configuration)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _emailAuthenticatorHelper = emailAuthenticatorHelper;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken token = await _refreshTokenRepository.AddAsync(refreshToken);
            return token;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u => u.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(x => new OperationClaim
                {
                    Id = x.OperationClaim.Id,
                    Name = x.OperationClaim.Name,
                }).ToArray();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
        {
            EmailAuthenticator emailAuthenticator = new()
            {
                UserId = user.Id,
                ActivationKey = await _emailAuthenticatorHelper.CreateEmailActivationKey(),
                IsVerified = false
            };
            return emailAuthenticator;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }

        public async Task DeleteRefreshTokens(int userId)
        {
            IList<RefreshToken> refreshTokens = (await _refreshTokenRepository.GetListAsync(r =>
            r.UserId == userId &&
            r.Revoked == null && r.Expires >= DateTime.UtcNow &&
            r.Created.AddDays(_tokenOptions.RefreshTokenTTL) <=
            DateTime.UtcNow)).Items;
            foreach(RefreshToken refreshToken in refreshTokens)await _refreshTokenRepository.DeleteAsync(refreshToken);
        }
    }
}
