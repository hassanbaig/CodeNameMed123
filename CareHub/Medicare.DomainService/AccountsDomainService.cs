using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.UnitOfWork.Base;
using CareHub.Factory.Factories;
using CareHub.UnitOfWork;
using CareHub.Core.Enumerations;
namespace CareHub.DomainService
{
    public class AccountsDomainService : AbstractDomainService
    {

        private IUnitOfWork unitOfWork;
        public override AbstractDomainModel Save(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            DomainModel.Models.ProviderRegistration providerRegistration = (DomainModel.Models.ProviderRegistration)domainModel;
            try
            {
                if (domainModel != null)
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.PROVIDER_REGISTRATION:
                            if (providerRegistration.Name == null || providerRegistration.Name.Length <= 0)
                            { providerRegistration.ResponseMessage = "Name is required."; }
                            else if (providerRegistration.Password == null || providerRegistration.Password.Length <= 0)
                            { providerRegistration.ResponseMessage = "Password is required."; }
                            else if (providerRegistration.ClinicName == null || providerRegistration.ClinicName.Length <= 0)
                            { providerRegistration.ResponseMessage = "Clinic name is required."; }
                            else if (providerRegistration.SpecialtyId <= 0)
                            { providerRegistration.ResponseMessage = "Specialty is required."; }
                            else if (providerRegistration.CityId <= 0)
                            { providerRegistration.ResponseMessage = "City is required."; }
                            else if (providerRegistration.LocalityId <= 0)
                            { providerRegistration.ResponseMessage = "Area is required."; }
                            else
                            {
                                FactoryFacade factory = new FactoryFacade();
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ProviderRegistrationUOW));
                                unitOfWork.Save(providerRegistration);
                                unitOfWork.Commit();
                                providerRegistration.ResponseMessage = "Registration is successful.";

                                CareHub.Core.ConfigurationEmails.ConfigurationEmail.SignupEmail(providerRegistration.Name, providerRegistration.Password, providerRegistration.Email);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.PROVIDER_REGISTRATION:
                            providerRegistration.ResponseMessage = "Invalid domain model.";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                switch (domainModelType)
                {
                    case CareHub.Factory.Enumerations.DomainModelEnum.PROVIDER_REGISTRATION:
                        providerRegistration.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }

            }
            switch (domainModelType)
            {
                case CareHub.Factory.Enumerations.DomainModelEnum.PROVIDER_REGISTRATION:
                    return providerRegistration;
                default:
                    break;
            }
            return null;
        }

