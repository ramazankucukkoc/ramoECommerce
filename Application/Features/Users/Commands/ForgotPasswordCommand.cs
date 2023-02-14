using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Application.Extensions;
using Core.Domain.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class ForgotPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }

        public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;

            public ForgotPasswordCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserEmailShouldExistsWhenSelected(request.Email);
                User? user = await _userRepository.GetAsync(f => f.Email == request.Email);

                var generatedPassword = RandomPasswordExtensions.CreateRandomPassword(14);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(generatedPassword, out passwordHash, out passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                await _userRepository.UpdateAsync(user);
                return $"Password unutunuz sisteme yeni şifre ile giriş yapabilrisiniz :{generatedPassword}";

            }
        }
    }
}
