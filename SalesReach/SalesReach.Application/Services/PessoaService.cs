﻿using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Models.ResponseModels;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Application.ViewModels;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;
using SalesReach.Domain.Repositories.UnitOfWork.Interface;

namespace SalesReach.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaDocumentoService _documentoService;
        private readonly IPessoaContatoService _contatoService;
        private readonly IEnderecoService _enderecoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IPessoaDocumentoService documentoService, IPessoaContatoService contatoService, IEnderecoService enderecoService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _documentoService = documentoService;
            _contatoService = contatoService;
            _enderecoService = enderecoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaModel>> BuscarTodosAsync() 
            => _mapper.Map<IEnumerable<PessoaModel>>(await _pessoaRepository.BuscarTodosAsync());

        public async Task<PessoaModel> BuscarPorIdAsync(int id) 
            => _mapper.Map<PessoaModel>(await _pessoaRepository.BuscarPorIdAsync(id));

        public async Task<PessoaModel> BuscarPorNomeAsync(string nome) 
            => _mapper.Map<PessoaModel>(await _pessoaRepository.BuscarPorNomeAsync(nome));

        public async Task<int> AtualizarAsync(PessoaModel pessoaModel)
        {
            var pessoa = await _pessoaRepository.BuscarPorIdAsync(pessoaModel.Id);

            pessoa.Atualizar(pessoaModel.Id, pessoaModel.Nome, pessoaModel.PessoaTipoId, pessoaModel.DataNascimento, pessoaModel.Ativo);

            return await _pessoaRepository.AtualizarAsync(pessoa);
        }

        public async Task<bool> VerificarSeExisteAsync(int id)
        {
            var retorno = await _pessoaRepository.BuscarPorIdAsync(id);
            return retorno is not null;
        }

        public async Task<int> AtualizarAtivoAsync(int id, bool ativo)
        {
            var pessoa = await _pessoaRepository.BuscarPorIdAsync(id);

            if (pessoa is null)
                return 0;

            pessoa.Atualizar(pessoa.Id, pessoa.Nome, pessoa.PessoaTipoId, pessoa.DataNascimento, ativo);

            return await _pessoaRepository.AtualizarAsync(pessoa);
        }

        public async Task<PessoaResponseModel> InserirAsync(PessoaRequestModel pessoaModel)
        {
            var pessoa = new Pessoa();
            var novaPessoa = new PessoaResponseModel();

            var novoDocumento = await _documentoService.BuscarPorNumeroAsync(pessoaModel.Documento.NumeroDocumento);

            if (novoDocumento is not null)
                throw new Exception("Já exite pessoa com o mesmo número de documento cadastrado.");

            pessoa.Inserir(pessoaModel.Nome, pessoaModel.PessoaTipoId, pessoaModel.DataNascimento, pessoaModel.Ativo);

            await _unitOfWork.BeginTransation();

            var pessoaId =  await _pessoaRepository.InserirAsync(pessoa);
            
            if (pessoaId == 0)
                return null;

            pessoaModel.Documento.Id = pessoaId;
            pessoaModel.Contato.PessoaId = pessoaId;
            pessoaModel.Endereco.PessoaId = pessoaId;

            await _documentoService.InserirAsync(pessoaModel.Documento);
            await _contatoService.InserirAsync(pessoaModel.Contato);
            await _enderecoService.InserirAsync(pessoaModel.Endereco);

            await _unitOfWork.Commit();

            novaPessoa.Pessoa = _mapper.Map<PessoaViewModel>(await _pessoaRepository.BuscarPorIdAsync(pessoaId));

            await Task.WhenAll
               (
                  Task.Run(async () => novaPessoa.Pessoa.Documento = _mapper.Map<DocumentoModel>(await _documentoService.BuscarPorIdAsync(pessoaId))),
                  Task.Run(async () => novaPessoa.Pessoa.Contato = _mapper.Map<ContatoModel>(await _contatoService.BuscarPorPessoaIdAsync(pessoaId))),
                  Task.Run(async () => novaPessoa.Pessoa.Endereco = _mapper.Map<EnderecoModel>(await _enderecoService.BuscarPorPessoaIdAsync(pessoaId)))
               );
          
            return novaPessoa;
        }
    }
}
