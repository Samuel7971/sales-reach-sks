using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Entities.Interface
{
    public interface IPessoaDocumento
    {
        public int Id { get; }
        public int DocumentoTipoId { get; }
        public string NumeroDocumento { get; }
        public DateTime DataCadastro { get; }
    }
}
