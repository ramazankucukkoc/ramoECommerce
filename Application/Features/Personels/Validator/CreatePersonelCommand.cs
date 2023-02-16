using Application.Features.Personels.Command.CreatePersonel;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Personels.Validator
{
    public class CreatePersonelCommandValidator:AbstractValidator<CreatePersonelCommand>
    {
        public CreatePersonelCommandValidator()
        {
            RuleFor(p => p.Gorsel).EsImagen();
        }
       
    }
   
}
