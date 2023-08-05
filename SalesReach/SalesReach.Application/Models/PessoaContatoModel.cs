using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Models
{
    public class PessoaContatoModel : IPessoaContato
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int TelefoneTipoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        public PessoaContatoModel() { }

        public PessoaContatoModel(IPessoaContato contato)
        {
            Id = contato.Id;
            PessoaId = contato.PessoaId;
            TelefoneTipoId = contato.TelefoneTipoId;
            Telefone = contato.Telefone;
            Email = contato.Email;
            DataCadastro = contato.DataCadastro;
        }
    }
}
