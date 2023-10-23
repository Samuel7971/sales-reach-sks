using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRespository;
        private readonly IMapper _mapper;
        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRespository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<EnderecoModel> BuscarPorCEPAsync(string cep) 
            => _mapper.Map<EnderecoModel>(await _enderecoRespository.BuscarPorCEPAsync(cep));

        public async Task<EnderecoModel> BuscarPorIdAsync(int id) 
            => _mapper.Map<EnderecoModel>(await _enderecoRespository.BuscarPorIdAsync(id));

        public async Task<EnderecoModel> BuscarPorPessoaIdAsync(int pessoaId)
            => _mapper.Map<EnderecoModel>(await _enderecoRespository.BuscarPorPessoaIdAsync(pessoaId));

        public async Task<IEnumerable<EnderecoModel>> BuscarPorLogradouroAsync(string logradouro) 
            => _mapper.Map<IEnumerable<EnderecoModel>>(await _enderecoRespository.BuscarPorLogradouroAsync(logradouro));

        public async Task<IEnumerable<EnderecoModel>> BuscarTodosAsync() 
            => _mapper.Map<IEnumerable<EnderecoModel>>(await _enderecoRespository.BuscarTodosAsync());

        public async Task<int> AtualizarAsync(EnderecoModel enderecoModel)
        {
            var endereco = await _enderecoRespository.BuscarPorIdAsync(enderecoModel.Id);

            endereco.Atualizar(enderecoModel.Id, enderecoModel.PessoaId, enderecoModel.CEP, enderecoModel.Logradouro, enderecoModel.Numero, enderecoModel.Complemento, enderecoModel.Bairro, endereco.Localidade, enderecoModel.UF);

            return await _enderecoRespository.AtualizarAsync(endereco);
        }

        public async Task<int> InserirAsync(EnderecoRequestModel enderecoModel)
        {
            var endereco = new Endereco();

            endereco.Inserir(enderecoModel.PessoaId, enderecoModel.CEP, enderecoModel.Logradouro, enderecoModel.Numero, enderecoModel.Complemento, enderecoModel.Bairro, enderecoModel.Localidade, enderecoModel.UF);
            return await _enderecoRespository.InserirAsync(endereco);
        }
    }
}
