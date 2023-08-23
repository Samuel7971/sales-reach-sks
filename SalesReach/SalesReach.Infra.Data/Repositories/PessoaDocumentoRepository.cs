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

        public async Task<IEnumerable<Documento>> BuscarTodosAsync()
        {
            var sql = $@"SELECT Id, DocumentoTipoId, NumeroDocumento, DataCadastro
                                  FROM FitCard_Gestao..Documento_Samuel";

            return await _session.Connection.QueryAsync<Documento>(sql);
        }

        public async Task<Documento> BuscarPorIdAsync(int id)
        {
            var sql = $@"SELECT Id, DocumentoTipoId, NumeroDocumento, DataCadastro
                                  FROM FitCard_Gestao..Documento_Samuel 
                                      WHERE Id = @id";
            return await _session.Connection.QueryFirstAsync<Documento>(sql, new { id });
        }

        public async Task<Documento> BuscarPorNumeroAsync(string numeroDocumento)
        {
            var sql = $@"SELECT Id, DocumentoTipoId, NumeroDocumento, DataCadastro
                                  FROM FitCard_Gestao..Documento_Samuel 
                                      WHERE NumeroDocumento LIKE '%' + REPLACE(@numeroDocumento,'&','%') + '%';";
            return await _session.Connection.QuerySingleOrDefaultAsync<Documento>(sql, new { numeroDocumento });
        }

        public async Task<int> AtualizarAsync(Documento documento)
        {
            var sql = $@"UPDATE FitCard_Gestao..Documento_Samuel 
                               SET DocumentoTipoId = @DocumentoTipoId,
                                   NumeroDocumento = @NumeroDocumento
                             WHERE Id = @Id";
            return await _session.Connection.ExecuteAsync(sql, documento);
        }


        public async Task<int> InserirAsync(Documento documento)
        {
            var sql = $@"INSERT INTO FitCard_Gestao..Documento_Samuel(Id, DocumentoTipoId, NumeroDocumento, DataCadastro)
                                   VALUES(@Id, @DocumentoTipoId, @NumeroDocumento, GETDATE())";
            return await _session.Connection.ExecuteAsync(sql, documento, _session.Transaction);
        }

        public Task<bool> VerificarSeExisteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
