using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalesReach.Domain.Entities.Interface
{
    public interface IEndereco
    {
        int Id { get; }
        int PessoaId { get; }
        string CEP { get; }
        string Logradouro { get; }
        string Numero { get; }
        string Complemento { get; }
        string Bairro { get; }
        string Localidade { get; }
        string UF { get; }
        DateTime DataCadastro { get; }
    }
}
