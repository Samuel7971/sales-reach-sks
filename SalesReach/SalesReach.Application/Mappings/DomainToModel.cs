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
    public class DomainToModel :Profile
    {
        public DomainToModel()
        {
            #region .: Pessoa Mapping :.
            CreateMap<Pessoa, PessoaModel>();
            CreateMap<IEnumerable<Pessoa>, IEnumerable<PessoaModel>>(); 
            #endregion

            #region .: Documento Mapping :.
            CreateMap<PessoaDocumento, PessoaDocumentoModel>();
            CreateMap<IEnumerable<PessoaDocumento>, IEnumerable<PessoaDocumentoModel>>();
            #endregion

            #region .: Contato Mapping :.
            CreateMap<PessoaContato, PessoaContatoModel>();
            CreateMap<IEnumerable<PessoaContato>, IEnumerable<PessoaContatoModel>>();
            #endregion

            #region .: Endereço Mapping :.
            CreateMap<Endereco, EnderecoModel>();
            CreateMap<IEnumerable<Endereco>, IEnumerable<EnderecoModel>>();
            #endregion
        }
    }
}
