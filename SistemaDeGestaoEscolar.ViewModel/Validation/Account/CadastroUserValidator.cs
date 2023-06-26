using FluentValidation;
using SistemaDeGestaoEscolar.ViewModel;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class CadastroUserValidator : AbstractValidator<CadastroUserViewModel>
    {
        public CadastroUserValidator()
        {
            When(model => model.Saving, () =>
            {
                RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                    .Length(1, 256).WithMessage("{PropertyName} deve ter até 256 caracteres")
                    .EmailAddress().WithMessage("{PropertyName} deve ser um email válido");

                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                    .Length(1, 200).WithMessage("{PropertyName} deve ter até 200 caracteres");

                RuleFor(x => x.Perfil)
                    .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} deve ser preenchido");

                //RuleFor(x => x.Senha)
                //    .NotEmpty().WithMessage("{PropertyName} deve ser preenchida")
                //    .Length(6, 100).WithMessage("{PropertyName} deve ter no mínimo {MinLength} caracteres");

                //RuleFor(x => x.SenhaConfirmacao)
                //    .Equal(x => x.Senha).WithMessage("{PropertyName} deve ser igual à {ComparisonValue}").WithName("Confirmação da Senha");
            });
        }
    }
}