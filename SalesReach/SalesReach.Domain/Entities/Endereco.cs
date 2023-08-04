using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesReach.Domain.Entities.Interface;
using SalesReach.Domain.Validations;

namespace SalesReach.Domain.Entities
{
    [Table("Endereco_Samuel")]
    public class Endereco : IEndereco
    {
        [Key]
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

        public Endereco() { }

        public Endereco(int id, int pessoaId, string cep, string logradouro, string numero, string complemento, string bairro, string localidade, string uf)
        {
            Id = id;
            PessoaId = pessoaId;
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
        }

        public Endereco(IEndereco endereco)
        {
            IsValidoEndereco(endereco.Id, endereco.PessoaId, endereco.CEP, endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Bairro, endereco.Localidade, endereco.UF);
            Id = endereco.Id;
            PessoaId = endereco.PessoaId;
            CEP = endereco.CEP;
            Logradouro= endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro= endereco.Bairro;
            Localidade= endereco.Localidade;
            UF = endereco.UF;
            DataCadastro = DateTime.Now;
        }

        private void IsValidoEndereco(int id, int pessoaId, string cep, string logradouro, string numero, string complemento, string bairro, string localidade, string uf)
        {
            DomainValidationException.When(pessoaId == 0, "PessoaId é requerido.");
            DomainValidationException.When(cep is not null && cep.Length == 8, "CEP informado é inválido.");
            DomainValidationException.When(logradouro is not null, "Logradouro não pode ser nulo.");
            DomainValidationException.When(numero is not null, "Número não pode ser nulo.");
            DomainValidationException.When(bairro is not null, "Bairro não pode ser nulo.");
            DomainValidationException.When(uf.Length != 2, "UF informado é inválido.");
        }

        public void Atualizar(int id, int pessoaId, string cep, string logradouro, string numero, string complemento, string bairro, string localidade, string uf)
        {
            IsValidoEndereco(id, pessoaId, cep, logradouro, numero, complemento, bairro, localidade, uf);

            Id = id;
            PessoaId = pessoaId;
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            UF = uf;
        }

        public static implicit operator string(Endereco endereco)
            => $"{endereco.PessoaId}, {NormalizarCEP(endereco.CEP)}, {endereco.Logradouro}, {endereco.Numero}, {endereco.Complemento}, {endereco.Bairro}, {endereco.Localidade}, {endereco.UF}";

        public static implicit operator Endereco(string endereco)
        {
            var data = endereco.Split(',');
            return new Endereco(id: int.Parse(data[0]),
                                pessoaId: int.Parse(data[1]),
                                cep: ReplaceCEP(data[2]),
                                logradouro: data[3],
                                numero: data[4],
                                complemento: data[5],
                                bairro: data[6],
                                localidade: data[7],
                                uf: data[8]);
        }

        private static string NormalizarCEP(string cep) => Convert.ToUInt64(cep).ToString(@"000000\-000");

        private static string ReplaceCEP(string cep) => cep.Replace("-", string.Empty);


    }
}
