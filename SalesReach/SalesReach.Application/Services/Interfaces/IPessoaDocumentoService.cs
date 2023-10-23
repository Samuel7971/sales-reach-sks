using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaDocumentoService
    {
        Task<IEnumerable<DocumentoModel>> BuscarTodosAsync();
        Task<DocumentoModel> BuscarPorIdAsync(int id);
        Task<DocumentoModel> BuscarPorNumeroAsync(string numeroDocumento);
        Task<int> InserirAsync(DocumentoRequestModel documento);
        Task<int> AtualizarAsync(DocumentoModel documento);
        Task<bool> VerificarSeExisteAsync(int id);
    }
}
