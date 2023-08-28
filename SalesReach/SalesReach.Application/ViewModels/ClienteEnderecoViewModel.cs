using SalesReach.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.ViewModels
{
    public class ClienteEnderecoViewModel
    {
        public ClienteModel Cliente { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
