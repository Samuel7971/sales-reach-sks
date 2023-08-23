using Dapper;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private DbSession _session;
        public ClienteRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            var sql = $@"SELECT 
                             Id
                            ,PessoaId
                            ,Ativo
                            ,DataCadastro 
                         FROM FitCard_Gestao..Cliente_Samuel";

            return await _session.Connection.QueryAsync<Cliente>(sql);
        }

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT 
                             Id
                            ,PessoaId
                            ,Ativo
                            ,DataCadastro 
                         FROM FitCard_Gestao..Cliente_Samuel WHERE Id = @id";

            return await _session.Connection.QuerySingleOrDefaultAsync<Cliente>(sql, new { id });
        }

        public async Task<int> AtualizarAtivoAsync(int id, bool ativo)
        {
            var sql = $@"UPDATE FitCard_Gestao..Cliente_Samuel
                               SET Ativo = @Ativo
                         WHERE Id = @Id";
            return await _session.Connection.ExecuteAsync(sql, new { id, ativo });
        }

        public async Task<int> InserirAsync(Cliente cliente)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..Cliente_Samuel(PessoaId, Ativo, DataCadastro)
                                VALUES(@PessoaId, @Ativo, GETDATE());
                         SELECT @@IDENTITY";
            return await _session.Connection.ExecuteScalarAsync<int>(sql, cliente, _session.Transaction);
        }
    }
}
