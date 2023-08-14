using SalesReach.Domain.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesReach.Domain.Entities
{
    [Table("Endereco_Samuel")]
    public class Endereco : Base
    {
        public int PessoaId { get; private set; }
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string UF { get; private set; }

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

        private void IsValidoEndereco(int pessoaId, string cep, string logradouro, string numero, string complemento, string bairro, string localidade, string uf)
        {
            DomainValidationException.When(pessoaId == 0, "PessoaId é requerido.");
            DomainValidationException.When(cep is null || cep.Length < 8, "CEP informado é inválido.");
            DomainValidationException.When(logradouro is null, "Logradouro não pode ser nulo.");
            DomainValidationException.When(numero is null, "Número não pode ser nulo.");
            DomainValidationException.When(bairro is null, "Bairro não pode ser nulo.");
            DomainValidationException.When(uf.Length != 2, "UF informado é inválido.");
        }

        public void Inserir(int pessoaId, string cep, string logradouro, string numero, string complemento, string bairro, string localidade, string uf)
        {
            IsValidoEndereco(pessoaId, cep, logradouro, numero, complemento, bairro, localidade, uf);
            PessoaId = pessoaId;
            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
        }

        public void Atualizar(int id, int pessoaId, string cep, string logradouro, string numero, string complemento, string bairro, string localidade, string uf)
        {
            IsValidoEndereco(pessoaId, cep, logradouro, numero, complemento, bairro, localidade, uf);

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
