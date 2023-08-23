using SalesReach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Repositories
{
    public interface IPessoaContatoRepository
    {
        Task<IEnumerable<Contato>> BuscarTodosAsync();
        Task<Contato> BuscarPorIdAsync(int id);
        Task<Contato> BuscarPorNumeroAsync(string numero);
        Task<Contato> BuscarPorEmailAsync(string email);
        Task<Contato> BuscarPorPessoaIdAsync(int pessoaId);
        Task<int> AtualizarAsync(Contato pessoaContato);
        Task<int> InserirAsync(Contato pessoaContato);
    }
}
