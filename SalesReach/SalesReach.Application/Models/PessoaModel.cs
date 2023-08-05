using SalesReach.Domain.Entities.Interface;

namespace SalesReach.Application.Models
{
    public class PessoaModel : IPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaTipoId { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public PessoaModel() { }

        public PessoaModel(IPessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            PessoaTipoId = pessoa.PessoaTipoId;
            DataNascimento = pessoa.DataNascimento;
            Ativo = pessoa.Ativo;
            DataCadastro = pessoa.DataCadastro;
        }
    }
}
