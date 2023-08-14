using System.Text.Json.Serialization;

namespace SalesReach.Application.Models.InserirModels
{
    public class PessoaInserirModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaTipoId { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DocumentoInserirModel Documento { get; set; } 
        public ContatoInserirModel Contato { get; set; }
        public EnderecoInserirModel Endereco { get; set; }
    }
}
