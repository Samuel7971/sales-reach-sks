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
        Task<IEnumerable<PessoaContato>> BuscarTodosAsync();
        Task<PessoaContato> BuscarPorIdAsync(int id);
        Task<PessoaContato> BuscarPorNumeroAsync(string numero);
        Task<PessoaContato> BuscarPorEmailAsync(string email);
        Task<int> AtualizarAsync(PessoaContato pessoaContato);
        Task<int> InserirAsync(PessoaContato pessoaContato);
    }
}
