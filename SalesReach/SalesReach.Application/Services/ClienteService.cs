using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
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
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteModel>> BuscarTodosAsync() => _mapper.Map<IEnumerable<ClienteModel>>(await _clienteRepository.BuscarTodosAsync());

        public async Task<ClienteModel> BuscarPorIdAsync(int id) => _mapper.Map<ClienteModel>(await _clienteRepository.BuscarPorIdAsync(id));

        public async Task<int> InserirAsync(ClienteModel clienteModel)
        {
            var novoCliente = new Cliente();

            novoCliente.Inserir(clienteModel.PessoaId, clienteModel.Ativo);

            return await _clienteRepository.InserirAsync(novoCliente);
        }

        public async Task<int> AtualizarAtivoAsync(int id, bool ativo)
        {
            var clienteAtualizar = new Cliente();

            clienteAtualizar.AtualizarAtivo(id, ativo);

            return await _clienteRepository.AtualizarAtivoAsync(id, ativo);
        }
    }
}
