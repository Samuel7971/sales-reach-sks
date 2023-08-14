using System.Text.Json.Serialization;

namespace SalesReach.Application.Models.InserirModels
{
    public class ContatoInserirModel
    {
        [JsonIgnore]
        public int PessoaId { get; set; }
        public int TelefoneTipoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
