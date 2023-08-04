using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<IEndereco>> BuscarTodosAsync();
        Task<IEndereco> BuscarPorIdAsync(int id);
        Task<IEndereco> BuscarPorCEPAsync(string cep);
        Task<IEnumerable<IEndereco>> BuscarPorLogradouroAsync(string logradouro);
        Task<int> AtualizarAsync(IEndereco endereco);
        Task<int> InserirAsync(IEndereco endereco);
    }
}
