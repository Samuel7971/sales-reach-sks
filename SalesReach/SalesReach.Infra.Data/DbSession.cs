using Microsoft.Extensions.Options;
using SalesReach.Infra.Data.SettingsDataBase;
using System.Data;
using System.Data.SqlClient;

namespace SalesReach.Infra.Data
{
    public class DbSession : IDisposable
    {
        private readonly DataBaseSettings _dataBaseSettings;

        public DbSession(IOptions<DataBaseSettings> options)
        {
            _Id = Guid.NewGuid();
            _dataBaseSettings = options.Value;
            Connection = new SqlConnection(_dataBaseSettings.ConnectionString);
            Connection.Open();
        }

        private Guid _Id { get; set; }
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }


        public void Dispose() => Connection.Dispose();
    }
}
