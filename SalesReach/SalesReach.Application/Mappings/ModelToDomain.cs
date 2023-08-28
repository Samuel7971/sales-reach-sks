using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Application.ViewModels;
using SalesReach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Application.Mappings
{
    public class ModelToDomain : Profile
    {
        public ModelToDomain()
        {
            #region .: Cliente Mapping :.
            CreateMap<ClienteModel, Cliente>();
            CreateMap<IEnumerable<ClienteModel>, IEnumerable<Cliente>>();
            #endregion

            #region .: Pessoa Mapping
            CreateMap<PessoaModel, Pessoa>();
            CreateMap<IEnumerable<PessoaModel>, IEnumerable<Pessoa>>();
            #endregion

            #region .: Documento Mapping :.
            CreateMap<DocumentoModel, Documento>();
            CreateMap<IEnumerable<DocumentoModel>, IEnumerable<Documento>>();
            #endregion

            #region .: Contato Mapping :.
            CreateMap<ContatoModel, Contato>();
            CreateMap<IEnumerable<ContatoModel>, IEnumerable<Contato>>();
            #endregion

            #region .: Endereço Mapping :.
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<IEnumerable<EnderecoModel>, IEnumerable<Endereco>>();
            #endregion
        }
    }
}
