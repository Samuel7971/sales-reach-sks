using SalesReach.Domain.Entities;

namespace SalesReach.Domain.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> BuscarTodosAsync();
        Task<Pessoa> BuscarPorIdAsync(int id);
        Task<Pessoa> BuscarPorNomeAsync(string nome);
        Task<int> InserirAsync(Pessoa pessoa);
        Task<int> AtualizarAsync(Pessoa pessoa);
    }
}
