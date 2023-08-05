using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Entities.Interface
{
    public interface IPessoaContato
    {
        int Id { get; }
        int PessoaId { get; }
        int TelefoneTipoId { get; }
        string Telefone { get; }
        string Email { get; }
        DateTime DataCadastro { get; }
    }
}
