using SalesReach.Application.Models;

namespace SalesReach.Application.ViewModels.ClienteViewModels
{
    public class ClientePessoaViewModel
    {
        public ClienteModel Cliente { get; set; }
        public PessoaModel Pessoa { get; set; }
        public DocumentoModel Documento { get; set; }
    }
}
