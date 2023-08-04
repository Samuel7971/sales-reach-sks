using SalesReach.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Models
{
    public class EnderecoModel : IEndereco
    {
        public int Id { get; private set; }
        public int PessoaId { get; private set; }
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string UF { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public EnderecoModel() { }

        public EnderecoModel(IEndereco endereco)
        {
            Id = endereco.Id;
            PessoaId = endereco.PessoaId;
            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Localidade = endereco.Localidade;
            UF = endereco.UF;
            DataCadastro = DateTime.Now;
        }
    }
}
