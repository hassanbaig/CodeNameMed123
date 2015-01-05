using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class PracticeRepository : IRepository
    {
        public PracticeRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }

        public PracticeRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }
        public Practice GetByName(string Name)
        {
            return _context.Practices.SingleOrDefault(pra => pra.Name == Name);
        }
        public List<CareHub.DataModel.Models.Practice> GetPracticeByHospital(long city, string practice)
        {
            var practices = (from pra in _context.Practices
                             where pra.Name.Contains(practice) && pra.CityId == city && pra.PracticeTypeId == 2
                            select new CareHub.DataModel.Models.Practice
                            {
                                Name = pra.Name,
                                Address = pra.Address,
                                CreationDate = pra.CreationDate                                
                            }).ToList();
            return practices;
        }

        public List<CareHub.DataModel.Models.Practice> GetPracticeByHospitalLocality(long city, string practice, string locality)
        {
            var practices = (from pra in _context.Practices
                             join loc in _context.Localities on pra.LocalityId equals loc.LocalityId
                             where pra.Name.Contains(practice) && pra.CityId == city && loc.Name.Contains(locality) && pra.PracticeTypeId == 2
                             select new CareHub.DataModel.Models.Practice
                             {
                                 Name = pra.Name,
                                 Address = pra.Address,
                                 CreationDate = pra.CreationDate
                             }).ToList();
            return practices;
        }

        public List<CareHub.DataModel.Models.Practice> GetPracticeByLab(long city, string lab)
        {
            var practices = (from pra in _context.Practices
                             where pra.Name.Contains(lab) && pra.CityId == city && pra.PracticeTypeId == 3
                             select new CareHub.DataModel.Models.Practice
                             {
                                 Name = pra.Name,
                                 Address = pra.Address,
                                 CreationDate = pra.CreationDate
                             }).ToList();
            return practices;
        }

        public List<CareHub.DataModel.Models.Practice> GetPracticeByLabLocality(long city, string lab, string locality)
        {
            var practices = (from pra in _context.Practices
                             join loc in _context.Localities on pra.LocalityId equals loc.LocalityId
                             where pra.Name.Contains(lab) && pra.CityId == city && loc.Name.Contains(locality) && pra.PracticeTypeId == 3
                             select new CareHub.DataModel.Models.Practice
                             {
                                 Name = pra.Name,
                                 Address = pra.Address,
                                 CreationDate = pra.CreationDate
                             }).ToList();
            return practices;
        }

        public List<CareHub.DataModel.Models.Practice> GetAllHospitals()
        {
            var practice = (from pra in _context.Practices                            
                            where pra.PracticeTypeId == 2
                            select new CareHub.DataModel.Models.Practice 
                            {
                                Name = pra.Name,
                                PracticeId = pra.PracticeId,                                
                                Address = pra.Address,                                                                                 
                            }).ToList();
            return practice;
        }
        public List<CareHub.DataModel.Models.Practice> GetAllLabs()
        {
            var practice = (from pra in _context.Practices
                            where pra.PracticeTypeId == 3
                            select new CareHub.DataModel.Models.Practice
                            {
                                Name = pra.Name,
                                PracticeId = pra.PracticeId,
                                Address = pra.Address,
                            }).ToList();
            return practice;
        }
        public void Save(Practice entity)
        {
             var data = (from pra in _context.Practices
                        where pra.Name == entity.Name
                        select pra).FirstOrDefault();
             if (data == null)
             { _context.Practices.Add(entity); }
             else
             { throw new Exception("Practice already exist"); }
        }
    }
}
