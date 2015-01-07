using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class CountryRepository : IRepository
    {
        public CountryRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }      
        public string GetNameById(int countryId)
        {
            var countryName = (from cou in _context.Countries
                               where cou.CountryId == countryId
                               select cou.Name).FirstOrDefault();
            if (countryName != null || countryName != "" || countryName != string.Empty)
            { return countryName; }
            else
            { throw new Exception("Country does not exist"); }
        }

        public List<CareHub.DataModel.Models.Country> GetAll()
        {
            var data = (from cou in _context.Countries
                        select new CareHub.DataModel.Models.Country 
                        {
                            CountryId = cou.CountryId,
                            Name = cou.Name
                        }).ToList();
            return data;
        }
    }
}
