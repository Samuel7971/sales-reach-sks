using SalesReach.Domain.Enums;
using SalesReach.Domain.Enums.Extensions;
using SalesReach.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesReach.Domain.Entities
{
    [Table("Pessoa_Samuel")]
    public class Pessoa : Base
    {
        public string Nome { get; private set; }
        public int PessoaTipoId { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        public Pessoa() { }

        public Pessoa(int id, string nome, int pessoaTipoId, DateTime dataNascimento, bool ativo, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            PessoaTipoId = pessoaTipoId;
            DataNascimento = dataNascimento;
            Ativo = ativo;
            DataCadastro = dataCadastro;
        }

        private void IsValidaPessoa(string nome, int pessoaTipoId, DateTime dataNascimento)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            DomainValidationException.When(!IsValidaDataNascimento(dataNascimento), "Data Nascimento informada é inválida.");
            DomainValidationException.When(pessoaTipoId < 0, "É preciso informar se o cadastro é de Pessoa Fisíca ou Juridica.");
        }

        public static implicit operator string(Pessoa pessoa)
            => $"{pessoa.Id}, {pessoa.Nome}, {PessoaTipoExtension.ToStringPessoaTipo(pessoa.PessoaTipoId)}, {pessoa.DataNascimento}, {pessoa.DataCadastro}, {ToStringAtivo(pessoa.Ativo)}";

        public static implicit operator Pessoa(string pessoa)
        {
            var data = pessoa.Split(',');
            return new Pessoa(id: int.Parse(data[0]), nome: data[1], pessoaTipoId: int.Parse(data[2]), dataNascimento: DateTime.Parse(data[3]), ativo: ToBoolAtivo(data[4]), dataCadastro: DateTime.Parse(data[5]));
        }

        public void Inserir(string nome, int pessoaTipoId, DateTime dataNascimento, bool ativo)
        {
            IsValidaPessoa(nome, pessoaTipoId, dataNascimento);

            Id = 0;
            Nome = nome;
            PessoaTipoId = pessoaTipoId;
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }

        public void Atualizar(int id, string nome, int pessoaTipoId, DateTime dataNascimento, bool ativo)
        {
            IsValidaPessoa(nome, pessoaTipoId, dataNascimento);

            Id = id;
            Nome = nome;
            PessoaTipoId = pessoaTipoId;
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }

        private static string ToStringAtivo(bool ativo) => ativo ? "Ativo" : "Inativo";

        private static bool ToBoolAtivo(string ativo) => ativo.Equals("Ativo");

        private bool IsValidaDataNascimento(DateTime dataNascimento)
            => dataNascimento <= DateTime.Now.AddYears(-16); 
    }
}
