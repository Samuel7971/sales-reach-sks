using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Application.Services
{
    public class PessoaDocumentoService : IPessoaDocumentoService
    {
        private readonly IPessoaDocumentoRepository _documentoRepository;
        private readonly IMapper _mapper;

        public PessoaDocumentoService(IPessoaDocumentoRepository documentoRepository, IMapper mapper)
        {
            _documentoRepository = documentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DocumentoModel>> BuscarTodosAsync() 
        {
            return _mapper.Map<IEnumerable<DocumentoModel>>(await _documentoRepository.BuscarTodosAsync());
        }

        public async Task<DocumentoModel> BuscarPorIdAsync(int id)
            => _mapper.Map<DocumentoModel>(await _documentoRepository.BuscarPorIdAsync(id));

        public async Task<DocumentoModel> BuscarPorNumeroAsync(string numeroDocumento)
            => _mapper.Map<DocumentoModel>(await _documentoRepository.BuscarPorNumeroAsync(numeroDocumento));

        public async Task<int> AtualizarAsync(DocumentoModel documentoModel)
        {
            var documento = await _documentoRepository.BuscarPorIdAsync(documentoModel.Id);

            if (documento is null)
                return 0;

            documento.Atualizar(documentoModel.Id, documentoModel.DocumentoTipoId, documentoModel.NumeroDocumento);

            return await _documentoRepository.AtualizarAsync(documento);
        }

        public async Task<int> InserirAsync(DocumentoRequestModel documentoModel)
        {
            var documento = new Documento();

            documento.Inserir(documentoModel.Id, documentoModel.DocumentoTipoId, documentoModel.NumeroDocumento);

            return await _documentoRepository.InserirAsync(documento);
        }

        public async Task<bool> VerificarSeExisteAsync(int id)
        {
            var retorno = await _documentoRepository.BuscarPorIdAsync(id);
            return retorno is not null;
        }
    }
}
