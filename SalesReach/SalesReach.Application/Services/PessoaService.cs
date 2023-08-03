using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Entities.Interface;
using SalesReach.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<IPessoa>> BuscarTodosAsync() => await _pessoaRepository.BuscarTodosAsync();
      
        public async Task<IPessoa> BuscarPorIdAsync(int id) => await _pessoaRepository.BuscarPorIdAsync(id);
 
        public async Task<IPessoa> BuscarPorNomeAsync(string nome) => await _pessoaRepository.BuscarPorNomeAsync(nome);
 
        public async Task<int> AtualizarAsync(IPessoa pessoaModel)
        {
            var pessoa = await _pessoaRepository.BuscarPorIdAsync(pessoaModel.Id);

            pessoa.Atualizar(pessoaModel.Id, pessoaModel.Nome, pessoaModel.PessoaTipoId, pessoaModel.DataNascimento, pessoaModel.Ativo);

            return await _pessoaRepository.AtualizarAsync(pessoa);
        }

        public async Task<int> InserirAsync(IPessoa pessoaModel)
        {
            var pessoa = new Pessoa(pessoaModel);

            return await _pessoaRepository.InserirAsync(pessoa);
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
    }
}
