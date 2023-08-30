using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesReach.Application.Mappings;
using SalesReach.Application.Models;
using SalesReach.Application.Models.RequestModels;
using SalesReach.Application.Services;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Application.Validations;
using SalesReach.Domain.Repositories;
using SalesReach.Domain.Repositories.UnitOfWork.Interface;
using SalesReach.Infra.Data;
using SalesReach.Infra.Data.Repositories;
using SalesReach.Infra.Data.SettingsDataBase;
using SalesReach.Infra.Data.Unit_Of_Work;

namespace SalesReach.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void InitInfraData(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataBaseSettings>(x => configuration.GetSection("DefaultConnection").Bind(x));
            services.AddScoped<DbSession>();
            services.AddAutoMapper(typeof(DomainToModel));
            services.AddAutoMapper(typeof(ModelToDomain));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IPessoaDocumentoService, PessoaDocumentoService>();
            services.AddTransient<IPessoaDocumentoRepository, PessoaDocumentoRepository>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IPessoaContatoService, PessoaContatoService>();
            services.AddTransient<IPessoaContatoRepository, PessoaContatoRepository>();

            #region .: FluentValidator :.
            services.AddTransient<IValidator<ClienteRequestModel>, ClienteValidator>();
            services.AddTransient<IValidator<PessoaRequestModel>, PessoaRequestValidator>();
            services.AddTransient<IValidator<PessoaModel>, PessoaValidator>();
            services.AddTransient<IValidator<ContatoModel>, PessoaContatoValidator>();
            services.AddTransient<IValidator<EnderecoModel>, EnderecoValidator>();
            services.AddTransient<IValidator<DocumentoModel>, PessoaDocumentoValidator>();
            #endregion
        }
    }
}
