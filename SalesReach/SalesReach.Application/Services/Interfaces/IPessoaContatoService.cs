using SalesReach.Application.Models;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaContatoService
    {
        Task<IEnumerable<PessoaContatoModel>> BuscarTodosAsync();
        Task<PessoaContatoModel> BuscarPorIdAsync(int id);
        Task<PessoaContatoModel> BuscarPorNumeroAsync(string numero);
        Task<PessoaContatoModel> BuscarPorEmailAsync(string email);
        Task<PessoaContatoModel> BuscarPorPessoaIdAsync(int pessoaId);
        Task<int> AtualizarAsync(PessoaContatoModel pessoaContato);
        Task<int> InserirAsync(PessoaContatoModel pessoaContato);
    }
}
