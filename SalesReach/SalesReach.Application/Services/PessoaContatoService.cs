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
    public class PessoaContatoService : IPessoaContatoService
    {
        private readonly IPessoaContatoRepository _contatoRepository;
        public PessoaContatoService(IPessoaContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }


        public async Task<IEnumerable<IPessoaContato>> BuscarTodosAsync() => await _contatoRepository.BuscarTodosAsync();

        public async Task<IPessoaContato> BuscarPorEmailAsync(string email) => await _contatoRepository.BuscarPorEmailAsync(email);

        public async Task<IPessoaContato> BuscarPorIdAsync(int id) => await _contatoRepository.BuscarPorIdAsync(id);

        public async Task<IPessoaContato> BuscarPorNumeroAsync(string numero) => await _contatoRepository.BuscarPorNumeroAsync(numero);


        public async Task<int> AtualizarAsync(IPessoaContato contatoModel)
        {
            var contato = await _contatoRepository.BuscarPorIdAsync(contatoModel.Id);

            contato.Atualizar(contatoModel.Id, contatoModel.PessoaId, contatoModel.TelefoneTipoId, contatoModel.Telefone, contatoModel.Email);
            return await _contatoRepository.AtualizarAsync(contato);
        }

        public async Task<int> InserirAsync(IPessoaContato contatoModel)
        {
            var contato = new PessoaContato(contatoModel);
            return await _contatoRepository.InserirAsync(contato);
        }
    }
}
