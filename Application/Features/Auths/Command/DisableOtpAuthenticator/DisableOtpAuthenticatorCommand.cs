﻿using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Auths.Command.DisableOtpAuthenticator
{
    public class DisableOtpAuthenticatorCommand : IRequest
    {
        public int UserId { get; set; }

        public class DisableOtpAuthenticatorCommandHandler : IRequestHandler<DisableOtpAuthenticatorCommand>
        {
            private readonly IUserService _userService;
            private IAuthService _authService;
            private AuthBusinessRules _authBusinessRules;

            public DisableOtpAuthenticatorCommandHandler(IUserService userService,
                IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<Unit> Handle(DisableOtpAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetById(request.UserId);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserShouldBeHaveAuthenticator(user);
                user.AuthenticatorType = Core.Domain.Enums.AuthenticatorType.None;
                await _authService.DeleteOldOtpAuthenticators(user);
                await _userService.Update(user);
                return Unit.Value;
            }
        }
    }
}
