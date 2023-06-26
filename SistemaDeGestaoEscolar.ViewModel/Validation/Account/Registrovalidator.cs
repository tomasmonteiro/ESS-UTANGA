using FluentValidation;
using SistemaDeGestaoEscolar.ViewModel;

namespace SistemaDeGestaoEscolar.Validation
{
    public class RegistroValidator : AbstractValidator<RegistroViewModel>
    {
        public RegistroValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                .Length(1, 256).WithMessage("{PropertyName} deve ter até 256 caracteres")
                .EmailAddress().WithMessage("{PropertyName} deve ser um email válido");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                .Length(1, 256).WithMessage("{PropertyName} deve ter até 256 caracteres");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("{PropertyName} deve ser preenchida")
                .Length(6, 100).WithMessage("{PropertyName} deve ter no mínimo {MinLength} caracteres");

            RuleFor(x => x.SenhaConfirmacao)
                .Equal(x => x.Senha).WithMessage("{PropertyName} deve ser igual à {ComparisonValue}").WithName("Confirmação da Senha");
        }
    }
}
