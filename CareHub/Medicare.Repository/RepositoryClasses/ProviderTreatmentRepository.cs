using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderTreatmentRepository : IRepository
    {
        public ProviderTreatmentRepository()
        {

        }
        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderTreatmentRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }
        public void AddProviderTreatments(ProviderTreatment entity)
        {
            var data = (from proTre in _context.ProviderTreatments
                        where proTre.ProviderId == entity.ProviderId && proTre.TreatmentId == entity.TreatmentId
                        select proTre).FirstOrDefault();

            if (data == null)
            { _context.ProviderTreatments.Add(entity);
            }
            else
            { throw new Exception("Treatment already added."); }
        }
        public void Save(ProviderTreatment entity)
        {
            _context.ProviderTreatments.Add(entity);
        }
        public void Delete(ProviderTreatment entity)
        {
            var data = (from proTre in _context.ProviderTreatments
                        where proTre.ProviderId == entity.ProviderId && proTre.TreatmentId == entity.TreatmentId
                        select proTre).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderTreatments.Remove(data);
            }
            else
            { throw new Exception("Treatment does not exist."); }
        }
    }
}
