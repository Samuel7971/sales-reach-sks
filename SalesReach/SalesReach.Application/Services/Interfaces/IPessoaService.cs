using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Models.ResponseModels;
using SalesReach.Application.ViewModels;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaModel>> BuscarTodosAsync();
        Task<PessoaModel> BuscarPorIdAsync(int id);
        Task<PessoaModel> BuscarPorNomeAsync(string nome);
        Task<PessoaResponseModel> InserirAsync(PessoaRequestModel pessoa);
        Task<int> AtualizarAsync(PessoaModel pessoa);
        Task<bool> VerificarSeExisteAsync(int id);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
    }
}
