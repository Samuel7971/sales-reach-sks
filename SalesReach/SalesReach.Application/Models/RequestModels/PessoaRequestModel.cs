using System.Text.Json.Serialization;

namespace SalesReach.Application.Models.RequestModels
{
    public class PessoaRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public int PessoaTipoId { get; set; }
        public string PessoaTipo { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DocumentoRequestModel Documento { get; set; }
        public ContatoRequestModel Contato { get; set; }
        public EnderecoRequestModel Endereco { get; set; }
    }
}
