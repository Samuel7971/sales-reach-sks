using SalesReach.Domain.Entities;

namespace SalesReach.Domain.Repositories
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> BuscarTodosAsync();
        Task<Endereco> BuscarPorIdAsync(int id);
        Task<Endereco> BuscarPorCEPAsync(string cep);
        Task<IEnumerable<Endereco>> BuscarPorLogradouroAsync(string logradouro);
        Task<int> AtualizarAsync(Endereco endereco);
        Task<int> InserirAsync(Endereco endereco);
    }
}
