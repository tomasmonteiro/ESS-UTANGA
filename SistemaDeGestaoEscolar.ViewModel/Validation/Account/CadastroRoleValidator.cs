using FluentValidation;
using SistemaDeGestaoEscolar.ViewModel;

namespace SistemaDeGestaoEscolar.WebApp
{
    public class CadastroRoleValidator : AbstractValidator<CadastroRoleViewModel>
    {
        public CadastroRoleValidator()
        {
            When(model => model.Saving, () =>
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                    .Length(1, 256).WithMessage("{PropertyName} deve ter até 256 caracteres");
            });
        }
    }
}