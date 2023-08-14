using System.Text.Json.Serialization;

namespace SalesReach.Application.Models.InserirModels
{
    public class DocumentoInserirModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int DocumentoTipoId { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
