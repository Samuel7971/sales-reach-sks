using SalesReach.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Entities
{
    [Table("Usuario_Samuel")]
    public class Usuario : Base
    {
        public int PessoaId { get; set; }
        public int UsuarioTipoId { get; set; }
        public bool Ativo { get; set; }

        public Usuario() { }

        public Usuario(int id, int pessoaId, int tipoUsuarioId, bool ativo, DateTime dataCadastro)
        {
            Id = id;
            PessoaId = pessoaId;
            UsuarioTipoId = tipoUsuarioId;
            Ativo = ativo;
            DataCadastro = dataCadastro;
        }

        private void IsValidoUsuario(int pessoaId, int tipoUsuarioId)
        {
            DomainValidationException.When(pessoaId < 0, "É preciso informar Id do cadastro pessoa.");
            DomainValidationException.When(tipoUsuarioId <= 0, "É preciso informar UsuárioTipoId.");
        }

        public void Inserir(int id, int pessoaId, int tipoUsuarioId, bool ativo, DateTime dataCadastro)
        {
            IsValidoUsuario(pessoaId, tipoUsuarioId);

            Id = id;
            PessoaId = pessoaId;
            UsuarioTipoId = tipoUsuarioId;
            Ativo = ativo;
        }

        public void Atualizar(int id, int pessoaId, int tipoUsuarioId, bool ativo)
        {
            IsValidoUsuario(pessoaId, tipoUsuarioId);

            Id = id;
            PessoaId = pessoaId;
            UsuarioTipoId = tipoUsuarioId;
            Ativo = ativo;
        }

        public static implicit operator string(Usuario usuario)
            => $"{usuario.Id}, {usuario.PessoaId}, {usuario.UsuarioTipoId}, {ToStringAtivo(usuario.Ativo)}, {usuario.DataCadastro}";

        public static implicit operator Usuario(string usuario)
        {
            var data = usuario.Split(',');
            return new Usuario(id: int.Parse(data[0]), pessoaId: int.Parse(data[1]), tipoUsuarioId: int.Parse(data[2]), ToBoolAtivo(data[3]), DateTime.Parse(data[4]));
        }

        private static string ToStringAtivo(bool ativo) => ativo ? "Ativo" : "Inativo";

        private static bool ToBoolAtivo(string ativo) => ativo.Equals("Ativo");
    }
}
