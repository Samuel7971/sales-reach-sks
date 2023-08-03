using System.ComponentModel.DataAnnotations;

namespace SalesReach.Domain.Enums
{
    public enum DocumentoTipo
    {
        [Display(Name = "CPF")]
        CPF = 1,
        [Display(Name = "RG")]
        RG = 2,
        [Display(Name = "CNPJ")]
        CNPJ = 3,
    }
}
