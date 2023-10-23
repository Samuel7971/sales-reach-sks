using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Enums.Extensions;

namespace SalesReach.Application.Mappings
{
    public class DomainToModel :Profile
    {
        public DomainToModel()
        {
            #region
            CreateMap<Cliente, ClienteModel>();
            #endregion

            #region .: Pessoa Mapping :.
            CreateMap<Pessoa, PessoaModel>()
                .ForMember(model => model.PessoaTipo, dom => dom.MapFrom(d => PessoaTipoExtension.ToStringPessoaTipo(d.PessoaTipoId)));
            #endregion

            #region .: Documento Mapping :.
            CreateMap<Documento, DocumentoModel>()
                .ForMember(model => model.DocumentoTipo, dom => dom.MapFrom(d => DocumentoTipoExtension.ToStringDocumentoTipo(d.DocumentoTipoId)));
            #endregion

            #region .: Contato Mapping :.
            CreateMap<Contato, ContatoModel>()
                .ForMember(model => model.TelefoneTipo, dom => dom.MapFrom(d => ContatoTipoExtension.ToStringTelefoneTipo(d.TelefoneTipoId)));
            #endregion

            #region .: Endereço Mapping :.
            CreateMap<Endereco, EnderecoModel>();
            #endregion
        }
    }
}
