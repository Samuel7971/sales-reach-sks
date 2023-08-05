using SalesReach.Domain.Entities.Interface;
using SalesReach.Domain.Enums.Extensions;
using SalesReach.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SalesReach.Domain.Entities
{
    [Table("PessoaContato_Samuel")]
    public class PessoaContato : IPessoaContato
    {
        [Key]
        public int Id { get; private set; }
        public int PessoaId { get; private set; }
        public int TelefoneTipoId { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public PessoaContato() { }

        public PessoaContato(int id, int pessoaId, int telefoneTipoId, string telefone, string email, DateTime dataCadastro)
        {
            IsValidoContato(pessoaId, telefoneTipoId, telefone, email);

            Id = id;
            PessoaId = pessoaId;
            TelefoneTipoId = telefoneTipoId;
            Telefone = telefone;
            Email = email;
            DataCadastro = dataCadastro;
        }

        public PessoaContato(IPessoaContato pessoaContato)
        {
            IsValidoContato(pessoaContato.PessoaId, pessoaContato.TelefoneTipoId, pessoaContato.Telefone, pessoaContato.Email);

            Id = pessoaContato.Id;
            PessoaId = pessoaContato.PessoaId;
            TelefoneTipoId = pessoaContato.TelefoneTipoId;
            Telefone = pessoaContato.Telefone;
            Email = pessoaContato.Email;
            DataCadastro = pessoaContato.DataCadastro;
        }

        public void IsValidoContato(int pessoaId, int telefoneTipoId, string telefone, string email)
        {
            DomainValidationException.When(pessoaId <= 0, "PessoaId deve ser informado.");
            DomainValidationException.When(telefoneTipoId <= 0, "Telefone Tipo Id deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(telefone), "Telefone deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(email), "E-mail deve ser informado.");
            DomainValidationException.When(!IsValidoEmail(email), "E-mail é inválido.");
        }

        public void Atualizar(int id, int pessoaId, int telefoneTipoId, string telefone, string email)
        {
            if (id != 0 && pessoaId != 0)
            {
                IsValidoContato(pessoaId, telefoneTipoId, telefone, email);

                Id = id;
                PessoaId = pessoaId;
                TelefoneTipoId = telefoneTipoId;
                Telefone = telefone;
                Email = email;
            }
        }

        public static implicit operator string(PessoaContato contato)
            => $"{contato.Id}, {contato.PessoaId}, {TelefoneTipoExtension.ToStringTelefoneTipo(contato.TelefoneTipoId)}, {contato.Telefone}, {contato.Email}, {contato.DataCadastro}";

        public static implicit operator PessoaContato(string contato)
        {
            var data = contato.Split(',');

            return new PessoaContato(
                                      int.Parse(data[0]),
                                      int.Parse(data[1]),
                                      int.Parse(data[2]),
                                      data[3],
                                      data[4],
                                      DateTime.Parse(data[5])
                                     );
        }

        private bool IsValidoEmail(string email)
        {
            Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");

            return regex.IsMatch(email);
        }
    }
}
