using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderAwardRepository : IRepository
    {
        public ProviderAwardRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderAwardRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }
        public void AddProviderAward(ProviderAward entity)
        {
            var award = (from proAwa in _context.ProviderAwards
                         join awa in _context.Awards on proAwa.AwardId equals awa.AwardId
                         where proAwa.ProviderId == entity.ProviderId && awa.AwardId == entity.AwardId
                         select proAwa).FirstOrDefault();
            if (award == null)
            {
                _context.ProviderAwards.Add(entity);
            }
            else
            { throw new Exception("Award already added"); }
        }      
        public List<Medicare.DataModel.Models.ProviderAward> GetProviderAwards(long providerId)
        {
            var data = (from proAwa in _context.ProviderAwards
                        join awa in _context.Awards on proAwa.AwardId equals awa.AwardId
                        where proAwa.ProviderId == providerId
                        select new Medicare.DataModel.Models.ProviderAward
                        {
                            ProviderId = proAwa.ProviderId,
                            ProviderAwardId = proAwa.ProviderAwardId,
                            AwardId = awa.AwardId,
                            Name = awa.Name,
                            Description = awa.Description,
                            Year = proAwa.Year                            
                        }).ToList();

            return data;
        }
        public void Delete(ProviderAward entity)
        {
            var data = (from proAwa in _context.ProviderAwards
                        where proAwa.ProviderId == entity.ProviderId && proAwa.AwardId == entity.AwardId
                        select proAwa).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderAwards.Remove(data);
            }
            else
            { throw new Exception("Award does not exist."); }
        }
    }
}
