using FluentValidation;

namespace SistemaDeGestaoEscolar.ViewModel
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                .Length(1, 256).WithMessage("{PropertyName} deve ter até 256 caracteres")
                .EmailAddress().WithMessage("{PropertyName} deve ser um email válido");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("{PropertyName} deve ser preenchida")
                .Length(6, 100).WithMessage("{PropertyName} deve ter no mínimo {MinLength} caracteres");
        }
    }
}