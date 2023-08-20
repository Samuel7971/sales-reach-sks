using FluentValidation;
using SalesReach.Application.Models;

namespace SalesReach.Application.Validations
{
    public class PessoaDocumentoValidator : AbstractValidator<PessoaDocumentoModel>
    {
        public PessoaDocumentoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id informado é inválido.");
            RuleFor(x => x.DocumentoTipoId)
                .GreaterThan(0).WithMessage("Tipo Documento é requerido.");
            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().NotNull().WithMessage("Número do documento é requerido.");
        }
    }
}
