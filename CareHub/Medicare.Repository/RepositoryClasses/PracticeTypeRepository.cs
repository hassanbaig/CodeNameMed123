using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class PracticeTypeRepository : IRepository
    {
        public PracticeTypeRepository()
        {

        }
        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
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

        public List<CareHub.DataModel.Models.PracticeType> GetAll()
        {
            var data = (from pracType in _context.PracticeTypes
                        select new CareHub.DataModel.Models.PracticeType 
                        {
                          PracticeTypeId = pracType.PracticeTypeId,
                          Name = pracType.Name,
                          Description = pracType.Description
                        }).ToList();
            return data;
        }
    }
}
