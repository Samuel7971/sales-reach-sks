using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Models.RequestModels
{
    public class PessoaRequestModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PessoaTipoId { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public PessoaDocumentoModel Documento { get; set; }
        public PessoaContatoModel Contato { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
