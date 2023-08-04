using FluentValidation;
using SalesReach.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Validations
{
    public class EnderecoValidator : AbstractValidator<EnderecoModel>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.CEP)
                .NotEmpty().NotNull().WithMessage("CEP é requerido.")
                .MaximumLength(8).WithMessage("CEP informado é inválido.")
                .MinimumLength(8).WithMessage("CEP informado é inválido.");

        }
    }
}
