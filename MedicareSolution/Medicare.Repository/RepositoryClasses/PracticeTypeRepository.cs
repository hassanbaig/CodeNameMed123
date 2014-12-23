using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class PracticeTypeRepository : IRepository
    {
        public PracticeTypeRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public string GetNameById(int PracticeTypeID)
        {
            var typeName = (from pt in _context.PracticeTypes
                                where pt.PracticeTypeId == PracticeTypeID
                                select pt.Name).FirstOrDefault();
            if (typeName != null || typeName != "" || typeName != string.Empty)
            { return typeName; }
            else
            { throw new Exception("Practice Type does not exist"); }
        }

        public List<Medicare.DataModel.Models.PracticeType> GetAll()
        {
            var data = (from pracType in _context.PracticeTypes
                        select new Medicare.DataModel.Models.PracticeType 
                        {
                          PracticeTypeId = pracType.PracticeTypeId,
                          Name = pracType.Name,
                          Description = pracType.Description
                        }).ToList();
            return data;
        }
    }
}
