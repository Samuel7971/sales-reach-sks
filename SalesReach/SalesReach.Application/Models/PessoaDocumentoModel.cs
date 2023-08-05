using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Models
{
    public class PessoaDocumentoModel : IPessoaDocumento
    {
        public int Id { get; set; }
        public int DocumentoTipoId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataCadastro { get; set; }

        public PessoaDocumentoModel() { }

        public PessoaDocumentoModel(IPessoaDocumento documento)
        {
            Id = documento.Id;
            DocumentoTipoId = documento.DocumentoTipoId;
            NumeroDocumento = documento.NumeroDocumento;
            DataCadastro = documento.DataCadastro;
        }
    }
}
