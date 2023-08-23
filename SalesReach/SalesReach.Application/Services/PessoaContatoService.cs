using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Repositories;

namespace SalesReach.Application.Services
{
    public class PessoaContatoService : IPessoaContatoService
    {
        private readonly IPessoaContatoRepository _contatoRepository;
        private readonly IMapper _mapper;
        public PessoaContatoService(IPessoaContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ContatoModel>> BuscarTodosAsync() 
            => _mapper.Map<IEnumerable<ContatoModel>>(await _contatoRepository.BuscarTodosAsync());

        public async Task<ContatoModel> BuscarPorEmailAsync(string email) 
            => _mapper.Map<ContatoModel>(await _contatoRepository.BuscarPorEmailAsync(email));

        public async Task<ContatoModel> BuscarPorIdAsync(int id) 
            => _mapper.Map<ContatoModel>(await _contatoRepository.BuscarPorIdAsync(id));

        public async Task<ContatoModel> BuscarPorNumeroAsync(string numero) 
            => _mapper.Map<ContatoModel>(await _contatoRepository.BuscarPorNumeroAsync(numero));

        public async Task<ContatoModel> BuscarPorPessoaIdAsync(int pessoaId)
            => _mapper.Map<ContatoModel>(await _contatoRepository.BuscarPorPessoaIdAsync(pessoaId));


        public async Task<int> AtualizarAsync(ContatoModel contatoModel)
        {
            var contato = await _contatoRepository.BuscarPorIdAsync(contatoModel.Id);

            contato.Atualizar(contatoModel.Id, contatoModel.PessoaId, contatoModel.TelefoneTipoId, contatoModel.Telefone, contatoModel.Email);
            return await _contatoRepository.AtualizarAsync(contato);
        }

        public async Task<int> InserirAsync(ContatoModel contatoModel)
        {
            var contato = new Contato();

            contato.Inserri(contatoModel.PessoaId, contatoModel.TelefoneTipoId, contatoModel.Telefone, contatoModel.Email);
            return await _contatoRepository.InserirAsync(contato);
        }
    }
}
