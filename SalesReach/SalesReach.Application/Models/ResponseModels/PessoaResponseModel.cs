using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Models.ResponseModels
{
    public class PessoaResponseModel
    {
        public PessoaModel Pessoa { get; set; }
        public PessoaDocumentoModel Documento { get; set; }
        public PessoaContatoModel Contato { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
