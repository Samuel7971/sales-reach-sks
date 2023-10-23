using FluentValidation;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Validations.ValidationsRequests
{
    public class PessoaRequestValidator : AbstractValidator<PessoaRequestModel>
    {
        public PessoaRequestValidator()
        {
            #region .: Pessoa :.
            RuleFor(x => x.Nome)
                .NotEmpty().NotNull().WithMessage("O nome é requerido.")
                .MinimumLength(5).WithMessage("É preciso ter mais que 5 caracteres no nome.")
                .MaximumLength(100).WithMessage("Nome não pode ter mais que 100 caracteres.");
            RuleFor(x => x.PessoaTipo)
                .NotEmpty().NotNull().WithMessage("Tipo Pessoa é requerido.");
            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage($"Data Nascimento é requerido.")
                .LessThan(DateTime.Now.AddYears(-16)).WithMessage("Pessoa menor que 16 anos");
            #endregion

            #region .: Documento :.
            RuleFor(x => x.Documento.DocumentoTipo)
                .NotNull().NotEmpty().WithMessage("Tipo Documento é requerido.");
            RuleFor(x => x.Documento.NumeroDocumento)
                .NotEmpty().NotNull().WithMessage("Número do documento é requerido.");
            #endregion

            #region .: Contato :.
            RuleFor(x => x.Contato.TelefoneTipo)
                .NotEmpty().NotNull().WithMessage("Informe Telefone Tipo.");
            RuleFor(x => x.Contato.Telefone)
                .NotEmpty().NotNull().WithMessage("Informe Telefone.");
            RuleFor(x => x.Contato.Email)
                .EmailAddress().WithMessage("E-mail informado é inválido.")
                .NotNull().NotEmpty().WithMessage("Informe E-mail.");
            #endregion

            #region .: Endereço :.
            RuleFor(x => x.Endereco.CEP)
                .NotEmpty().NotNull().WithMessage("CEP é requerido.")
                .Length(8).WithMessage("CEP informado é inválido.");
            RuleFor(x => x.Endereco.Logradouro)
                .NotNull().NotEmpty().WithMessage("Logradouro é requerido.");
            RuleFor(x => x.Endereco.Numero)
                .NotNull().NotEmpty().WithMessage("Número é requerido.");
            RuleFor(x => x.Endereco.Bairro)
                .NotEmpty().NotNull().WithMessage("Bairro é requerido.");
            RuleFor(x => x.Endereco.UF)
                .NotNull().NotEmpty().WithMessage("UF informado é inválido.")
                .Length(2).WithMessage("UF informado é inválido.");
            #endregion

        }
    }
}
