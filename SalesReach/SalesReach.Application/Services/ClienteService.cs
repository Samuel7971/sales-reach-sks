using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Application.ViewModels;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaDocumentoService _documentoService;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IPessoaService pessoaService, IPessoaDocumentoService documentoService, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _pessoaService = pessoaService;
            _documentoService = documentoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteModel>> BuscarTodosAsync() 
            => _mapper.Map<IEnumerable<ClienteModel>>(await _clienteRepository.BuscarTodosAsync());

        public async Task<ClienteModel> BuscarClientePorPessoaIdAsync(int pessoaId) 
            => _mapper.Map<ClienteModel>(await _clienteRepository.BuscarClientePorPessoaIdAsync(pessoaId));

        public async Task<ClientePessoaViewModel> BuscarPorIdAsync(int id) 
        {
            var clientePessoa = new ClientePessoaViewModel();

            clientePessoa.Cliente = _mapper.Map<ClienteModel>(await _clienteRepository.BuscarPorIdAsync(id));

            if (clientePessoa.Cliente is null) 
                return new ClientePessoaViewModel();

            await Task.WhenAll
                (
                   Task.Run(async () => clientePessoa.Pessoa = _mapper.Map<PessoaModel>(await _pessoaService.BuscarPorIdAsync(clientePessoa.Cliente.PessoaId)) ?? new PessoaModel()),
                   Task.Run(async () => clientePessoa.Documento = _mapper.Map<DocumentoModel>(await _documentoService.BuscarPorIdAsync(clientePessoa.Cliente.PessoaId)) ?? new DocumentoModel())
                );

            return clientePessoa;
        }

        public async Task<int> InserirAsync(ClienteRequestModel clienteModel)
        {
            var novoCliente = new Cliente();

            try
            {
                var pessoa = await _pessoaService.InserirAsync(clienteModel.Pessoa);

                novoCliente.Inserir(pessoa.Pessoa.Id, pessoa.Pessoa.Ativo);

                return await _clienteRepository.InserirAsync(novoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> AtualizarAtivoAsync(int id, bool ativo)
        {
            var clienteAtualizar = new Cliente();

            clienteAtualizar.AtualizarAtivo(id, ativo);

            return await _clienteRepository.AtualizarAtivoAsync(id, ativo);
        }

        public async Task<ClientePessoaViewModel> BuscarClientePorNome(string nome)
        {
            var clientePessoa = new ClientePessoaViewModel();

            clientePessoa.Pessoa = _mapper.Map<PessoaModel>(await _pessoaService.BuscarPorNomeAsync(nome)) ?? new PessoaModel();

            await Task.WhenAll
                (
                   Task.Run(async () => clientePessoa.Cliente = _mapper.Map<ClienteModel>(await _clienteRepository.BuscarClientePorPessoaIdAsync(clientePessoa.Pessoa.Id))),
                   Task.Run(async () => clientePessoa.Documento = _mapper.Map<DocumentoModel>(await _documentoService.BuscarPorIdAsync(clientePessoa.Pessoa.Id)) ?? new DocumentoModel())
                );

            if (clientePessoa.Cliente is null)
                return new ClientePessoaViewModel();

            return clientePessoa;
        }
    }
}
