using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly EfReportRepository _reportRepository;

        public ReportManager()
        {
            // TODO refactor
            _reportRepository = new EfReportRepository();
        }

        public void Save(Report table)
        {
            _reportRepository.Save(table);
        }

        public void Delete(Report table)
        {
            _reportRepository.Delete(table);
        }

        public void Update(Report table)
        {
            _reportRepository.Update(table);
        }

        public Report GetById(int id)
        {
            return _reportRepository.GetById(id);
        }

        public List<Report> GetAll()
        {
            return _reportRepository.GetAll();
        }
    }
}
