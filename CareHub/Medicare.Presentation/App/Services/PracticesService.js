/***
 * Service: datacontext 
 *
 * Handles all persistence and creation/deletion of app entities
 * using BreezeJS.
 *
 ***/
(function () {
    'use strict';

    var serviceId = 'practicesService';
    angular.module('app').factory(serviceId,
    ['breeze', '$q', 'logger', 'entityManagerFactoryPractices', practicesService]);

    function practicesService(breeze, $q, logger, emFactory) {
        logger = logger.forSource(serviceId);
        var logError = logger.logError;
        var logSuccess = logger.logSuccess;
        var logWarning = logger.logWarning;

        var manager = emFactory.newManager();

        var service = {
            getPracticeDetails: getPracticeDetails,
            getPracticeLocation: getPracticeLocation,
            getPracticeTimings: getPracticeTimings,
            getPracticeContacts: getPracticeContacts,
            addPracticeDetails: addPracticeDetails,
            addPracticeLocation: addPracticeLocation,
            addPracticeContacts: addPracticeContacts,
            addPracticeTimings: addPracticeTimings,

            isValidEmail: isValidEmail,

            //Services
            getServices: getServices,
            getAddedServices: getAddedServices,
            addPracticeServices: addPracticeServices,
            addToPracticeServices: addToPracticeServices,
            removePracticeServices: removePracticeServices,

            //Travel Service
            getTravelServices: getTravelServices,
            getAddedTravelServices: getAddedTravelServices,
            addPracticeTravelServices: addPracticeTravelServices,
            addToPracticeTravelServices: addToPracticeTravelServices,
            removePracticeTravelServices: removePracticeTravelServices,

            //Premises
            getPremises: getPremises,
            getAddedPremises: getAddedPremises,
            addPracticePremises: addPracticePremises,
            addToPracticePremises: addToPracticePremises,
            removePracticePremises: removePracticePremises,

            //Language
            getLanguages: getLanguages,
            getAddedLanguages: getAddedLanguages,
            addPracticeLanguages: addPracticeLanguages,
            addToPracticeLanguages: addToPracticeLanguages,
            removePracticeLanguages: removePracticeLanguages,

            //Accreditation
            getAccreditations: getAccreditations,
            getAddedAccreditations: getAddedAccreditations,
            addPracticeAccreditations: addPracticeAccreditations,
            addToPracticeAccreditations: addToPracticeAccreditations,
            removePracticeAccreditations: removePracticeAccreditations,

            //Insurance
            getInsurances: getInsurances,
            getAddedInsurances: getAddedInsurances,
            addPracticeInsurances: addPracticeInsurances,
            addToPracticeInsurances: addToPracticeInsurances,
            removePracticeInsurances: removePracticeInsurances,

            //Currency
            getPracticeBillingCurrency: getPracticeBillingCurrency,

            //Practice Type
            getPracticeType: getPracticeType,

            //Countries
            getPracticeCountry : getPracticeCountry

        };
        return service;

        //Email validation
        function isValidEmail(emailField) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            var isValid = false;
            if (re.test(emailField) == false) {
                isValid = false;
            }
            else {
                isValid = true;
            }
            return isValid;
        }

        //Billing Currency
        function getPracticeBillingCurrency() {

            return breeze.EntityQuery.from('GetPracticeBillingCurrency').using(manager).execute().then('successful').catch('failed');
        }

        //Practice Type
        function getPracticeType() {

            return breeze.EntityQuery.from('GetPracticeType').using(manager).execute().then('successful').catch('failed');
        }

    //Practice Country
        function getPracticeCountry() {

            return breeze.EntityQuery.from('GetCountries').using(manager).execute().then('successful').catch('failed');
        }

        //Provider Practice
        function getProviderPractices() {

            return breeze.EntityQuery.from('GetProviderPractices').using(manager).execute().then('successful').catch('failed');
        }

        //Practice Detail
        function getPracticeDetails(initialValues) {

            return breeze.EntityQuery.from('GetPracticeDetails').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeDetails(initialValues) {

            return breeze.EntityQuery.from('AddPracticeDetails').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }


        //Location
        function getPracticeLocation(initialValues) {

            return breeze.EntityQuery.from('GetPracticeLocation').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeLocation(initialValues) {

            return breeze.EntityQuery.from('AddPracticeLocation').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        //Contact 
        function getPracticeContacts(initialValues) {

            return breeze.EntityQuery.from('GetPracticeContacts').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeContacts(initialValues) {

            return breeze.EntityQuery.from('AddPracticeContacts').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }


        // Practice Timing

        function getPracticeTimings(initialValues) {

            return breeze.EntityQuery.from('GetPracticeTimings').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeTimings(initialValues) {

            return breeze.EntityQuery.from('AddPracticeTimings').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }
              
        //Services
        function getServices() {
            return breeze.EntityQuery.from('GetServices')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function getAddedServices() {
            return breeze.EntityQuery.from('GetAddedServices')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeServices(initialValues) {

            return breeze.EntityQuery.from('AddPracticeServices').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addToPracticeServices(initialValues) {

            return breeze.EntityQuery.from('AddToPracticeServices').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function removePracticeServices(initialValues) {

            return breeze.EntityQuery.from('RemovePracticeServices').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        //travel services
        function getTravelServices() {
            return breeze.EntityQuery.from('GetTravelServices')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function getAddedTravelServices() {
            return breeze.EntityQuery.from('GetAddedTravelServices')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeTravelServices(initialValues) {

            return breeze.EntityQuery.from('AddPracticeTravelServices').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addToPracticeTravelServices(initialValues) {

            return breeze.EntityQuery.from('AddToPracticeTravelServices').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function removePracticeTravelServices(initialValues) {

            return breeze.EntityQuery.from('RemovePracticeTravelServices').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        //Premises
        function getPremises() {
            return breeze.EntityQuery.from('GetPremises')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function getAddedPremises() {
            return breeze.EntityQuery.from('GetAddedPremises')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticePremises(initialValues) {

            return breeze.EntityQuery.from('AddPracticePremises').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addToPracticePremises(initialValues) {

            return breeze.EntityQuery.from('AddToPracticePremises').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function removePracticePremises(initialValues) {

            return breeze.EntityQuery.from('RemovePracticePremises').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        //Language
        function getLanguages() {
            debugger;
            return breeze.EntityQuery.from('GetLanguages')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function getAddedLanguages() {
            return breeze.EntityQuery.from('GetAddedLanguages')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeLanguages(initialValues) {
            debugger;
            return breeze.EntityQuery.from('AddPracticeLanguages').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addToPracticeLanguages(initialValues) {

            return breeze.EntityQuery.from('AddToPracticeLanguages').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function removePracticeLanguages(initialValues) {

            return breeze.EntityQuery.from('RemovePracticeLanguages').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        // Accreditation
        function getAccreditations() {
            return breeze.EntityQuery.from('GetAccreditations')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function getAddedAccreditations() {
            return breeze.EntityQuery.from('GetAddedAccreditations')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeAccreditations(initialValues) {

            return breeze.EntityQuery.from('AddPracticeAccreditations').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addToPracticeAccreditations(initialValues) {

            return breeze.EntityQuery.from('AddToPracticeAccreditations').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function removePracticeAccreditations(initialValues) {

            return breeze.EntityQuery.from('RemovePracticeAccreditations').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        //Insurance
        function getInsurances() {
            return breeze.EntityQuery.from('GetInsurances')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function getAddedInsurances() {
            return breeze.EntityQuery.from('GetAddedInsurances')
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addPracticeInsurances(initialValues) {

            return breeze.EntityQuery.from('AddPracticeInsurances').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function addToPracticeInsurances(initialValues) {

            return breeze.EntityQuery.from('AddToPracticeInsurances').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

        function removePracticeInsurances(initialValues) {

            return breeze.EntityQuery.from('RemovePracticeInsurances').withParameters(initialValues)
                  .using(manager).execute().then('successful').catch('failed');
        }

    }
}
)();