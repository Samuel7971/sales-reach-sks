using FluentValidation;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Validations
{
    public class ClienteValidator: AbstractValidator<ClienteRequestModel>
    {
        public ClienteValidator()
        {
            #region .: Pessoa :.
            RuleFor(x => x.Pessoa.Id)
                .GreaterThan(0).WithMessage("Id Pessoa é requerido.");
            RuleFor(x => x.Pessoa.Nome)
                .NotEmpty().NotNull().WithMessage("O nome é requerido.")
                .MinimumLength(5).WithMessage("É preciso ter mais que 5 caracteres no nome.")
                .MaximumLength(100).WithMessage("Nome não pode ter mais que 100 caracteres.");
            RuleFor(x => x.Pessoa.PessoaTipoId)
                .GreaterThan(0).LessThan(3).WithMessage("Tipo Pessoa não cadastrado.");
            RuleFor(x => x.Pessoa.DataNascimento)
                .NotNull().WithMessage($"Data Nascimento é requerido.")
                .LessThan(DateTime.Now.AddYears(-16)).WithMessage("Pessoa menor que 16 anos");
            #endregion

            #region .: Documento :.
            RuleFor(x => x.Pessoa.Documento.DocumentoTipoId)
                .GreaterThan(0).WithMessage("Tipo Documento é requerido.");
            RuleFor(x => x.Pessoa.Documento.NumeroDocumento)
                .NotEmpty().NotNull().WithMessage("Número do documento é requerido.");
            #endregion

            #region .: Contato :.
            RuleFor(x => x.Pessoa.Contato.TelefoneTipoId)
                .GreaterThan(0).WithMessage("Informe Telefone Tipo Id.");
            RuleFor(x => x.Pessoa.Contato.Telefone)
                .NotEmpty().NotNull().WithMessage("Informe Telefone.");
            RuleFor(x => x.Pessoa.Contato.Email)
                .EmailAddress().WithMessage("E-mail informado é inválido.")
                .NotNull().NotEmpty().WithMessage("Informe E-mail.");
            #endregion

            #region .: Endereço :.
            RuleFor(x => x.Pessoa.Endereco.CEP)
                .NotEmpty().NotNull().WithMessage("CEP é requerido.")
                .Length(8).WithMessage("CEP informado é inválido.");
            RuleFor(x => x.Pessoa.Endereco.Logradouro)
                .NotNull().NotEmpty().WithMessage("Logradouro é requerido.");
            RuleFor(x => x.Pessoa.Endereco.Numero)
                .NotNull().NotEmpty().WithMessage("Número é requerido.");
            RuleFor(X => X.Pessoa.Endereco.Bairro)
                .NotEmpty().NotNull().WithMessage("Bairro é requerido.");
            RuleFor(x => x.Pessoa.Endereco.UF)
                .NotNull().NotEmpty().WithMessage("UF informado é inválido.")
                .Length(2).WithMessage("UF informado é inválido.");
            #endregion
        }
    }
}
