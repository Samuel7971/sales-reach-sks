using FluentValidation;
using SalesReach.Application.Models;

namespace SalesReach.Application.Validations
{
    public class PessoaContatoValidator : AbstractValidator<ContatoModel>
    {
        public PessoaContatoValidator()
        {
            RuleFor(x => x.PessoaId)
                .GreaterThan(0).WithMessage("Informe PessoaId.");

            RuleFor(x => x.TelefoneTipoId)
                .GreaterThan(0).WithMessage("Informe Telefone Tipo Id.");

            RuleFor(x => x.Telefone)
                .NotEmpty().NotNull().WithMessage("Informe Telefone.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("E-mail informado é inválido.")
                .NotNull().NotEmpty().WithMessage("Informe E-mail.");
        }
    }
}
