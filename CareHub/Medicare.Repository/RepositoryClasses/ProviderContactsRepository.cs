﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderContactsRepository : IRepository
    {
        public ProviderContactsRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderContactsRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }       
        public void Update(ProviderContact entity)
        {
            var providerContacts = (from proCon in _context.ProviderContacts
                                    where proCon.ProviderId == entity.ProviderId
                                    select proCon).FirstOrDefault();
            if (providerContacts != null)
            {
                providerContacts.ProviderId = entity.ProviderId;
                providerContacts.PrimaryPhone = entity.PrimaryPhone;
                providerContacts.PrimaryEmail = entity.PrimaryEmail;
                providerContacts.SecondaryPhone = entity.SecondaryPhone;
                providerContacts.SecondaryEmail = entity.SecondaryEmail;
                providerContacts.WebsiteAddress = entity.WebsiteAddress;
            }
            else
            {
                _context.ProviderContacts.Add(entity);
            }
        }
    }
}