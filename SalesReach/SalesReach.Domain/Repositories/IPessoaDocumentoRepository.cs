using SalesReach.Domain.Entities;

namespace SalesReach.Domain.Repositories
{
    public interface IPessoaDocumentoRepository
    {
        Task<IEnumerable<PessoaDocumento>> BuscarTodosAsync();
        Task<PessoaDocumento> BuscarPorIdAsync(int id);
        Task<int> InserirAsync(PessoaDocumento documento);
        Task<PessoaDocumento> BuscarPorNumeroAsync(string numeroDocumento);
        Task<int> AtualizarAsync(PessoaDocumento documento);
        Task<bool> VerificarSeExisteAsync(int id);
    }
}
