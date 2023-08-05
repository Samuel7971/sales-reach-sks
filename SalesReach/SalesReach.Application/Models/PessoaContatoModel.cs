using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Models
{
    public class PessoaContatoModel : IPessoaContato
    {
        public int Id { get; private set; }
        public int PessoaId { get; private set; }
        public int TelefoneTipoId { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }

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
