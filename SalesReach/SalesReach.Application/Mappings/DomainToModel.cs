using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Domain.Entities;

namespace SalesReach.Application.Mappings
{
    public class DomainToModel :Profile
    {
        public DomainToModel()
        {
            #region .: Pessoa Mapping :.
            CreateMap<Pessoa, PessoaViewModel>();
            //CreateMap<IEnumerable<Pessoa>, IEnumerable<PessoaModel>>(); 
            #endregion

            #region .: Documento Mapping :.
            CreateMap<PessoaDocumento, DocumentoModel>();
            //CreateMap<IEnumerable<PessoaDocumento>, IEnumerable<PessoaDocumentoModel>>();
            #endregion

            #region .: Contato Mapping :.
            CreateMap<PessoaContato, ContatoModel>();
            //CreateMap<IEnumerable<PessoaContato>, IEnumerable<PessoaContatoModel>>();
            #endregion

            #region .: Endereço Mapping :.
            CreateMap<Endereco, EnderecoModel>();
            //CreateMap<IEnumerable<Endereco>, IEnumerable<EnderecoModel>>();
            #endregion
        }
    }
}
