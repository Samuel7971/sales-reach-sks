using SalesReach.Domain.Entities;
using SalesReach.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaContatoService
    {
        Task<IEnumerable<IPessoaContato>> BuscarTodosAsync();
        Task<IPessoaContato> BuscarPorIdAsync(int id);
        Task<IPessoaContato> BuscarPorNumeroAsync(string numero);
        Task<IPessoaContato> BuscarPorEmailAsync(string email);
        Task<int> AtualizarAsync(IPessoaContato pessoaContato);
        Task<int> InserirAsync(IPessoaContato pessoaContato);
    }
}
