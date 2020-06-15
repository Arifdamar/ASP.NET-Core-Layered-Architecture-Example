using System;
using System.Collections.Generic;
using System.Linq;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : EfGenericRepository<Work>, IWorkDal
    {

    }
}
