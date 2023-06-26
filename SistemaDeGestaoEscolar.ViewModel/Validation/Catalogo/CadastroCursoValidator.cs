using FluentValidation;

namespace SistemaDeGestaoEscolar.ViewModel
{
    public class CadastroCursoValidator : AbstractValidator<CadastroCursoViewModel>
        {
        public CadastroCursoValidator()
        {
            When(model => model.Saving, () =>
            {
                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                    .Length(1, 100).WithMessage("{PropertyName} deve ter até 100 caracteres");

                RuleFor(x => x.Requisito)
                   .NotEmpty().WithMessage("{PropertyName} deve ser preenchido")
                   .Length(1, 100).WithMessage("{PropertyName} deve ter até 100 caracteres");

                RuleFor(x => x.Carga_Horaria)
                   .NotEmpty().WithMessage("{PropertyName} deve ser preenchido").WithMessage("{PropertyName} deve ter até 100 caracteres");
            });
        }
    }
}
