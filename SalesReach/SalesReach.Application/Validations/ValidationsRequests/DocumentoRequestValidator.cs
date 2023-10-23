using FluentValidation;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Validations.ValidationsRequests
{
    public class DocumentoRequestValidator : AbstractValidator<DocumentoRequestModel>
    {
        public DocumentoRequestValidator() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id informado é inválido.");
            RuleFor(x => x.DocumentoTipo)
                .NotNull().NotEmpty().WithMessage("Tipo Documento é requerido.");
            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().NotNull().WithMessage("Número do documento é requerido.");
        }
    }
}
