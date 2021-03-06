﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class RegistrationCouncilRepository : IRepository
    {
        public RegistrationCouncilRepository()
        {

        }

        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public List<CareHub.DataModel.Models.RegistrationCouncil> GetAll()
        {
            var data = (from regCou in _context.RegistrationCouncils
                        select new CareHub.DataModel.Models.RegistrationCouncil 
                        {
                            Name = regCou.Name,
                            Description = regCou.Description,
                            RegistrationCouncilId = regCou.RegistrationCouncilId
                        }).ToList();
            return data;
        }
    }
}
