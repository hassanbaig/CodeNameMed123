﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class DegreeRepository : IRepository
    {
        public DegreeRepository()
        {

        }
       private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }

        public DegreeRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }     
        public List<Medicare.DataModel.Models.Degree> GetAll()
        {
            var degrees = (from deg in _context.Degrees
                             select new Medicare.DataModel.Models.Degree
                             {
                                 DegreeId = deg.DegreeId,
                                 Title = deg.Title,
                                 Description = deg.Description
                             }).ToList();
            return degrees;
        }
    }
}