using AutoMapper;
using SalesReach.Application.Models;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Enums.Extensions;

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
            CreateMap<PessoaModel, Pessoa>()
                .ForMember(dom => dom.PessoaTipoId, model => model.MapFrom(m => PessoaTipoExtension.IntParsePessoaTipo(m.PessoaTipo)));
            CreateMap<IEnumerable<PessoaModel>, IEnumerable<Pessoa>>();
            #endregion

            #region .: Documento Mapping :.
            CreateMap<DocumentoModel, Documento>()
                .ForMember(dom => dom.DocumentoTipoId, model => model.MapFrom(m => DocumentoTipoExtension.IntParseDocumentoTipo(m.DocumentoTipo)));
            CreateMap<IEnumerable<DocumentoModel>, IEnumerable<Documento>>();
            #endregion

            #region .: Contato Mapping :.
            CreateMap<ContatoModel, Contato>()
                .ForMember(dom => dom.TelefoneTipoId, model => model.MapFrom(m => ContatoTipoExtension.IntParseTelefoneTipo(m.TelefoneTipo)));
            CreateMap<IEnumerable<ContatoModel>, IEnumerable<Contato>>();
            #endregion

            #region .: Endereço Mapping :.
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<IEnumerable<EnderecoModel>, IEnumerable<Endereco>>();
            #endregion
        }
    }
}
