using Dapper;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DbSession _session;
        public EnderecoRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Endereco>> BuscarTodosAsync()
        {
            var sql = $@"SELECT 
                               Id
                              , CEP
                              , Logradouro
                              , Numero
                              , Complemento
                              , Bairro
                              , Localidade
                              , UF
                              , PessoaId
                              , DataCadastro
                         FROM FitCard_Gestao..Endereco_Samuel";
            return await _session.Connection.QueryAsync<Endereco>(sql);
        }
        public async Task<Endereco> BuscarPorCEPAsync(string cep)
        {
            var sql = $@"SELECT 
                                Id
                              , CEP
                              , Logradouro
                              , Numero
                              , Complemento
                              , Bairro
                              , Localidade
                              , UF
                              , PessoaId
                              , DataCadastro
                         FROM FitCard_Gestao..Endereco_Samuel
                         WHERE CEP = @cep";
            return await _session.Connection.QueryFirstAsync<Endereco>(sql, new { cep });
        }

        public async Task<Endereco> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT 
                                Id
                              , CEP
                              , Logradouro
                              , Numero
                              , Complemento
                              , Bairro
                              , Localidade
                              , UF
                              , PessoaId
                              , DataCadastro
                         FROM FitCard_Gestao..Endereco_Samuel
                         WHERE Id = @id";
            return await _session.Connection.QueryFirstAsync<Endereco>(sql, new { id });
        }

        public async Task<Endereco> BuscarPorPessoaIdAsync(int pessoaId)
        {
            var sql = $@"SELECT 
                                Id
                              , CEP
                              , Logradouro
                              , Numero
                              , Complemento
                              , Bairro
                              , Localidade
                              , UF
                              , PessoaId
                              , DataCadastro
                         FROM FitCard_Gestao..Endereco_Samuel
                         WHERE PessoaId = @pessoaId";
            return await _session.Connection.QueryFirstAsync<Endereco>(sql, new { pessoaId });
        }

        public async Task<IEnumerable<Endereco>> BuscarPorLogradouroAsync(string logradouro)
        {
            var sql = $@"SELECT 
                                Id
                              , CEP
                              , Logradouro
                              , Numero
                              , Complemento
                              , Bairro
                              , Localidade
                              , UF
                              , PessoaId
                              , DataCadastro
                         FROM FitCard_Gestao..Endereco_Samuel
                         WHERE Logradouro LIKE '%' + REPLACE(@logradouro,'&','%') + '%'";
            return await _session.Connection.QueryAsync<Endereco>(sql, new { logradouro });
        }
        public async Task<int> AtualizarAsync(Endereco endereco)
        {
            var sql = $@"UPDATE Endereco_Samuel SET
                              , CEP = @CEP
                              , Logradouro = @Logradouro
                              , Numero = @Numero
                              , Complemento = @Complemento
                              , Bairro = @Bairro
                              , Localidade = @Localidade
                              , UF = @UF
                         FROM FitCard_Gestao..Endereco_Samuel
                         WHERE Id = @id";
            return await _session.Connection.ExecuteAsync(sql, endereco);
        }

        public async Task<int> InserirAsync(Endereco endereco)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..Endereco_Samuel 
                                (CEP
                                 ,Logradouro
                                 ,Numero
                                 ,Complemento
                                 ,Bairro
                                 ,Localidade
                                 ,UF
                                 ,PessoaId
                                 ,DataCadastro)
                          VALUES(@CEP
                                 ,@Logradouro
                                 ,@Numero
                                 ,@Complemento
                                 ,@Bairro
                                 ,@Localidade
                                 ,@UF
                                 ,@PessoaId
                                 ,GETDATE())";
            return await _session.Connection.ExecuteAsync(sql, endereco, _session.Transaction);
        }
    }
}
