using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalesReach.Application.Models.InserirModels
{
    public class EnderecoInserirModel
    {
        [JsonIgnore]
        public int PessoaId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
    }
}
