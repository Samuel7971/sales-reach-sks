using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesReach.Domain.Entities;
using SalesReach.Domain.Entities.Interface;
using SalesReach.Infra.Data.DataBaseSettings;

namespace SalesReach.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void InitInfraData(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataBaseSettings>(x => configuration.GetSection("DefaultConnection").Bind(x));

            services.AddTransient<IPessoa, Pessoa>();
        }
    }
}
