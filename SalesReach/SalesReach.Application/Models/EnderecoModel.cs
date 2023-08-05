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
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public DateTime DataCadastro { get; set; }

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
