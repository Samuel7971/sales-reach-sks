using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Entities.Interface
{
    public interface IPessoa
    {
        public int Id { get; }
        public string Nome { get; }
        public int PessoaTipoId { get; }
        public DateTime DataNascimento { get; }
        public bool Ativo { get; }
        public DateTime DataCadastro { get; }
    }
}