        public override AbstractDomainModel Update(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            DomainModel.Models.ChangePassword changePassword = (DomainModel.Models.ChangePassword)domainModel;
            DomainModel.Models.ForgotPassword forgotPassword = (DomainModel.Models.ForgotPassword)domainModel;
            DomainModel.Models.EditProfile editProfile = (DomainModel.Models.EditProfile)domainModel;
            try
            {
                if (domainModel != null)
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.CHANGE_PASSWORD:
                            if (changePassword.CurrentPassword == null || changePassword.CurrentPassword.Length <= 0)
                            { changePassword.ResponseMessage = "Current password is required."; }
                            else if (changePassword.NewPassword == null || changePassword.NewPassword.Length <= 0)
                            { changePassword.ResponseMessage = "New password is required."; }
                            else
                            {
                                FactoryFacade factory = new FactoryFacade();
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ChangePasswordUOW));
                                unitOfWork.Update(changePassword);
                                unitOfWork.Commit();
                                CareHub.Core.ConfigurationEmails.ConfigurationEmail.ChangePasswordEmail(changePassword.UserId, changePassword.NewPassword, changePassword.UserId);
                                changePassword.ResponseMessage = "Password changed successfully";
                            }
                            break;
                        case CareHub.Factory.Enumerations.DomainModelEnum.FORGOT_PASSWORD:
                            //  if (forgotPassword.CurrentPassword == null || forgotPassword.CurrentPassword.Length <= 0)
                            // { message = "Current password is required"; }
                            if (forgotPassword.NewPassword == null || forgotPassword.NewPassword.Length <= 0)
                            {
                                forgotPassword.ResponseMessage = "New password is required";
                            }
                            else
                            {
                                FactoryFacade factory = new FactoryFacade();
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ForgotPasswordUOW));
                                unitOfWork.Update(forgotPassword);
                                unitOfWork.Commit();

                                /*  DomainModel.Models.ProviderRegistration providerRegistration = new DomainModel.Models.ProviderRegistration();
                                  unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ProviderRegistrationUOW));
                                  providerRegistration = (DomainModel.Models.ProviderRegistration)unitOfWork.Get(providerRegistration);
                                 */
                                CareHub.Core.ConfigurationEmails.ConfigurationEmail.ForgotPasswordEmail(forgotPassword.UserId, forgotPassword.NewPassword, forgotPassword.UserId);
                                forgotPassword.ResponseMessage = "New password has been sent successfully";

                            }
                            break;
                        case CareHub.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                            if (editProfile.FirstName == null || editProfile.FirstName.Length <= 0)
                            { editProfile.ResponseMessage = "First name is required."; }
                            else if (editProfile.Gender == 0)
                            { editProfile.ResponseMessage = "Gender is required."; }
                            else if (editProfile.CountryId == 0)
                            { editProfile.ResponseMessage = "Country is required."; }
                            else if (editProfile.StateId == 0)
                            { editProfile.ResponseMessage = "State is required."; }
                            else if (editProfile.CityId == 0)
                            { editProfile.ResponseMessage = "City is required."; }
                            else if (editProfile.LocalityId == 0)
                            { editProfile.ResponseMessage = "Locality is required."; }
                            else
                            {
                                /////////
                                FactoryFacade factory = new FactoryFacade();
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ChangePasswordUOW));
                                unitOfWork.Update(editProfile);
                                unitOfWork.Commit();
                                editProfile.ResponseMessage = "Profile updated successfully.";
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.CHANGE_PASSWORD:
                            changePassword.ResponseMessage = "Invalid domain model.";
                            break;
                        case CareHub.Factory.Enumerations.DomainModelEnum.FORGOT_PASSWORD:
                            forgotPassword.ResponseMessage = "Invalid domain model.";
                            break;
                        case CareHub.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                            editProfile.ResponseMessage = "Invalid domain model.";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                switch (domainModelType)
                {
                    case CareHub.Factory.Enumerations.DomainModelEnum.CHANGE_PASSWORD:
                        changePassword.ResponseMessage = ex.Message;
                        break;
                    case CareHub.Factory.Enumerations.DomainModelEnum.FORGOT_PASSWORD:
                        forgotPassword.ResponseMessage = ex.Message;
                        break;
                    case CareHub.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
            }
            switch (domainModelType)
            {
                case CareHub.Factory.Enumerations.DomainModelEnum.CHANGE_PASSWORD:
                    return changePassword;
                case CareHub.Factory.Enumerations.DomainModelEnum.FORGOT_PASSWORD:
                    return forgotPassword;
                case CareHub.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                    return editProfile;
                default:
                    break;
            }
            return null;
        }

        public override AbstractDomainModel Delete(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Query(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            DomainModel.Models.Authenticate authenticate = (DomainModel.Models.Authenticate)domainModel;
            try
            {
                if (domainModel != null)
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.AUTHENTICATE:
                            if (authenticate.UserId == null || authenticate.UserId.Length <= 0)
                            { authenticate.ResponseMessage = "User id is required"; }
                            else if (authenticate.Password == null || authenticate.Password.Length <= 0)
                            { authenticate.ResponseMessage = "Password is required"; }
                            else
                            {
                                FactoryFacade factory = new FactoryFacade();
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.AuthenticateUOW));
                                authenticate = (DomainModel.Models.Authenticate)unitOfWork.Get(authenticate);
                                authenticate.ResponseMessage = "Valid";
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.AUTHENTICATE:
                            authenticate.ResponseMessage = "Invalid domain model";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                switch (domainModelType)
                {
                    case CareHub.Factory.Enumerations.DomainModelEnum.AUTHENTICATE:
                        authenticate.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
            }
            switch (domainModelType)
            {
                case CareHub.Factory.Enumerations.DomainModelEnum.AUTHENTICATE:
                    return authenticate;
                default:
                    break;
            }
            return null;
        }

        public override AbstractDomainModel Query(AbstractDomainModel domainModel, Factory.Enumerations.DomainModelEnum domainModelType, SearchCriteriaEnum searchCriteria)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Query(SearchCriteriaEnum searchCriteria)
        {
            DomainModel.Models.ProviderRegistration providerRegistration = new DomainModel.Models.ProviderRegistration();
            FactoryFacade factory = new FactoryFacade();
            try
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_SPECIALTIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ProviderRegistrationUOW));
                        providerRegistration = (DomainModel.Models.ProviderRegistration)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_COUNTRIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ProviderRegistrationUOW));
                        providerRegistration = (DomainModel.Models.ProviderRegistration)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_CITIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ProviderRegistrationUOW));
                        providerRegistration = (DomainModel.Models.ProviderRegistration)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_LOCALITIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.ProviderRegistrationUOW));
                        providerRegistration = (DomainModel.Models.ProviderRegistration)unitOfWork.GetAll(searchCriteria);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_SPECIALTIES:
                        providerRegistration.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_COUNTRIES:
                        providerRegistration.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_CITIES:
                        providerRegistration.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_LOCALITIES:
                        providerRegistration.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                factory = null;
            }
            switch (searchCriteria)
            {
                case SearchCriteriaEnum.GET_SPECIALTIES:
                    return providerRegistration;
                case SearchCriteriaEnum.GET_COUNTRIES:
                    return providerRegistration;
                case SearchCriteriaEnum.GET_CITIES:
                    return providerRegistration;
                case SearchCriteriaEnum.GET_LOCALITIES:
                    return providerRegistration;
                default:
                    break;
            }
            return null;
        }
    }
}
