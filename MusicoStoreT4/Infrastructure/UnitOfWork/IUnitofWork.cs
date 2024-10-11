using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IRepository<LogMessage> LogMessageRepository { get; }
        //IRepository<Image> ImageRepository { get; }

        void Commit();
        void Rollback();
    }
}
