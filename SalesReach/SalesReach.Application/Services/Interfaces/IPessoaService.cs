using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Models.ResponseModels;
using SalesReach.Application.ViewModels;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaViewModel>> BuscarTodosAsync();
        Task<PessoaViewModel> BuscarPorIdAsync(int id);
        Task<PessoaViewModel> BuscarPorNomeAsync(string nome);
        Task<PessoaInserirResponseViewModel> InserirAsync(PessoaRequestModel pessoa);
        Task<int> AtualizarAsync(PessoaModel pessoa);
        Task<bool> VerificarSeExisteAsync(int id);
        Task<int> AtualizarAtivoAsync(int id, bool ativo);
    }
}
