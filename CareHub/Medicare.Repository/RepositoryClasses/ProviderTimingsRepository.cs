using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderTimingsRepository : IRepository
    {
        public ProviderTimingsRepository()
        {

        }
       private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderTimingsRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }           
        public void Update(ProviderTiming entity)
        {
            var providerTimings = (from UpdproTim in _context.ProviderTimings
                                   where UpdproTim.ProviderId == entity.ProviderId && UpdproTim.DayoftheWeek == entity.DayoftheWeek
                                   select UpdproTim).FirstOrDefault();
            if (providerTimings != null)
            {
                providerTimings.ProviderId = entity.ProviderId;
                providerTimings.DayoftheWeek = entity.DayoftheWeek;
                providerTimings.StartTime1 = entity.StartTime1;
                providerTimings.StartTime2 = entity.StartTime2;
                providerTimings.EndTime1 = entity.EndTime1;
                providerTimings.EndTime2 = entity.EndTime2;
            }
            else
            {
                _context.ProviderTimings.Add(entity);

               // _context.ProviderAvailabilities.Add(entity);
            }
        }
        public void Remove(long providerId,string day)
        {
            var providerTimings = (from DelproTim in _context.ProviderTimings
                                   where DelproTim.ProviderId == providerId && DelproTim.DayoftheWeek == day
                                   select DelproTim).FirstOrDefault();
            if (providerTimings != null)
            {
                _context.ProviderTimings.Remove(providerTimings);
               ;
            }           
        }        
    }
}
