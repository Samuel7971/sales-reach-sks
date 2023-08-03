﻿using FluentValidation;
using SalesReach.Application.Models;

namespace SalesReach.Application.Validations
{
    public class PessoaValidator : AbstractValidator<PessoaModel>
    {
        public PessoaValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty().NotNull().WithMessage("O nome é requerido.")
                .MinimumLength(5).WithMessage("É preciso ter mais que 5 caracteres no nome.")
                .MaximumLength(100).WithMessage("Nome não pode ter mais que 100 caracteres.");
            RuleFor(x => x.PessoaTipoId)
                .ExclusiveBetween(1, 2).WithMessage("Tipo Pessoa não cadastrado.");
            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage($"Data Nascimento é requerido.")
                .LessThan(DateTime.Now.AddYears(-16)).WithMessage("Pessoa menor que 16 anos");
        }
    }
}