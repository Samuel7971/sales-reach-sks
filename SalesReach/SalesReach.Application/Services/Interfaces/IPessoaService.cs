using SalesReach.Application.Models;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaModel>> BuscarTodosAsync();
        Task<PessoaModel> BuscarPorIdAsync(int id);
        Task<PessoaModel> BuscarPorNomeAsync(string nome);
        Task<int> InserirAsync(PessoaModel pessoa);
        Task<int> AtualizarAsync(PessoaModel pessoa);
        Task<bool> VerificarSeExisteAsync(int id);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
    }
}
