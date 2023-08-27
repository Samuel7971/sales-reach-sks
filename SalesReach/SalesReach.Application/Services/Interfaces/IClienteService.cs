using SalesReach.Application.Models;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteModel>> BuscarTodosAsync();
        Task<ClienteModel> BuscarPorIdAsync(int id);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
        Task<int> InserirAsync(ClienteModel cliente);
    }
}
