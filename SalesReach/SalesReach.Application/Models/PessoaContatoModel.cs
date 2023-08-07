namespace SalesReach.Application.Models
{
    public class PessoaContatoModel 
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int TelefoneTipoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
