using SalesReach.Domain.Enums;
using SalesReach.Domain.Enums.Extensions;
using SalesReach.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesReach.Domain.Entities
{
    [Table("PessoaDocumento_Samuel")]
    public class PessoaDocumento 
    {
        [Key]
        public int Id { get; set; }
        public int DocumentoTipoId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;

        public PessoaDocumento() { }

        public PessoaDocumento(int id, int documentoTipoId, string numeroDocumento, DateTime dataCadastro)
        {
            IsValidoDocumento(id, documentoTipoId, numeroDocumento);

            Id = id;
            DocumentoTipoId = documentoTipoId;
            NumeroDocumento = numeroDocumento;
            DataCadastro = dataCadastro;
        }

        private void IsValidoDocumento(int id, int documentoTipoId, string numeroDocumento)
        {
            DomainValidationException.When(id == 0, "Id não pode ser 0.");
            DomainValidationException.When(string.IsNullOrEmpty(numeroDocumento), "Informe o número do CPF ou CNPJ.");
            DomainValidationException.When(numeroDocumento.Length != 11 && documentoTipoId == (int)DocumentoTipo.CPF, "CPF informado é inválido.");
            DomainValidationException.When(numeroDocumento.Length != 14 && documentoTipoId == (int)DocumentoTipo.CNPJ, "CNPJ informado é inválido.");
            DomainValidationException.When(numeroDocumento.Length != 9 && documentoTipoId == (int)DocumentoTipo.RG, "RG informado é inválido.");
        }

        public static implicit operator string(PessoaDocumento pessoaDocumento)
           => $"{pessoaDocumento.Id}, {ToStringTipoDocumento(pessoaDocumento.DocumentoTipoId)}, {pessoaDocumento.NumeroDocumento}, {pessoaDocumento.DataCadastro}";

        public static implicit operator PessoaDocumento(string documento)
        {
            string[] data = documento.Split(',');
            return new PessoaDocumento(id: int.Parse(data[0]), documentoTipoId: IntParseTipoDocumento(data[1]), numeroDocumento: data[2], dataCadastro: DateTime.Parse(data[3]));
        }

        public void Inserir(int id, int documentoTipoId, string numeroDocumento)
        {
            IsValidoDocumento(id, documentoTipoId, numeroDocumento);

            Id = id;
            DocumentoTipoId = documentoTipoId;
            NumeroDocumento = numeroDocumento;
        }

        public void Atualizar(int id, int documentoTipoId, string numeroDocumento)
        {
            IsValidoDocumento(id, documentoTipoId, numeroDocumento);

            Id = id;
            DocumentoTipoId = documentoTipoId;
            NumeroDocumento = numeroDocumento;
        }

        public static string ToStringTipoDocumento(int tipo)
           => tipo switch
           {
               1 => DocumentoTipo.CPF.DisplayName(),
               2 => DocumentoTipo.RG.DisplayName(),
               3 => DocumentoTipo.CNPJ.DisplayName(),
               _ => throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de documento não cadastrado."),
           };

        public static int IntParseTipoDocumento(string tipo)
           => tipo switch
           {
               "CPF" => 1,
               "RG" => 2,
               "CNPJ" => 3,
               _ => throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de documento não cadastrado."),
           };
    }
}
