using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderExperienceRepository : IRepository
    {
        public ProviderExperienceRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderExperienceRepository(MedicareDevEntities context)
        {
            _context = context;
        }
        public void Delete(ProviderExperience entity)
        {
            var data = (from proExp in _context.ProviderExperiences
                        where proExp.ProviderId == entity.ProviderId && proExp.Organization == entity.Organization && proExp.Designation == entity.Designation && proExp.CityId == entity.CityId
                        select proExp).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderExperiences.Remove(data);
            }
            else
            { throw new Exception("Education does not exist."); }
        }
        public List<Medicare.DataModel.Models.ProviderExperience> GetProviderExperience(long providerId)
        {
            var data = (from proExp in _context.ProviderExperiences
                        join cit in _context.Cities on proExp.CityId equals cit.CityId
                        where proExp.ProviderId == providerId
                        select new Medicare.DataModel.Models.ProviderExperience
                        {
                            ProviderId = proExp.ProviderId,
                            ProviderExperienceId = proExp.ProviderExperienceId,
                            Designation = proExp.Designation,
                            Organization = proExp.Organization,
                            CityId = proExp.CityId,
                            CityName = cit.Name,
                            StartYear = proExp.StartYear,
                            EndYear = proExp.EndYear
                        }).ToList();

            return data;
        }
        public void AddProviderExperience(ProviderExperience entity)
        {
            var experience = (from proExp in _context.ProviderExperiences
                              where proExp.ProviderId == entity.ProviderId && proExp.Designation == entity.Designation && proExp.Organization == entity.Organization
                              select proExp).FirstOrDefault();
            if (experience == null)
            {
                _context.ProviderExperiences.Add(entity);
            }
            else
            { throw new Exception("Already added"); }
        }      
        public void Save(ProviderExperience entity)
        {
            _context.ProviderExperiences.Add(entity);
        }
    }
}
