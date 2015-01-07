﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderSpecialtyRepository : IRepository
    {
        public ProviderSpecialtyRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderSpecialtyRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }
        public void AddProviderSpecialties(ProviderSpecialty entity)
        {
            var data = (from proSpe in _context.ProviderSpecialties
                        where proSpe.ProviderId == entity.ProviderId && proSpe.SpecialtyId == entity.SpecialtyId
                        select proSpe).FirstOrDefault();

            if (data == null)
            { _context.ProviderSpecialties.Add(entity); }
            else
            { throw new Exception("Specialty already added."); }
        }
        public void Save(ProviderSpecialty entity)
        {
            _context.ProviderSpecialties.Add(entity);
        }
        public void Delete(ProviderSpecialty entity)
        {
            var data = (from proSpe in _context.ProviderSpecialties
                        where proSpe.ProviderId == entity.ProviderId && proSpe.SpecialtyId == entity.SpecialtyId
                        select proSpe).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderSpecialties.Remove(data);
            }
            else
            { throw new Exception("Specialty does not exist."); }
        }
    }
}
