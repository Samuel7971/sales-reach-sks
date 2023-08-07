using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
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

        public async Task<int> InserirAsync(PessoaModel pessoaModel)
        {
            var pessoa = new Pessoa();

            pessoa.Inserir(pessoaModel.Nome, pessoaModel.PessoaTipoId, pessoaModel.DataNascimento, pessoaModel.Ativo);
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
