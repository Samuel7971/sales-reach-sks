using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Enums
{
    internal enum TelefoneTipo
    {
        [Display(Name = "Residencial")]
        Residencial = 1,
        [Display(Name = "Celular")]
        Celular = 2,
        [Display(Name = "Comercial")]
        Comercial = 3
    }
}
