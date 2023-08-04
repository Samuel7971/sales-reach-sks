using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Entities.Interface;
using SalesReach.Domain.Repositories;
using System.Runtime.ConstrainedExecution;

namespace SalesReach.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRespository;
        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRespository = enderecoRepository;
        }

        public async Task<IEndereco> BuscarPorCEPAsync(string cep) => await _enderecoRespository.BuscarPorCEPAsync(cep);

        public async Task<IEndereco> BuscarPorIdAsync(int id) => await _enderecoRespository.BuscarPorIdAsync(id);

        public async Task<IEnumerable<IEndereco>> BuscarPorLogradouroAsync(string logradouro) => await _enderecoRespository.BuscarPorLogradouroAsync(logradouro);

        public async Task<IEnumerable<IEndereco>> BuscarTodosAsync() => await _enderecoRespository.BuscarTodosAsync();

        public async Task<int> AtualizarAsync(IEndereco enderecoModel)
        {
            var endereco = await _enderecoRespository.BuscarPorIdAsync(enderecoModel.Id);

            endereco.Atualizar(enderecoModel.Id, enderecoModel.PessoaId, enderecoModel.CEP, enderecoModel.Logradouro, enderecoModel.Numero, enderecoModel.Complemento, enderecoModel.Bairro, endereco.Localidade, enderecoModel.UF);

            return await _enderecoRespository.AtualizarAsync(endereco);
        }

        public async Task<int> InserirAsync(IEndereco enderecoModel)
        {
            var endereco = new Endereco(enderecoModel);
            return await _enderecoRespository.InserirAsync(endereco);
        }
    }
}
