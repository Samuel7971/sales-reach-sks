using Dapper;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Infra.Data.Repositories
{
    public class PessoaContatoRepository : IPessoaContatoRepository
    {
        private readonly DbSession _session;

        public PessoaContatoRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<PessoaContato>> BuscarTodosAsync()
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..PessoaContato_Samuel";
            return await _session.Connection.QueryAsync<PessoaContato>(sql);
        }

        public async Task<PessoaContato> BuscarPorEmailAsync(string email)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..PessoaContato_Samuel
                         WHERE Email = @email";
            return await _session.Connection.QueryFirstAsync<PessoaContato>(sql, new { email });
        }

        public async Task<PessoaContato> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..PessoaContato_Samuel
                         WHERE Email = @id";
            return await _session.Connection.QueryFirstAsync<PessoaContato>(sql, new { id });
        }

        public async Task<PessoaContato> BuscarPorNumeroAsync(string numero)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..PessoaContato_Samuel
                         WHERE Email = @numero";
            return await _session.Connection.QueryFirstAsync<PessoaContato>(sql, new { numero });
        }

        public async Task<int> AtualizarAsync(PessoaContato pessoaContato)
        {
            var sql = $@"UPDATE FitCard_Gestao..PessoaContato_Samuel
                             SET TelefoneTipoId = @TelefoneTipoId ,Telefone = @Telefone ,Email = @Email
                         FROM PessoaContato_Samuel
                         WHERE Id = @Id";
            return await _session.Connection.ExecuteAsync(sql, pessoaContato);
        }

        public async Task<int> InserirAsync(PessoaContato pessoaContato)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..PessoaContato_Samuel(PessoaId, TeleFoneTipoId, Telefone, Email, DataCadastro)
                          VALUES(@PessoaId, @TelefoneTipoId, @Telefone, @Email, GETDATE())";
            return await _session.Connection.ExecuteAsync(sql, pessoaContato);
        }
    }
}
