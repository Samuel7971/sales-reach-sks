using SalesReach.Application.Models;

namespace SalesReach.Application.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaTipoId { get; set; }
        public string PessoaTipo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DocumentoModel Documento { get; set; }
        public ContatoModel Contato { get; set; }
        public EnderecoModel Endereco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
