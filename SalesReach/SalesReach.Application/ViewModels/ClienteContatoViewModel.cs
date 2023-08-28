using SalesReach.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.ViewModels
{
    public class ClienteContatoViewModel
    {
        public ClienteModel Cliente { get; set; }
        public ContatoModel Contato { get; set; }
    }
}
