using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class BillingCurrencyRepository : IRepository
    {
        public BillingCurrencyRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public string GetNameById(int billingCurrencyID)
        {
            var currencyName = (from cur in _context.BillingCurrencies
                               where cur.BillingCurrencyId == billingCurrencyID
                               select cur.Name).FirstOrDefault();
            if (currencyName != null || currencyName != "" || currencyName != string.Empty)
            { return currencyName; }
            else
            { throw new Exception("Billing Currency does not exist"); }
        }

        public List<CareHub.DataModel.Models.BillingCurrency> GetAll()
        {
            var data = (from bilcur in _context.BillingCurrencies
                        select new CareHub.DataModel.Models.BillingCurrency 
                        {
                            BillingCurrencyId = bilcur.BillingCurrencyId,
                            Name = bilcur.Name,
                            Description = bilcur.Description
                        }).ToList();
            return data;
        }
    }
}
