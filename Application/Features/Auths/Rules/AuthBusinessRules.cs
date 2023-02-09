using Application.Features.Auths.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Security.GoogleAuth;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new BusinessException(AuthBusinessExceptionMessages.UserDontExists);
            return Task.CompletedTask;
        }
        public async Task UserEmailShouldBeActive(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException(AuthBusinessExceptionMessages.UserMailAlreadyExists);
        }
        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(AuthBusinessExceptionMessages.PasswordDontMatch);
        }
        public async Task UsersGoogleMailShouldBeVerified(GoogleUserDetails googleUserDetails)
        {
            if (googleUserDetails.EmailVerified == false) throw new BusinessException("Google mail has to be verified.");
        }

        public Task UserShouldNotBeHaveAuthenticator(User user)
        {
            if (user.AuthenticatorType != AuthenticatorType.None)
                throw new BusinessException(AuthBusinessExceptionMessages.UserHaveAlreadyAuthenticator);
            return Task.CompletedTask;

        }
    }
}
