using Dapper;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Infra.Data.Repositories
{
    public class PessoaDocumentoRepository : IPessoaDocumentoRepository
    {
        private DbSession _session;
        public PessoaDocumentoRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<PessoaDocumento>> BuscarTodosAsync()
        {
            var sql = $@"SELECT Id, DocumentoTipoId, NumeroDocumento, DataCadastro
                                  FROM FitCard_Gestao..PessoaDocumento_Samuel";

            return await _session.Connection.QueryAsync<PessoaDocumento>(sql);
        }

        public async Task<PessoaDocumento> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT Id, DocumentoTipoId, NumeroDocumento, DataCadastro
                                  FROM FitCard_Gestao..PessoaDocumento_Samuel 
                                      WHERE Id = @id";
            return await _session.Connection.QueryFirstAsync<PessoaDocumento>(sql, new { id });
        }

        public async Task<PessoaDocumento> BuscarPorNumeroAsync(string numeroDocumento)
        {
            var sql = $@"SELECT Id, DocumentoTipoId, NumeroDocumento, DataCadastro
                                  FROM FitCard_Gestao..PessoaDocumento_Samuel 
                                      WHERE NumeroDocumento LIKE '%' + REPLACE(@numeroDocumento,'&','%') + '%';";
            return await _session.Connection.QueryFirstAsync<PessoaDocumento>(sql, new { numeroDocumento });
        }

        public async Task<int> AtualizarAsync(PessoaDocumento documento)
        {
            var sql = $@"UPDATE FitCard_Gestao..PessoaDocumento_Samuel 
                               SET DocumentoTipoId = @DocumentoTipoId,
                                   NumeroDocumento = @NumeroDocumento
                             WHERE Id = @Id";
            return await _session.Connection.ExecuteAsync(sql, documento);
        }


        public async Task<int> InserirAsync(PessoaDocumento documento)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..PessoaDocumento_Samuel(Id, DocumentoTipoId, NumeroDocumento, DataCadastro)
                                   VALUES(@Id, @DocumentoTipoId, @NumeroDocumento, GETDATE())";
            return await _session.Connection.ExecuteAsync(sql, documento);
        }

        public Task<bool> VerificarSeExisteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
