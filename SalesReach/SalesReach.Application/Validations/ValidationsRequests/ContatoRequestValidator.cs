using FluentValidation;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Validations.ValidationsRequests
{
    public class ContatoRequestValidator : AbstractValidator<ContatoRequestModel>
    {
        public ContatoRequestValidator()
        {
            RuleFor(x => x.PessoaId)
                .GreaterThan(0).WithMessage("Informe PessoaId.");
            RuleFor(x => x.TelefoneTipo)
                .NotEmpty().NotNull().WithMessage("Informe Telefone Tipo.");
            RuleFor(x => x.Telefone)
                .NotEmpty().NotNull().WithMessage("Informe Telefone.");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("E-mail informado é inválido.")
                .NotNull().NotEmpty().WithMessage("Informe E-mail.");
        }
    }
}
