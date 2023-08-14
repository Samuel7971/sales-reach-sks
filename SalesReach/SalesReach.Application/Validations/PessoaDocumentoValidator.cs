using FluentValidation;
using SalesReach.Application.Models;
using SalesReach.Application.Models.InserirModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Validations
{
    public class PessoaDocumentoValidator : AbstractValidator<DocumentoInserirModel>
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
