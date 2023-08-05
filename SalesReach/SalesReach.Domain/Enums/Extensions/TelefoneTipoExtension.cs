using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Enums.Extensions
{
    public static class TelefoneTipoExtension
    {
        public static string ToStringTelefoneTipo(this int telefoneTipoId)
        => telefoneTipoId switch
        {
            1 => TelefoneTipo.Residencial.DisplayName(),
            2 => TelefoneTipo.Celular.DisplayName(),
            3 => TelefoneTipo.Comercial.DisplayName(),
            _ => throw new ArgumentOutOfRangeException(nameof(TelefoneTipo), "Tipo Telefone não cadastrado."),
        };

        public static int IntParseTelefoneTipo(this string telefoneTipoId)
          => telefoneTipoId switch
          {
              "Residencial" => 1,
              "Celular" => 2,
              "Comercial" => 3,
              _ => throw new ArgumentOutOfRangeException(nameof(TelefoneTipo), "Tipo Telefone não cadastrado."),
          };
    }
}
