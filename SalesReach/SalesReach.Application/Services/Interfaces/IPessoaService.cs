using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<IPessoa>> BuscarTodosAsync();
        Task<IPessoa> BuscarPorIdAsync(int id);
        Task<IPessoa> BuscarPorNomeAsync(string nome);
        Task<int> InserirAsync(IPessoa pessoa);
        Task<int> AtualizarAsync(IPessoa pessoa);
        Task<bool> VerificarSeExisteAsync(int id);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
    }
}
