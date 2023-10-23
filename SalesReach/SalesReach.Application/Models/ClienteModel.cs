namespace SalesReach.Application.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
