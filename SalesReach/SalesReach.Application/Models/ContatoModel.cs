﻿using System.Text.Json.Serialization;

namespace SalesReach.Application.Models
{
    public class ContatoModel 
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public int TelefoneTipoId { get; set; }
        public string TelefoneTipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
