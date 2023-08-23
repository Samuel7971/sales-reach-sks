using SalesReach.Domain.Entities;

namespace SalesReach.Domain.Repositories
{
    public interface IPessoaDocumentoRepository
    {
        Task<IEnumerable<Documento>> BuscarTodosAsync();
        Task<Documento> BuscarPorIdAsync(int id);
        Task<int> InserirAsync(Documento documento);
        Task<Documento> BuscarPorNumeroAsync(string numeroDocumento);
        Task<int> AtualizarAsync(Documento documento);
        Task<bool> VerificarSeExisteAsync(int id);
    }
}
