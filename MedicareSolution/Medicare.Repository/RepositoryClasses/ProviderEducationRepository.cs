using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderEducationRepository : IRepository
    {
        public ProviderEducationRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderEducationRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }
        public void AddProviderEducation(ProviderEducation entity)
        {
            var education = (from proEdu in _context.ProviderEducations
                             where proEdu.ProviderId == entity.ProviderId && proEdu.DegreeTitle == entity.DegreeTitle && proEdu.SchoolTitle == entity.SchoolTitle
                             select proEdu).FirstOrDefault();
            if (education == null)
            {
                _context.ProviderEducations.Add(entity);
            }
            else
            { throw new Exception("Education already added"); }
        } 
        public List<Medicare.DataModel.Models.ProviderEducation> GetProviderEducation(long providerId)
        {
            var data = (from proedu in _context.ProviderEducations
                        where proedu.ProviderId == providerId
                        select new Medicare.DataModel.Models.ProviderEducation
                        {
                            ProviderId = proedu.ProviderId,
                            ProviderEducationId = proedu.ProviderEducationId,
                            DegreeTitle = proedu.DegreeTitle,
                            DegreeYear = proedu.DegreeYear,
                            SchoolTitle = proedu.SchoolTitle
                        }).ToList();

            return data;
        }
        public void Delete(ProviderEducation entity)
        {
            var data = (from proEdu in _context.ProviderEducations
                        where proEdu.ProviderId == entity.ProviderId && proEdu.DegreeTitle == entity.DegreeTitle && proEdu.SchoolTitle == entity.SchoolTitle
                        select proEdu).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderEducations.Remove(data);
            }
            else
            { throw new Exception("Education does not exist."); }
        }
        public void Save(ProviderEducation entity)
        {
            _context.ProviderEducations.Add(entity);
        } 
    }
}
