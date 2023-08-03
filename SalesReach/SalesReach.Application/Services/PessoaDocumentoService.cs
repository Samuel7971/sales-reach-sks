using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Entities.Interface;
using SalesReach.Domain.Repositories;

namespace SalesReach.Application.Services
{
    public class PessoaDocumentoService : IPessoaDocumentoService
    {
        private readonly IPessoaDocumentoRepository _pessoaDocumentoRepository;

        public PessoaDocumentoService(IPessoaDocumentoRepository pessoaDocumentoRepository)
        {
            _pessoaDocumentoRepository = pessoaDocumentoRepository;
        }


        public async Task<IPessoaDocumento> BuscarPorIdAsync(int id)
            => await _pessoaDocumentoRepository.BuscarPorIdAsync(id);

        public async Task<IPessoaDocumento> BuscarPorNumeroAsync(string numeroDocumento)
            => await _pessoaDocumentoRepository.BuscarPorNumeroAsync(numeroDocumento);

        public async Task<int> AtualizarAsync(IPessoaDocumento documentoModel)
        {
            var documento = await _pessoaDocumentoRepository.BuscarPorIdAsync(documentoModel.Id);

            if (documento is null)
                return 0;

            documento.Atualizar(documentoModel.Id, documentoModel.DocumentoTipoId, documentoModel.NumeroDocumento);

            return await _pessoaDocumentoRepository.AtualizarAsync(documento);
        }

        public async Task<int> InserirAsync(IPessoaDocumento documentoModel)
        {
            var documento = new PessoaDocumento(documentoModel);

            return await _pessoaDocumentoRepository.InserirAsync(documento);
        }

        public async Task<bool> VerificarSeExisteAsync(int id)
        {
            var retorno = await _pessoaDocumentoRepository.BuscarPorIdAsync(id);
            return retorno is not null;
        }
    }
}
