using SalesReach.Application.Models;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaDocumentoService
    {
        Task<IEnumerable<PessoaDocumentoModel>> BuscarTodosAsync();
        Task<PessoaDocumentoModel> BuscarPorIdAsync(int id);
        Task<PessoaDocumentoModel> BuscarPorNumeroAsync(string numeroDocumento);
        Task<int> InserirAsync(PessoaDocumentoModel documento);
        Task<int> AtualizarAsync(PessoaDocumentoModel documento);
        Task<bool> VerificarSeExisteAsync(int id);
    }
}
