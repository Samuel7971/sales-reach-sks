using SalesReach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> BuscarTodosAsync();
        Task<Cliente> BuscarPorIdAsync(int id);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
        Task<int> InserirAsync(Cliente cliente);
    }
}
