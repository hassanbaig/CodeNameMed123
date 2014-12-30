using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;
using Medicare.UnitOfWork.Base;
using Medicare.DomainModel.Models;
using Medicare.Repository.RepositoryClasses;
using Medicare.Core.Common;
namespace Medicare.UnitOfWork
{
    public class AuthenticateUOW : BaseUnitOfWork, IUnitOfWork
    {
        private UserRepository userRepository;
        private ProviderRepository providerRepository;
        private Authenticate authenticate;
        public AuthenticateUOW()
            : base()
        {
            if (base.Context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            else
            {
                ((IUnitOfWork)this).InitializeRepositories();
            }
        }
        public AuthenticateUOW(shiner49_medicareEntities context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            else
            {
                ((IUnitOfWork)this).InitializeRepositories();
            }
        }

        void IUnitOfWork.InitializeRepositories()
        {
            userRepository = (UserRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(UserRepository));
            providerRepository = (ProviderRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderRepository));
            userRepository.DataContext = base.Context;
            providerRepository.DataContext = base.Context;
        }


        void IUnitOfWork.Save(AbstractDomainModel domainModel)
        {
            throw new NotImplementedException();            
        }

        void IUnitOfWork.SaveAll()
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.Delete(AbstractDomainModel domainModel)
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.Update(AbstractDomainModel domainModel)
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.Commit()
        {
            base.Commit();
        }

        void IUnitOfWork.Add(AbstractDomainModel domainModel)
        {
            base.Add(domainModel);
        }

        void IUnitOfWork.Remove(AbstractDomainModel domainModel)
        {
            base.Remove(domainModel);
        }


        public AbstractDomainModel Get(AbstractDomainModel domainModel)
        {
            authenticate = (DomainModel.Models.Authenticate)domainModel;
            string encryptedPass = Encryption.Encrypt("#", authenticate.Password);
            User user = userRepository.GetUser(authenticate.UserId, encryptedPass);
            if (user != null)
            {
                Medicare.DataModel.Models.Provider provider = new Medicare.DataModel.Models.Provider();

                switch (user.UserRoleId)
                {
                    case 1:
                        provider = providerRepository.GetProviderByUserId(authenticate.UserId);
                        if (provider != null)
                        {
                            authenticate.ProviderId = provider.ProviderId;
                        }

                        else
                        {
                            throw new Exception("Please check login credentials and then try again.");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new Exception("Please check login credentials and then try again.");
            }

            return authenticate;
        }
        public AbstractDomainModel GetAll(Core.Enumerations.SearchCriteriaEnum searchCriteria)
        {
            throw new NotImplementedException();
        }
    }
}