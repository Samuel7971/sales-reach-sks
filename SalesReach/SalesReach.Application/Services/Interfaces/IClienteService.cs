using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.ViewModels;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteModel>> BuscarTodosAsync();
        Task<ClientePessoaViewModel> BuscarPorIdAsync(int id);
        Task<ClienteModel> BuscarPorPessoaIdAsync(int pessoaId);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
        Task<int> InserirAsync(ClienteRequestModel cliente);
        Task<ClientePessoaViewModel> BuscarClientePorNome(string nome);
        Task<ClienteEnderecoViewModel> BuscarClientePorCepAsync(string cep);
    }
}
