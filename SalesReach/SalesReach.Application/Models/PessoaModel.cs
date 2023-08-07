namespace SalesReach.Application.Models
{
    public class PessoaModel 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaTipoId { get; set; }
        public DateTime DataNascimento { get; set; }
        public PessoaDocumentoModel Dcoumento { get; set; }
        public PessoaContatoModel Contato { get; set; }
        public EnderecoModel Endereco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
