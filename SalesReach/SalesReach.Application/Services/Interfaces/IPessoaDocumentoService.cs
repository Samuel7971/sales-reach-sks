using SalesReach.Application.Models;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaDocumentoService
    {
        Task<IEnumerable<DocumentoModel>> BuscarTodosAsync();
        Task<DocumentoModel> BuscarPorIdAsync(int id);
        Task<DocumentoModel> BuscarPorNumeroAsync(string numeroDocumento);
        Task<int> InserirAsync(DocumentoModel documento);
        Task<int> AtualizarAsync(DocumentoModel documento);
        Task<bool> VerificarSeExisteAsync(int id);
    }
}
