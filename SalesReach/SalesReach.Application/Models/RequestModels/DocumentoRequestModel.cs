using System.Text.Json.Serialization;

namespace SalesReach.Application.Models.RequestModels
{
    public class DocumentoRequestModel
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int DocumentoTipoId { get; set; }
        public string DocumentoTipo { get; set; }
        public string NumeroDocumento { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
    }
}
