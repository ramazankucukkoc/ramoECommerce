using Application.Features.Personels.Command.CreatePersonel;
using FluentValidation;

namespace Application.Features.Personels.Validator
{
    public class CreatePersonelCommandValidator:AbstractValidator<CreatePersonelCommand>
    {
        public CreatePersonelCommandValidator()
        {
            RuleFor(p => p.Gorsel).Must(EsImagen).WithMessage("Wrong format file. It must be an image.");
        }
        private bool EsImagen(string imagen)
        {
            return imagen != null ? imagen.EndsWith(".jpg") || imagen.EndsWith(".png") : true;
        }
    }
   
}
