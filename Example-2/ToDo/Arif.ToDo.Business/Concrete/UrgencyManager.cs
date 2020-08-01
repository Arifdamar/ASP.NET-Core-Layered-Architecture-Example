using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.Business.Interfaces;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Arif.ToDo.DataAccess.Interfaces;
using Arif.ToDo.Entities.Concrete;

namespace Arif.ToDo.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly EfUrgencyRepository _urgencyRepository;

        public UrgencyManager()
        {
            // TODO refactor
            _urgencyRepository = new EfUrgencyRepository();
        }

        public void Save(Urgency table)
        {
            _urgencyRepository.Save(table);
        }

        public void Delete(Urgency table)
        {
            _urgencyRepository.Delete(table);
        }

        public void Update(Urgency table)
        {
            _urgencyRepository.Update(table);
        }

        public Urgency GetById(int id)
        {
            return _urgencyRepository.GetById(id);
        }

        public List<Urgency> GetAll()
        {
            return _urgencyRepository.GetAll();
        }
    }
}
