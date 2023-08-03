using Dapper;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {   
        private DbSession _session;
        public PessoaRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Pessoa>> BuscarTodosAsync()
        {
            var sql = $@"SELECT 
                             Id
                            ,Nome
                            ,PessoaTipoId
                            ,DataNascimento
                            ,Ativo
                            ,DataCadastro
                         FROM FitCard_Gestao..Pessoa_Samuel";
            return await _session.Connection.QueryAsync<Pessoa>(sql);
        }

        public async Task<Pessoa> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT 
                             Id
                            ,Nome
                            ,PessoaTipoId
                            ,DataNascimento
                            ,Ativo
                            ,DataCadastro
                         FROM FitCard_Gestao..Pessoa_Samuel WHERE Id = @id";
            return await _session.Connection.QuerySingleOrDefaultAsync<Pessoa>(sql, new { id });
        }

        public async Task<Pessoa> BuscarPorNomeAsync(string nome)
        {
            var sql = $@"SELECT 
                             Id
                            ,Nome
                            ,PessoaTipoId
                            ,DataNascimento
                            ,Ativo
                            ,DataCadastro
                         FROM FitCard_Gestao..Pessoa_Samuel WHERE Nome LIKE '%' + REPLACE(@nome,'&','%') + '%'";
            return await _session.Connection.QueryFirstAsync<Pessoa>(sql, new { nome });
        }

        public async Task<int> AtualizarAsync(Pessoa pessoa)
        {
            var sql = $@"UPDATE FitCard_Gestao..Pessoa_Samuel
                               SET Nome = @Nome
                                  ,DataNascimento = @DataNascimento
                                  ,Ativo = @Ativo
                                  ,PessoaTipoId = @PessoaTipoId
                          WHERE Id = @Id";
            return await _session.Connection.ExecuteAsync(sql, pessoa);
        }

        public async Task<int> InserirAsync(Pessoa pessoa)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..Pessoa_Samuel(Nome, PessoaTipoId, DataNascimento, Ativo, DataCadastro)
                                    OUTPUT INSERTED.Id
                                                VALUES(@Nome, @PessoaTipoId, @DataNascimento, @Ativo, GETDATE())";
            return await _session.Connection.ExecuteAsync(sql, pessoa);
        }
    }
}
