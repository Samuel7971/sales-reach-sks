using AutoMapper;
using SalesReach.Application.Models;
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
            #region .: Pessoa Mapping
            CreateMap<PessoaModel, Pessoa>();
            CreateMap<IEnumerable<PessoaModel>, IEnumerable<Pessoa>>();
            #endregion

            #region .: Documento Mapping :.
            CreateMap<PessoaDocumentoModel, PessoaDocumento>();

            #endregion

            #region .: Contato Mapping :.
            CreateMap<PessoaContatoModel, PessoaContato>();
            CreateMap<IEnumerable<PessoaContatoModel>, IEnumerable<PessoaContato>>();
            #endregion

            #region .: Endereço Mapping :.
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<IEnumerable<EnderecoModel>, IEnumerable<Endereco>>();
            #endregion
        }
    }
}
