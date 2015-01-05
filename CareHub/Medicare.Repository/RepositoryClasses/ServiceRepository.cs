using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ServiceRepository : IRepository
    {
        public ServiceRepository()
        {

        }

        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }
        public List<CareHub.DataModel.Models.Service> Save(Service entity)
        {

            var data = (from ser in _context.Services
                        where ser.Title == entity.Title
                        select ser).FirstOrDefault();
            if (data == null)
            {
                _context.Services.Add(entity);
                _context.SaveChanges();

                var service = (from ser in _context.Services
                               select new CareHub.DataModel.Models.Service
                               {
                                   Description = ser.Description,
                                   ServiceId = ser.ServiceId,
                                   Title = ser.Title
                               }).ToList();

                return service;
            }
            else
            { throw new Exception("Service already exist"); }
        } 
        public List<CareHub.DataModel.Models.Service> GetAllServices()
        {
            var data = (from ser in _context.Services
                        where ser.ServiceTypeId == 1
                        select new CareHub.DataModel.Models.Service
                        {
                            Description = ser.Description,
                            ServiceId = ser.ServiceId,
                            Title = ser.Title
                        }).ToList();

            return data;
        }
        public List<CareHub.DataModel.Models.Service> GetAllTravelServices()
        {
            var data = (from ser in _context.Services
                        where ser.ServiceTypeId == 2
                        select new CareHub.DataModel.Models.Service
                        {
                            Description = ser.Description,
                            ServiceId = ser.ServiceId,
                            Title = ser.Title
                        }).ToList();

            return data;
        }
    }
}
