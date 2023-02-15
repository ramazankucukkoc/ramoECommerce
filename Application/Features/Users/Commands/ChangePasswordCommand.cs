using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class ChangePasswordCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, string>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;

            public ChangePasswordCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(x => x.Id == request.UserId);
                await _authBusinessRules.UserShouldBeExists(user);

                byte[] passwordHash, passwordSalt;

                await _authBusinessRules.UserPasswordShouldBeMatch(request.UserId, request.NewPassword.Trim());
                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _userRepository.UpdateAsync(user);
                return "Şifre değiştirme işlemi başarılı şekilde tamamlandı";

            }
        }

    }
}
