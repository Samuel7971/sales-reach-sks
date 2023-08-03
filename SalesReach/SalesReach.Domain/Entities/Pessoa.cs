using SalesReach.Domain.Entities.Interface;
using SalesReach.Domain.Enums;
using SalesReach.Domain.Enums.Extensions;
using SalesReach.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesReach.Domain.Entities
{
    [Table("Pessoa_Samuel")]
    public class Pessoa : IPessoa
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int PessoaTipoId { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

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

        public Pessoa(IPessoa pessoa)
        {
            IsValidaPessoa(pessoa.Nome, pessoa.PessoaTipoId, pessoa.DataNascimento);

            Id = pessoa.Id;
            Nome = pessoa.Nome;
            PessoaTipoId = pessoa.PessoaTipoId;
            DataNascimento = pessoa.DataNascimento;
            Ativo = true;
            DataCadastro = pessoa.DataCadastro;
        }

        private void IsValidaPessoa(string nome, int pessoaTipoId, DateTime dataNascimento)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            DomainValidationException.When(!IsValidaDataNascimento(dataNascimento), "Data Nascimento informada é inválida.");
            DomainValidationException.When(pessoaTipoId < 0, "É preciso informar se o cadastro é de Pessoa Fisíca ou Juridica.");
        }

        public static implicit operator string(Pessoa pessoa)
            => $"{pessoa.Id}, {pessoa.Nome}, {ToStringPessoaTipo(pessoa.PessoaTipoId)}, {pessoa.DataCadastro}, {ToStringAtivo(pessoa.Ativo)}";

        public static implicit operator Pessoa(string pessoa)
        {
            var data = pessoa.Split(',');
            return new Pessoa(id: int.Parse(data[0]), nome: data[1], pessoaTipoId: int.Parse(data[2]), dataNascimento: DateTime.Parse(data[3]), ativo: bool.Parse(data[4]), dataCadastro: DateTime.Parse(data[5]));
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

        public void Inativar(int id, bool ativo)
        {
            Id = id;
            Ativo = ativo;
        }

        public void Buscar(int id)
        {
            Id = id;
        }

        private static string ToStringPessoaTipo(int pessoaTipoId)
            => pessoaTipoId == (int)PessoaTipo.Juridica ? PessoaTipo.Juridica.DisplayName() : PessoaTipo.Fisica.DisplayName();

        private static string ToStringAtivo(bool ativo) => ativo ? "Ativo" : "Inativo";

        private bool IsValidaDataNascimento(DateTime dataNascimento)
            => dataNascimento <= DateTime.Now.AddYears(-16); 
    }
}
