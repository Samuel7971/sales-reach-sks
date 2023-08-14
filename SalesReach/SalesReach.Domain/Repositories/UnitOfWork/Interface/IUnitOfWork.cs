using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Domain.Repositories.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransation();
        Task Commit();
        Task Rollback();
    }
}
