using FluentValidation;
using SalesReach.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Validations
{
    public class PessoaDocumentoValidator : AbstractValidator<PessoaDocumentoModel>
    {
        public PessoaDocumentoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id é requerido.")
                .LessThanOrEqualTo(0).WithMessage("Id informado é inválido.");
            RuleFor(x => x.DocumentoTipoId)
                .LessThanOrEqualTo(0).WithMessage("Tipo Documento é requerido.");
            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().NotNull().WithMessage("Número do documento é requerido.");
        }
    }
}
