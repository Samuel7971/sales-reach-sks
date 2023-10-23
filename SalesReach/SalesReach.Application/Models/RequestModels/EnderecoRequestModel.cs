using System.Text.Json.Serialization;

namespace SalesReach.Application.Models.RequestModels
{
    public class EnderecoRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
    }
}
