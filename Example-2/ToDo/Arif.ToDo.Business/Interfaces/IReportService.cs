﻿using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetReportByIdWithTask(int id);
        int GetReportCountByUserId(int userId);
        int GetTotalReportCount();
    }
}
