using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class TreatmentRepository : IRepository
    {
        public TreatmentRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }
        public TreatmentRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }
        public long GetTreatmentIdByName(string Name)
        {
            var treatmentId = (from tre in _context.Treatments
                               where tre.Name == Name
                               select tre.TreatmentId).FirstOrDefault();
            return treatmentId;
        }
        public List<CareHub.DataModel.Models.Treatment> GetAllParentTreatments()
        {
            var data = (from tre in _context.Treatments
                             where tre.ParentId == null || tre.ParentId == 0
                             select new CareHub.DataModel.Models.Treatment
                             {
                                 Name = tre.Name,
                                 TreatmentId = tre.TreatmentId
                             }).ToList();
            return data;
        }
        public List<CareHub.DataModel.Models.Treatment> GetAll()
        {
            var data = (from tre in _context.Treatments
                             select new CareHub.DataModel.Models.Treatment
                             {
                                 Name = tre.Name,
                                 TreatmentId = tre.TreatmentId
                             }).ToList();
            return data;
        }

        public void Update(Treatment entity)
        {
            var treatment = (from tre in _context.Treatments
                             where tre.TreatmentId == entity.TreatmentId
                             select tre).FirstOrDefault();
            if (treatment != null)
            {
                treatment.Name = entity.Name;
                treatment.Cost = entity.Cost;
                treatment.Tax = entity.Tax;
                treatment.ParentId = entity.ParentId;
                treatment.Notes = entity.Notes;
            }
            else
            { throw new Exception("Treatment not found"); }
        }
        public long AddTreatmentGetId(Treatment entity)
        {
            long treatmentId = 0;
            var data = (from tre in _context.Treatments
                        where tre.Name == entity.Name
                        select tre).FirstOrDefault();

            if (data == null)
            {
                _context.Treatments.Add(entity);
                _context.SaveChanges();
                treatmentId = entity.TreatmentId;
            }
            else
            {
                treatmentId = data.TreatmentId;
            }
            return treatmentId;
        }         
        public void Save(Treatment entity)
        {
            _context.Treatments.Add(entity);
        }
    }
}
