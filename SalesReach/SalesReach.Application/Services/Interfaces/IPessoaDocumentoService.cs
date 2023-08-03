using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaDocumentoService
    {
        Task<IPessoaDocumento> BuscarPorIdAsync(int id);
        Task<IPessoaDocumento> BuscarPorNumeroAsync(string numeroDocumento);
        Task<int> InserirAsync(IPessoaDocumento documento);
        Task<int> AtualizarAsync(IPessoaDocumento documento);
        Task<bool> VerificarSeExisteAsync(int id);
    }
}
