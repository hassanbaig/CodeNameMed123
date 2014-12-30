using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.UnitOfWork.Base;
using Medicare.Factory.Factories;
using Medicare.UnitOfWork;
using Medicare.Core.Enumerations;
namespace Medicare.DomainService
{
    public class StaffDomainService : AbstractDomainService
    {        
        private IUnitOfWork unitOfWork;
        private DomainModel.Models.EditProfile editProfile;
        private DomainModel.Models.DoctorEditDetails doctorEditDetails;
        private DomainModel.Models.Staff staff;
        public override AbstractDomainModel Save(AbstractDomainModel domainModel, Medicare.Factory.Enumerations.DomainModelEnum domainModelType)
        {            
            try
            {
                if (domainModel != null)
                {
                    FactoryFacade factory = new FactoryFacade();
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_SPECIALIZATIONS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Save(doctorEditDetails);
                            //unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_LANGUAGES:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Save(doctorEditDetails);
                            //unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_SPECIALIZATIONS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_LANGUAGES:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
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
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_SPECIALIZATIONS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_LANGUAGES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }                
            }

            switch (domainModelType)
            {
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_SPECIALIZATIONS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_LANGUAGES:
                    return doctorEditDetails;
                default:
                    break;
            }
            return null;                        
        }

        public override AbstractDomainModel Update(AbstractDomainModel domainModel, Medicare.Factory.Enumerations.DomainModelEnum domainModelType)
        {                      
            try
            {
                if (domainModel != null)
                {
                    FactoryFacade factory = new FactoryFacade();
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_DETAILS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;

                            if (doctorEditDetails.DoctorDetailsDoctorName == null || doctorEditDetails.DoctorDetailsDoctorName.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Doctor name is required.";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                unitOfWork.Update(doctorEditDetails);
                                unitOfWork.Commit();
                                doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONTACTS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.DoctorContactsPrimaryPhone == null || doctorEditDetails.DoctorContactsPrimaryPhone.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Primary phone is required.";
                            }
                            else if (doctorEditDetails.DoctorContactsPrimaryEmail == null || doctorEditDetails.DoctorContactsPrimaryEmail.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Primary email id is required.";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                unitOfWork.Update(doctorEditDetails);
                                unitOfWork.Commit();
                                doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONSULTATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been updated successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                            editProfile = (DomainModel.Models.EditProfile)domainModel;
                            if (editProfile.FirstName == null || editProfile.FirstName.Length <= 0)
                            { editProfile.ResponseMessage = "First Name is required."; }
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
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.EditProfileUOW));
                                unitOfWork.Update(editProfile);
                                unitOfWork.Commit();
                                editProfile.ResponseMessage = "Profile updated successfully.";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_SPECIALIZATIONS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_LANGUAGES:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TREATMENTS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.DoctorTreatmentsTreatmentName == null || doctorEditDetails.DoctorTreatmentsTreatmentName.Length <= 0)
                            { doctorEditDetails.ResponseMessage = "Treatment name is required."; }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                unitOfWork.Update(doctorEditDetails);
                                unitOfWork.Commit();
                                doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_EDIT_TREATMENTS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;

                            if (doctorEditDetails.DoctorTreatmentsTreatmentName == null || doctorEditDetails.DoctorTreatmentsTreatmentName.Length <= 0)
                            { doctorEditDetails.ResponseMessage = "Treatment name is required."; }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                unitOfWork.Update(doctorEditDetails);
                                unitOfWork.Commit();
                                doctorEditDetails.ResponseMessage = "Information has been updated successfully.";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EDUCATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EXPERIENCE:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AFFILIATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AWARD:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Update(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been added successfully.";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_DETAILS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONTACTS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONSULTATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                            editProfile.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_SPECIALIZATIONS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_LANGUAGES:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TREATMENTS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_EDIT_TREATMENTS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EDUCATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EXPERIENCE:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AFFILIATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AWARD:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
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
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_DETAILS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONTACTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONSULTATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_SPECIALIZATIONS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_LANGUAGES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TREATMENTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_EDIT_TREATMENTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EDUCATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EXPERIENCE:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AFFILIATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AWARD:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }                
            }
            switch (domainModelType)
            {
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_DETAILS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONTACTS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONSULTATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE:
                    return editProfile;              
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_SPECIALIZATIONS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_LANGUAGES:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TREATMENTS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_EDIT_TREATMENTS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EDUCATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EXPERIENCE:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AFFILIATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AWARD:
                    return doctorEditDetails; 
                default:
                    break;
            }
            return null;
        }

