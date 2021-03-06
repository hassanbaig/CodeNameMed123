﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class LocalityRepository : IRepository
    {
        public LocalityRepository()
        {

        }

        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }      
        public List<CareHub.DataModel.Models.Locality> GetLocalitiesByCountryCity(int country, long city)
        {
            var data = (from loc in _context.Localities
                        where loc.CityId == city && loc.CountryId == country
                        select new CareHub.DataModel.Models.Locality
                        {
                            CityId = loc.CityId,
                            LocalityId = loc.LocalityId,
                            Name = loc.Name
                        }).ToList();
            if (data.Count() > 0)
            { return data; }
            else
            { throw new Exception("Localities do not exist"); }
        }
        public List<CareHub.DataModel.Models.Locality> GetAll()
        {
            var data = (from loc in _context.Localities
                        select new CareHub.DataModel.Models.Locality 
                        {
                            CityId = loc.CityId,
                            LocalityId = loc.LocalityId,
                            Name = loc.Name
                        }).ToList();
            return data;
        }
    }
}
