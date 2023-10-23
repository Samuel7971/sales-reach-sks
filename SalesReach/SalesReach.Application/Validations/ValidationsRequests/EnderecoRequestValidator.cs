using FluentValidation;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Validations.ValidationsRequests
{
    public class EnderecoRequestValidator : AbstractValidator<EnderecoRequestModel>
    {
        public EnderecoRequestValidator()
        {
            RuleFor(x => x.PessoaId)
                .GreaterThan(0).WithMessage("PessoaId é requerido.");
            RuleFor(x => x.CEP)
                .NotEmpty().NotNull().WithMessage("CEP é requerido.")
                .Length(8).WithMessage("CEP informado é inválido.");
            RuleFor(x => x.Logradouro)
                .NotNull().NotEmpty().WithMessage("Logradouro é requerido.");
            RuleFor(x => x.Numero)
                .NotNull().NotEmpty().WithMessage("Número é requerido.");
            RuleFor(X => X.Bairro)
                .NotEmpty().NotNull().WithMessage("Bairro é requerido.");
            RuleFor(x => x.UF)
                .NotNull().NotEmpty().WithMessage("UF informado é inválido.")
                .Length(2).WithMessage("UF informado é inválido.");
        }
    }
}
