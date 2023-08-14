﻿using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Models.InserirModels;
using SalesReach.Application.Models.ResponseModels;
using SalesReach.Application.Services.Interfaces;
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
        {
            var pessoas = _mapper.Map<IEnumerable<PessoaModel>>(await _pessoaRepository.BuscarTodosAsync()).ToList();
            var documentos = new List<PessoaDocumentoModel>();
            var contatos = new List<PessoaContatoModel>();
            var enderecos = new List<EnderecoModel>();

            await Task.WhenAll
                (
                   Task.Run(async () => documentos = _mapper.Map<IEnumerable<PessoaDocumentoModel>>(await _documentoService.BuscarTodosAsync()).ToList()),
                   Task.Run(async () => contatos = _mapper.Map<IEnumerable<PessoaContatoModel>>(await _contatoService.BuscarTodosAsync()).ToList()),
                   Task.Run(async () => enderecos = _mapper.Map<IEnumerable<EnderecoModel>>(await _enderecoService.BuscarTodosAsync()).ToList())
                );

            pessoas.ForEach(x =>
            {
                x.Dcoumento = documentos.Where(d => d.Id == x.Id).Select(d => d).First();
                x.Contato =  contatos.Where(c => c.PessoaId == x.Id).Select(c => c).First();
                x.Endereco = enderecos.Where(e => e.PessoaId == x.Id).Select(e => e).First();
            });

            return pessoas;
        }

        public async Task<PessoaModel> BuscarPorIdAsync(int id)
        {
            var pessoa = _mapper.Map<PessoaModel>(await _pessoaRepository.BuscarPorIdAsync(id));

            await Task.WhenAll
                (
                   Task.Run(async () => pessoa.Dcoumento = _mapper.Map<PessoaDocumentoModel>(await _documentoService.BuscarPorIdAsync(pessoa.Id))),
                   Task.Run(async () => pessoa.Contato = _mapper.Map<PessoaContatoModel>(await _contatoService.BuscarPorPessoaIdAsync(pessoa.Id))),
                   Task.Run(async () => pessoa.Endereco = _mapper.Map<EnderecoModel>(await _enderecoService.BuscarPorPessoaIdAsync(pessoa.Id)))
                );

            return pessoa;
        }

        public async Task<PessoaModel> BuscarPorNomeAsync(string nome)
        {
            var pessoa = _mapper.Map<PessoaModel>(await _pessoaRepository.BuscarPorNomeAsync(nome));

            await Task.WhenAll
               (
                  Task.Run(async () => pessoa.Dcoumento = _mapper.Map<PessoaDocumentoModel>(await _documentoService.BuscarPorIdAsync(pessoa.Id))),
                  Task.Run(async () => pessoa.Contato = _mapper.Map<PessoaContatoModel>(await _contatoService.BuscarPorPessoaIdAsync(pessoa.Id))),
                  Task.Run(async () => pessoa.Endereco = _mapper.Map<EnderecoModel>(await _enderecoService.BuscarPorPessoaIdAsync(pessoa.Id)))
               );

            return pessoa;
        }

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

        public async Task<PessoaResponseModel> InserirAsync(PessoaInserirModel pessoaModel)
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

            await Task.WhenAll
               (
                  Task.Run(async () => novaPessoa.Pessoa = _mapper.Map<PessoaModel>(await _pessoaRepository.BuscarPorIdAsync(pessoaId))),
                  Task.Run(async () => novaPessoa.Documento = _mapper.Map<PessoaDocumentoModel>(await _documentoService.BuscarPorIdAsync(pessoaId))),
                  Task.Run(async () => novaPessoa.Contato = _mapper.Map<PessoaContatoModel>(await _contatoService.BuscarPorPessoaIdAsync(pessoaId))),
                  Task.Run(async () => novaPessoa.Endereco = _mapper.Map<EnderecoModel>(await _enderecoService.BuscarPorPessoaIdAsync(pessoaId)))
               );
          
            return novaPessoa;
        }
    }
}
