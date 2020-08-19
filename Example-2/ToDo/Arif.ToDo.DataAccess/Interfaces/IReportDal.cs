using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Interfaces
{
    public interface IReportDal : IGenericDal<Report>
    {
        Report GetReportByIdWithTask(int id);
        int GetReportCountByUserId(int userId);
        int GetTotalReportCount();
    }
}