        public override AbstractDomainModel Delete(AbstractDomainModel domainModel, Medicare.Factory.Enumerations.DomainModelEnum domainModelType)
        {   
            try
            {
                if (domainModel != null)
                {
                    FactoryFacade factory = new FactoryFacade();
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_SPECIALIZATIONS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_LANGUAGES:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_TREATMENTS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EDUCATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EXPERIENCE:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AFFILIATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AWARD:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                            unitOfWork.Delete(doctorEditDetails);
                            unitOfWork.Commit();
                            doctorEditDetails.ResponseMessage = "Information has been removed successfully.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_REMOVE_FROM_PROVIDERS:
                            staff = (DomainModel.Models.Staff)domainModel;
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.StaffUOW));
                            unitOfWork.Delete(staff);
                            unitOfWork.Commit();
                            staff.ResponseMessage = "Information has been removed successfully.";
                            break;
                        default:
                            break;
                    }         
                }
                else
                {
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_SPECIALIZATIONS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_LANGUAGES:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_TREATMENTS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EDUCATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EXPERIENCE:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AFFILIATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AWARD:
                            doctorEditDetails.ResponseMessage = "Invalid domain model.";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_REMOVE_FROM_PROVIDERS:
                            staff.ResponseMessage = "Invalid domain model.";
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
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_SPECIALIZATIONS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_LANGUAGES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_TREATMENTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EDUCATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EXPERIENCE:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AFFILIATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AWARD:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_REMOVE_FROM_PROVIDERS:
                        staff.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
            }
            switch (domainModelType)
            {
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_SPECIALIZATIONS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_LANGUAGES:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_TREATMENTS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EDUCATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EXPERIENCE:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AFFILIATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AWARD:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_REMOVE_FROM_PROVIDERS:
                    return staff;
                default:
                    break;
            }
            return null;       
        }
        public override AbstractDomainModel Query(AbstractDomainModel domainModel, Medicare.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            try
            {
                if (domainModel != null)
                {
                    FactoryFacade factory = new FactoryFacade();
                    switch (domainModelType)
                    {
                        case Medicare.Factory.Enumerations.DomainModelEnum.PROFILE_DETAILS:
                            editProfile = (DomainModel.Models.EditProfile)domainModel;
                            if (editProfile.UserId == null || editProfile.UserId.Length <= 0)
                            {
                                editProfile.ResponseMessage = "User id is required";
                            }
                            else if (editProfile.ProviderId <= 0)
                            {
                                editProfile.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.EditProfileUOW));
                                editProfile.ProfileDetails = (DomainModel.Models.EditProfile)unitOfWork.Get(editProfile);
                                editProfile.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_DETAILS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails.DoctorInfo = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONTACTS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails.DoctorInfo = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONSULTATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails.DoctorInfo = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_SPECIALIZATIONS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_LANGUAGES:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_TREATMENTS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EDUCATION:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EXPERIENCE:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AFFILIATIONS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AWARDS:
                            doctorEditDetails = (DomainModel.Models.DoctorEditDetails)domainModel;
                            if (doctorEditDetails.UserId == null || doctorEditDetails.UserId.Length <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "User id is required";
                            }
                            else if (doctorEditDetails.ProviderId <= 0)
                            {
                                doctorEditDetails.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                                doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.Get(doctorEditDetails);
                                doctorEditDetails.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_DOCTORS:
                            staff = (DomainModel.Models.Staff)domainModel;
                            if (staff.UserId == null || staff.UserId.Length <= 0)
                            {
                                staff.ResponseMessage = "User id is required";
                            }
                            else if (staff.ProviderId <= 0)
                            {
                                staff.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.StaffUOW));
                                staff = (DomainModel.Models.Staff)unitOfWork.Get(staff);
                                staff.ResponseMessage = "Valid";
                            }
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_STAFF:
                            staff = (DomainModel.Models.Staff)domainModel;
                            if (staff.UserId == null || staff.UserId.Length <= 0)
                            {
                                staff.ResponseMessage = "User id is required";
                            }
                            else if (staff.ProviderId <= 0)
                            {
                                staff.ResponseMessage = "Provider id is required";
                            }
                            else
                            {
                                unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.StaffUOW));
                                staff = (DomainModel.Models.Staff)unitOfWork.Get(staff);
                                staff.ResponseMessage = "Valid";
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
                        case Medicare.Factory.Enumerations.DomainModelEnum.PROFILE_DETAILS:
                            editProfile.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_DETAILS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONTACTS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONSULTATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_SPECIALIZATIONS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_LANGUAGES:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_TREATMENTS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EDUCATION:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EXPERIENCE:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AFFILIATIONS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AWARDS:
                            doctorEditDetails.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_DOCTORS:
                            staff.ResponseMessage = "Invalid domain model";
                            break;
                        case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_STAFF:
                            staff.ResponseMessage = "Invalid domain model";
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
                    case Medicare.Factory.Enumerations.DomainModelEnum.PROFILE_DETAILS:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_DETAILS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONTACTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONSULTATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_SPECIALIZATIONS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_LANGUAGES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_TREATMENTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EDUCATION:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EXPERIENCE:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AFFILIATIONS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AWARDS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_DOCTORS:
                        staff.ResponseMessage = ex.Message;
                        break;
                    case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_STAFF:
                        staff.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
            }

            switch (domainModelType)
            {
                case Medicare.Factory.Enumerations.DomainModelEnum.PROFILE_DETAILS:
                    return editProfile;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_DETAILS:                 
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONTACTS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONSULTATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_SPECIALIZATIONS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_LANGUAGES:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_TREATMENTS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EDUCATION:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EXPERIENCE:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AFFILIATIONS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AWARDS:
                    return doctorEditDetails;
                case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_DOCTORS:
                    return staff;
                case Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_STAFF:
                    return staff;
                default:
                    break;
            }
            return null;  // Just to fullfill the syntactical requirements, this return will never hit in any case.
        }

        public override AbstractDomainModel Query(AbstractDomainModel domainModel, Factory.Enumerations.DomainModelEnum domainModelType, SearchCriteriaEnum searchCriteria)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Query(SearchCriteriaEnum searchCriteria)
        {
            editProfile = new DomainModel.Models.EditProfile();
            doctorEditDetails = new DomainModel.Models.DoctorEditDetails();

            FactoryFacade factory = new FactoryFacade();
            try
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_REGISTRATION_COUNCILS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        return doctorEditDetails;                        
                    case SearchCriteriaEnum.GET_COUNTRIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.EditProfileUOW));
                        editProfile = (DomainModel.Models.EditProfile)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_STATES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.EditProfileUOW));
                        editProfile = (DomainModel.Models.EditProfile)unitOfWork.GetAll(searchCriteria);
                        break;                    
                    case SearchCriteriaEnum.GET_CITIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.EditProfileUOW));
                        editProfile = (DomainModel.Models.EditProfile)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_LOCALITIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.EditProfileUOW));
                        editProfile = (DomainModel.Models.EditProfile)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_SPECIALTIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_LANGUAGES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_PARENT_TREATMENTS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_TREATMENTS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_DEGREES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_COLLEGES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_AFFILIATIONS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_AWARDS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(Medicare.UnitOfWork.DoctorEditDetailsUOW));
                        doctorEditDetails = (DomainModel.Models.DoctorEditDetails)unitOfWork.GetAll(searchCriteria);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_REGISTRATION_COUNCILS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_COUNTRIES:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_STATES:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_CITIES:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_LOCALITIES:
                        editProfile.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_SPECIALTIES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_LANGUAGES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_PARENT_TREATMENTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_TREATMENTS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_DEGREES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_COLLEGES:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_AFFILIATIONS:
                        doctorEditDetails.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_AWARDS:
                        doctorEditDetails.ResponseMessage = ex.Message;
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
                case SearchCriteriaEnum.GET_REGISTRATION_COUNCILS:                    
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_COUNTRIES:
                    return editProfile;
                case SearchCriteriaEnum.GET_STATES:
                    return editProfile;
                case SearchCriteriaEnum.GET_CITIES:
                    return editProfile;
                case SearchCriteriaEnum.GET_LOCALITIES:
                    return editProfile;
                case SearchCriteriaEnum.GET_SPECIALTIES:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_LANGUAGES:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_PARENT_TREATMENTS:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_TREATMENTS:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_DEGREES:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_COLLEGES:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_AFFILIATIONS:
                    return doctorEditDetails;
                case SearchCriteriaEnum.GET_AWARDS:
                    return doctorEditDetails;
                default:
                    break;
            }
            return null;          
        }
    }
}
