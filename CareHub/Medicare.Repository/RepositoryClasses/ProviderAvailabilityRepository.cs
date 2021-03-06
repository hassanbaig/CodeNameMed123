﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderAvailabilityRepository : IRepository
    {
        public ProviderAvailabilityRepository()
        {

        }
       private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderAvailabilityRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }           
        public void Update(ProviderAvailability entity)
        {
            var providerAvailability = (from proAva in _context.ProviderAvailabilities
                                        where proAva.ProviderId == entity.ProviderId && proAva.DayoftheWeek == entity.DayoftheWeek
                                        select proAva).FirstOrDefault();
            if (providerAvailability != null)
            {
                providerAvailability.ProviderId = entity.ProviderId;
                providerAvailability.DayoftheWeek = entity.DayoftheWeek;
                providerAvailability.StartTime1 = entity.StartTime1;
                providerAvailability.StartTime2 = entity.StartTime2;
                providerAvailability.EndTime1 = entity.EndTime1;
                providerAvailability.EndTime2 = entity.EndTime2;
            }
            else
            {
                _context.ProviderAvailabilities.Add(entity);
            }
        }
        public void Remove(long providerId,string day)
        {
            var providerAvailability = (from proAva in _context.ProviderAvailabilities
                                        where proAva.ProviderId == providerId && proAva.DayoftheWeek == day
                                        select proAva).FirstOrDefault();
            if (providerAvailability != null)
            {
                _context.ProviderAvailabilities.Remove(providerAvailability);
            }           
        }        
    }
}
