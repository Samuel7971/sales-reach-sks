﻿using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesReach.Application.Services;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Domain.Repositories;
using SalesReach.Infra.Data;
using SalesReach.Infra.Data.Repositories;
using SalesReach.Infra.Data.SettingsDataBase;
using SalesReach.Infra.Data.Unit_Of_Work;
using SalesReach.Infra.Data.Unit_Of_Work.Interface;

namespace SalesReach.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void InitInfraData(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataBaseSettings>(x => configuration.GetSection("DefaultConnection").Bind(x));
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IPessoaDocumentoService, PessoaDocumentoService>();
            services.AddTransient<IPessoaDocumentoRepository, PessoaDocumentoRepository>();

            services.AddFluentValidationAutoValidation();
        }
    }
}
