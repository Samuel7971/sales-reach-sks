﻿using FluentValidation;
using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Validations
{
    public class PessoaValidator : AbstractValidator<PessoaModel>
    {
        public PessoaValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id é requerido.");
            RuleFor(x => x.Nome)
                .NotEmpty().NotNull().WithMessage("O nome é requerido.")
                .MinimumLength(5).WithMessage("É preciso ter mais que 5 caracteres no nome.")
                .MaximumLength(100).WithMessage("Nome não pode ter mais que 100 caracteres.");
            RuleFor(x => x.PessoaTipoId)
                .GreaterThan(0).LessThan(3).WithMessage("Tipo Pessoa não cadastrado.");
            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage($"Data Nascimento é requerido.")
                .LessThan(DateTime.Now.AddYears(-16)).WithMessage("Pessoa menor que 16 anos");
        }
    }
}
