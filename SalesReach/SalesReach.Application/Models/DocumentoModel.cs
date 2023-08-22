namespace SalesReach.Application.Models
{
    public class DocumentoModel 
    {
        public int Id { get; set; }
        public int DocumentoTipoId { get; set; }
        public string DocumentoTipo { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
