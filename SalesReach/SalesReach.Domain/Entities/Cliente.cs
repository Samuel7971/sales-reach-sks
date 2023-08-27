using SalesReach.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Entities
{
    [Table("Cliente_Samuel")]
    public class Cliente : Base
    {
        public int PessoaId { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente() { }

        public Cliente(int id, int pessoaId, DateTime dataCadastro, bool ativo)
        {
            Id = id;
            PessoaId = pessoaId;
            Ativo = ativo;
            DataCadastro = dataCadastro;
        }

        private void IsValidoCliente(int pessoaId)
        {
            DomainValidationException.When(pessoaId < 0, "É preciso informar Id do cadastro pessoa.");
        }

        public static implicit operator string(Cliente cliente)
            => $"{cliente.Id}, {cliente.PessoaId}, {ToStringAtivo(cliente.Ativo)}, {cliente.DataCadastro.GetDateTimeFormats('g')[0]}";

        public static implicit operator Cliente(string cliente)
        {
            var data = cliente.Split(',');
            return new Cliente(id: int.Parse(data[0]), pessoaId: int.Parse(data[1]), ativo: ToBoolAtivo(data[2]), dataCadastro: DateTime.Parse(data[3]));
        }

        public void Inserir(int pessoaId, bool ativo)
        {
            IsValidoCliente(pessoaId);

            Id = 0;
            PessoaId = pessoaId;
            Ativo = ativo;
        }

        public void AtualizarAtivo(int id, bool ativo)
        {
            Id = id;
            Ativo = ativo;
        }

        private static string ToStringAtivo(bool ativo) => ativo ? "Ativo" : "Inativo";

        private static bool ToBoolAtivo(string ativo) => ativo.Equals("Ativo");
    }
}
