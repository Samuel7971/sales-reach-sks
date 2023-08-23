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

        public async Task<IEnumerable<Contato>> BuscarTodosAsync()
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..Contato_Samuel";
            return await _session.Connection.QueryAsync<Contato>(sql);
        }

        public async Task<Contato> BuscarPorEmailAsync(string email)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..Contato_Samuel
                         WHERE Email = @email";
            return await _session.Connection.QueryFirstAsync<Contato>(sql, new { email });
        }

        public async Task<Contato> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..Contato_Samuel
                         WHERE Id = @id";
            return await _session.Connection.QueryFirstAsync<Contato>(sql, new { id });
        }

        public async Task<Contato> BuscarPorNumeroAsync(string numero)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..Contato_Samuel
                         WHERE Telefone = @numero";
            return await _session.Connection.QueryFirstAsync<Contato>(sql, new { numero });
        }

        public async Task<Contato> BuscarPorPessoaIdAsync(int pessoaId)
        {
            var sql = $@"SELECT 
                                Id
                         	  , PessoaId
                         	  , TelefoneTipoId
                         	  , Telefone
                         	  , Email
                         	  , DataCadastro 
                         FROM FitCard_Gestao..Contato_Samuel
                         WHERE PessoaId = @pessoaId";
            return await _session.Connection.QueryFirstAsync<Contato>(sql, new { pessoaId });
        }

        public async Task<int> AtualizarAsync(Contato pessoaContato)
        {
            var sql = $@"UPDATE FitCard_Gestao..PessoaContato_Samuel
                             SET TelefoneTipoId = @TelefoneTipoId 
                                ,Telefone = @Telefone 
                                ,Email = @Email
                         FROM Contato_Samuel
                         WHERE Id = @Id AND PessoaId = @PessoaId";
            return await _session.Connection.ExecuteAsync(sql, pessoaContato);
        }

        public async Task<int> InserirAsync(Contato pessoaContato)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..Contato_Samuel(PessoaId, TeleFoneTipoId, Telefone, Email, DataCadastro)
                          VALUES(@PessoaId, @TelefoneTipoId, @Telefone, @Email, GETDATE())";
            return await _session.Connection.ExecuteAsync(sql, pessoaContato, _session.Transaction);
        }
    }
}
