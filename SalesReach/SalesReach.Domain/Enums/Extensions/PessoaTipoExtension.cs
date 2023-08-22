using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Enums.Extensions
{
    public static class PessoaTipoExtension
    {
        public static string ToStringPessoaTipo(this int pessoaTipoId)
           => pessoaTipoId == (int)PessoaTipo.Juridica ? PessoaTipo.Juridica.DisplayName() : PessoaTipo.Fisica.DisplayName();

        public static int IntParsePessoaTipo(this string pessoaTipo)
            => pessoaTipo.Equals(PessoaTipo.Fisica.DisplayName()) ? 1 : 2;
    }
}
