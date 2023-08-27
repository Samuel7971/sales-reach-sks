using SalesReach.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.ViewModels
{
    public class ClientePessoaViewModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public PessoaModel Pessoa { get; set; }
    }
}
