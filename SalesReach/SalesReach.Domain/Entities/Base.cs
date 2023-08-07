using System.ComponentModel.DataAnnotations;

namespace SalesReach.Domain.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
