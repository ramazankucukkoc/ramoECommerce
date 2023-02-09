﻿using Core.Domain.Entities;
using Core.Security.JWT;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
        Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task DeleteRefreshTokens(int userId);
        Task<EmailAuthenticator> CreateEmailAuthenticator(User user);
    }
}
