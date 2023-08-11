using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Application.Services
{
    public class PessoaDocumentoService : IPessoaDocumentoService
    {
        private readonly IPessoaDocumentoRepository _pessoaDocumentoRepository;
        private readonly IMapper _mapper;

        public PessoaDocumentoService(IPessoaDocumentoRepository pessoaDocumentoRepository, IMapper mapper)
        {
            _pessoaDocumentoRepository = pessoaDocumentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaDocumentoModel>> BuscarTodosAsync() 
        {
            return _mapper.Map<IEnumerable<PessoaDocumentoModel>>(await _pessoaDocumentoRepository.BuscarTodosAsync());
        }

        public async Task<PessoaDocumentoModel> BuscarPorIdAsync(int id)
            => _mapper.Map<PessoaDocumentoModel>(await _pessoaDocumentoRepository.BuscarPorIdAsync(id));

        public async Task<PessoaDocumentoModel> BuscarPorNumeroAsync(string numeroDocumento)
            => _mapper.Map<PessoaDocumentoModel>(await _pessoaDocumentoRepository.BuscarPorNumeroAsync(numeroDocumento));

        public async Task<int> AtualizarAsync(PessoaDocumentoModel documentoModel)
        {
            var documento = await _pessoaDocumentoRepository.BuscarPorIdAsync(documentoModel.Id);

            if (documento is null)
                return 0;

            documento.Atualizar(documentoModel.Id, documentoModel.DocumentoTipoId, documentoModel.NumeroDocumento);

            return await _pessoaDocumentoRepository.AtualizarAsync(documento);
        }

        public async Task<int> InserirAsync(PessoaDocumentoModel documentoModel)
        {
            var documento = new PessoaDocumento();

            documento.Inserir(documentoModel.Id, documentoModel.DocumentoTipoId, documentoModel.NumeroDocumento);

            return await _pessoaDocumentoRepository.InserirAsync(documento);
        }

        public async Task<bool> VerificarSeExisteAsync(int id)
        {
            var retorno = await _pessoaDocumentoRepository.BuscarPorIdAsync(id);
            return retorno is not null;
        }
    }
}
