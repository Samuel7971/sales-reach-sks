﻿using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoModel>> BuscarTodosAsync();
        Task<EnderecoModel> BuscarPorIdAsync(int id);
        Task<EnderecoModel> BuscarPorCEPAsync(string cep);
        Task<EnderecoModel> BuscarPorPessoaIdAsync(int pessoaId);
        Task<IEnumerable<EnderecoModel>> BuscarPorLogradouroAsync(string logradouro);
        Task<int> AtualizarAsync(EnderecoModel endereco);
        Task<int> InserirAsync(EnderecoRequestModel endereco);
    }
}
