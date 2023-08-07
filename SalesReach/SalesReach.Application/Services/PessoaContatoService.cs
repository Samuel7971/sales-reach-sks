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


        public async Task<IEnumerable<PessoaContatoModel>> BuscarTodosAsync() 
            => _mapper.Map<IEnumerable<PessoaContatoModel>>(await _contatoRepository.BuscarTodosAsync());

        public async Task<PessoaContatoModel> BuscarPorEmailAsync(string email) 
            => _mapper.Map<PessoaContatoModel>(await _contatoRepository.BuscarPorEmailAsync(email));

        public async Task<PessoaContatoModel> BuscarPorIdAsync(int id) 
            => _mapper.Map<PessoaContatoModel>(await _contatoRepository.BuscarPorIdAsync(id));

        public async Task<PessoaContatoModel> BuscarPorNumeroAsync(string numero) 
            => _mapper.Map<PessoaContatoModel>(await _contatoRepository.BuscarPorNumeroAsync(numero));


        public async Task<int> AtualizarAsync(PessoaContatoModel contatoModel)
        {
            var contato = await _contatoRepository.BuscarPorIdAsync(contatoModel.Id);

            contato.Atualizar(contatoModel.Id, contatoModel.PessoaId, contatoModel.TelefoneTipoId, contatoModel.Telefone, contatoModel.Email);
            return await _contatoRepository.AtualizarAsync(contato);
        }

        public async Task<int> InserirAsync(PessoaContatoModel contatoModel)
        {
            var contato = new PessoaContato();

            contato.Inserri(contatoModel.PessoaId, contatoModel.TelefoneTipoId, contatoModel.Telefone, contatoModel.Email);
            return await _contatoRepository.InserirAsync(contato);
        }
    }
}
