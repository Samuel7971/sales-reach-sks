﻿using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;

namespace SalesReach.Application.Services.Interfaces
{
    public interface IPessoaContatoService
    {
        Task<IEnumerable<ContatoModel>> BuscarTodosAsync();
        Task<ContatoModel> BuscarPorIdAsync(int id);
        Task<ContatoModel> BuscarPorNumeroAsync(string numero);
        Task<ContatoModel> BuscarPorEmailAsync(string email);
        Task<ContatoModel> BuscarPorPessoaIdAsync(int pessoaId);
        Task<int> AtualizarAsync(ContatoModel pessoaContato);
        Task<int> InserirAsync(ContatoRequestModel pessoaContato);
    }
}
