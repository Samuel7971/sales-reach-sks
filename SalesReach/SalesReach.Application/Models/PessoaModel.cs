using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaTipoId { get; set; }
        public string PessoaTipo { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
