using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReach.Infra.Data.Unit_Of_Work.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransation();
        void Commit();
        void Rollback();
    }
}
