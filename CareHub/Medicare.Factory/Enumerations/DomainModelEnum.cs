﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.Factory.Enumerations
{
    public enum DomainModelEnum
    {
        PROVIDER_REGISTRATION,       
        CHANGE_PASSWORD,
        FORGOT_PASSWORD,
        AUTHENTICATE,
        EDIT_PROFILE,
        PROFILE_DETAILS,
        DOCTOR_SEARCH,
        PRACTICE_SEARCH,

        PRACTICE_EDIT_DETAILS_GET_DETAILS,
        PRACTICE_EDIT_DETAILS_ADD_DETAILS,

        PRACTICE_EDIT_DETAILS_GET_LOCATION,

        PRACTICE_EDIT_DETAILS_GET_PROVIDER_PRACTICES,

        PRACTICE_EDIT_DETAILS_GET_CONTACTS,

        PRACTICE_EDIT_DETAILS_ADD_CONTACTS,

        PRACTICE_EDIT_DETAILS_GET_ADDED_LANGUAGES,
        PRACTICE_EDIT_DETAILS_ADD_LANGUAGES,
        PRACTICE_EDIT_DETAILS_ADD_TO_LANGUAGES,
        PRACTICE_EDIT_DETAILS_REMOVE_FROM_LANGUAGES,

        PRACTICE_EDIT_DETAILS_GET_ADDED_PREMISES,
        PRACTICE_EDIT_DETAILS_ADD_PREMISES,
        PRACTICE_EDIT_DETAILS_ADD_TO_PREMISES,
        PRACTICE_EDIT_DETAILS_REMOVE_FROM_PREMISES,

        PRACTICE_EDIT_DETAILS_GET_ADDED_ACCREDITATIONS,
        PRACTICE_EDIT_DETAILS_ADD_ACCREDITATIONS,
        PRACTICE_EDIT_DETAILS_ADD_TO_ACCREDITATIONS,
        PRACTICE_EDIT_DETAILS_REMOVE_FROM_ACCREDITATIONS,

        PRACTICE_EDIT_DETAILS_GET_ADDED_INSURANCES,
        PRACTICE_EDIT_DETAILS_ADD_INSURANCES,
        PRACTICE_EDIT_DETAILS_ADD_TO_INSURANCES,
        PRACTICE_EDIT_DETAILS_REMOVE_FROM_INSURANCES,

        PRACTICE_EDIT_DETAILS_GET_ADDED_SERVICES,
        PRACTICE_EDIT_DETAILS_ADD_SERVICES,
        PRACTICE_EDIT_DETAILS_ADD_TO_SERVICES,
        PRACTICE_EDIT_DETAILS_REMOVE_FROM_SERVICES,


        PRACTICE_EDIT_DETAILS_GET_ADDED_TRAVEL_SERVICES,
        PRACTICE_EDIT_DETAILS_ADD_TRAVEL_SERVICES,
        PRACTICE_EDIT_DETAILS_ADD_TO_TRAVEL_SERVICES,
        PRACTICE_EDIT_DETAILS_REMOVE_FROM_TRAVEL_SERVICES,

        PRACTICE_EDIT_DETAILS_ADD_TO_TIMINGS,
        PRACTICE_EDIT_DETAILS_GET_ADDED_TIMINGS,
        
        DOCTOR_EDIT_DETAILS_GET_DETAILS,
        DOCTOR_EDIT_DETAILS_ADD_DETAILS,
        DOCTOR_EDIT_DETAILS_GET_CONTACTS,
        DOCTOR_EDIT_DETAILS_ADD_CONTACTS,
        DOCTOR_EDIT_DETAILS_GET_CONSULTATION,
        DOCTOR_EDIT_DETAILS_ADD_CONSULTATION,
        DOCTOR_EDIT_DETAILS_ADD_SPECIALIZATIONS,
        DOCTOR_EDIT_DETAILS_GET_ADDED_SPECIALIZATIONS,
        DOCTOR_EDIT_DETAILS_ADD_TO_SPECIALIZATIONS,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_SPECIALIZATIONS,     
        DOCTOR_EDIT_DETAILS_ADD_LANGUAGES,
        DOCTOR_EDIT_DETAILS_GET_ADDED_LANGUAGES,
        DOCTOR_EDIT_DETAILS_ADD_TO_LANGUAGES,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_LANGUAGES,
        DOCTOR_EDIT_DETAILS_GET_ADDED_TREATMENTS,
        DOCTOR_EDIT_DETAILS_GET_ADDED_EDUCATION,
        DOCTOR_EDIT_DETAILS_GET_ADDED_EXPERIENCE,
        DOCTOR_EDIT_DETAILS_GET_ADDED_AFFILIATIONS,
        DOCTOR_EDIT_DETAILS_GET_ADDED_AWARDS,
        DOCTOR_EDIT_DETAILS_ADD_TREATMENTS,
        DOCTOR_EDIT_DETAILS_EDIT_TREATMENTS,
        DOCTOR_EDIT_DETAILS_ADD_TO_TREATMENTS,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_TREATMENTS,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_EDUCATION,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_EXPERIENCE,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_AFFILIATION,
        DOCTOR_EDIT_DETAILS_REMOVE_FROM_AWARD,
        DOCTOR_EDIT_DETAILS_ADD_EDUCATION,
        DOCTOR_EDIT_DETAILS_ADD_EXPERIENCE,
        DOCTOR_EDIT_DETAILS_ADD_AFFILIATION,
        DOCTOR_EDIT_DETAILS_ADD_AWARD,

        STAFF_GET_ADDED_PRACTICE_DOCTORS,
        STAFF_GET_ADDED_PRACTICE_STAFF,
        STAFF_REMOVE_FROM_PROVIDERS,
    }
}