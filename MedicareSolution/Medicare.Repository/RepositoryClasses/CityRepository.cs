﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class CityRepository : IRepository
    {
        public CityRepository()
        {

        }
        private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }      
        public string GetNameById(long cityId)
        {
            var cityName = (from cit in _context.Cities
                            where cit.CityId == cityId
                            select cit.Name).FirstOrDefault();
            if (cityName != null || cityName != "" || cityName != string.Empty)
            { return cityName; }
            else
            { throw new Exception("City does not exist"); }
        }
        public List<Medicare.DataModel.Models.City> GetCitiesByCountry(int countryId)
        {
            var data = (from cit in _context.Cities
                        where cit.CountryId == countryId
                        select new Medicare.DataModel.Models.City
                        {
                            CityId = cit.CityId,
                            CountryId = cit.CountryId,
                            Name = cit.Name
                        }).ToList();
            if (data.Count() > 0)
            { return data; }
            else
            { throw new Exception("Cities do not exist"); }
        }
        public List<Medicare.DataModel.Models.City> GetAll()
        {
            var data = (from cit in _context.Cities
                        select new Medicare.DataModel.Models.City 
                        {
                            CityId = cit.CityId,
                            CountryId = cit.CountryId,
                            Name = cit.Name
                        }).ToList();
            return data;
        }
    }
}