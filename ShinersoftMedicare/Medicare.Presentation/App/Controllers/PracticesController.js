/***
 * Controller/ViewModel: practices 
 *
 * Handles fetch and save of data
 *
 ***/
(function () {
    'use strict';

    var controllerId = 'practicesController';
    angular.module('app').controller(controllerId,
    ['practicesService', 'logger', '$scope', '$location', 'usSpinnerService', '$rootScope', 'alertsManager', practicesController]);

    function practicesController(practicesService, logger, $scope, $location, usSpinnerService, $rootScope, alertsManager) {
        logger = logger.forSource(controllerId);
        var logError = logger.logError;
        var logSuccess = logger.logSuccess;

        $scope.alerts = alertsManager.alerts;

        $scope.successAlert = successAlert;
        $scope.failureAlert = failureAlert;

        function successAlert(message) {
            alertsManager.addAlert(message, 'alert-success');
        }

        function failureAlert(message) {
            alertsManager.addAlert(message, 'alert-danger');
        };

        $scope.reset = function () {
            alertsManager.clearAlerts();
        };

        $scope.startSpin = function () {
            if (!$scope.spinneractive) {
                usSpinnerService.spin('spinner-1');
            }
        };

        $scope.stopSpin = function () {
            if ($scope.spinneractive) {
                usSpinnerService.stop('spinner-1');
            }
        };

        $scope.spinneractive = false;

        $rootScope.$on('us-spinner:spin', function (event, key) {
            $scope.spinneractive = true;
        });

        $rootScope.$on('us-spinner:stop', function (event, key) {
            $scope.spinneractive = false;
        });

        $scope.launch = function (which) {
            var dlg = null;
            switch (which) {

                // Confirm Dialog
                case 'confirm':
                    dlg = $dialogs.confirm('Delete Languages', 'Are you sure you want to delete');
                    dlg.result.then(function (btn) {
                        $scope.confirmed = 'Language is deleted';
                    }, function (btn) {
                        $scope.confirmed = '';
                    });
                    break;


            }; // end switch
        }; // end launch

        //
        $scope.confirmed = 'You have yet to be confirmed!';

        // ViewModel
        var practicesControllerVM = this;
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // ViewModel variables    
        // Visibility variables
        practicesControllerVM.isVisiblePracticeDetails = true;
        practicesControllerVM.isVisiblePracticeLocation = false;
        practicesControllerVM.isVisiblePracticeContants = false;
        practicesControllerVM.isVisiblePracticeTimings = false;
        practicesControllerVM.isVisiblePracticeServices = false;
        practicesControllerVM.isVisiblePracticePictures = false;
        practicesControllerVM.isVisiblePracticeVideos = false;
        practicesControllerVM.isVisiblePracticePremises = false;
        practicesControllerVM.isVisiblePracticeLanguages = false;
        practicesControllerVM.isVisiblePracticeAccreditations = false;
        practicesControllerVM.isVisiblePracticeInsurances = false;
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice details variables
        practicesControllerVM.practiceDetailsPracticeName = '';
        practicesControllerVM.practiceDetailsGender = '';
        practicesControllerVM.practiceDetailsRegistrationDetails = '';
        practicesControllerVM.practiceDetailsRegistrationYear = '';
        practicesControllerVM.practiceDetailsRegistrationCouncil = '';
        practicesControllerVM.practiceDetailsRegistrationCouncilId = '';
        practicesControllerVM.practiceDetailsNumberOfYears = '';
        practicesControllerVM.practiceDetailsPracticeTagLine = '';
        practicesControllerVM.practiceDetailsPracticeDescription = '';

        practicesControllerVM.practiceDetailsPracticeDetailsList = [];

        //Curency
        practicesControllerVM.practiceDetailsBillingCurrency = '';
        practicesControllerVM.billingCurrencyList = [];

        //Practice Type
        practicesControllerVM.practiceDetailsPracticeType = '';
        practicesControllerVM.practiceTypeList = [];

        //Practice Country
        practicesControllerVM.practiceCountryList = [];

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Pratice location variables
        practicesControllerVM.practiceLocationStreetAddress = '';
        practicesControllerVM.practiceLocationLandmark = '';
        practicesControllerVM.practiceLocationLocality = '';
        practicesControllerVM.practiceLocationCity = '';
        practicesControllerVM.practiceLocationState = '';
        practicesControllerVM.practiceLocationZipcode = '';
        practicesControllerVM.practiceLocationCountry = '';

        practicesControllerVM.practiceDetailsPracticeLocationList = [];

        //Provider Practice
        practicesControllerVM.ProviderPractices = '';
        practicesControllerVM.ProviderPracticesList = [];
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice contacts variables
        practicesControllerVM.isVisibleSecondaryPhone = false;
        practicesControllerVM.isVisibleSecondaryEmailId = false;
        practicesControllerVM.practiceContactsPrimaryPhone = '';
        practicesControllerVM.practiceContactsSecondaryPhone = '';
        practicesControllerVM.practiceContactsPrimaryEmailId = '';
        practicesControllerVM.practiceContactsSecondaryEmailId = '';
        practicesControllerVM.practiceContactsWebsiteAddress = '';


        practicesControllerVM.practiceContactsList = [];

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //  Practice timings variables
        $scope.hoursArray = ['None', '1 am', '2 am', '3 am', '4 am', '5 am', '6 am', '7 am', '8 am', '9 am', '10 am', '11 am', '12 am', '1 pm', '2 pm', '3 pm', '4 pm', '5 pm', '6 pm', '7 pm', '8 pm', '9 pm', '10 pm', '11 pm', '12 pm'];
        $scope.minutesArray = ['None', '00', '01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31', '32', '33', '34', '35', '36', '37', '38', '39', '40', '41', '42', '43', '44', '45', '46', '47', '48', '49', '50', '51', '52', '53', '54', '55', '56', '57', '58', '59'];

        practicesControllerVM.practiceTimingsLunchBreak = false;
        practicesControllerVM.practiceTimingsMonday = false;
        practicesControllerVM.practiceTimingsTuesday = false;
        practicesControllerVM.practiceTimingsWednesday = false;
        practicesControllerVM.practiceTimingsThursday = false;
        practicesControllerVM.practiceTimingsFriday = false;
        practicesControllerVM.practiceTimingsSaturday = false;
        practicesControllerVM.practiceTimingsSunday = false;

        practicesControllerVM.practiceTimingsClose1Open2Visible = false;

        practicesControllerVM.practiceTimingsMondayOpenHours1 = '';
        practicesControllerVM.practiceTimingsMondayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsMondayCloseHours1 = '';
        practicesControllerVM.practiceTimingsMondayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsMondayOpenHours2 = '';
        practicesControllerVM.practiceTimingsMondayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsMondayCloseHours2 = '';
        practicesControllerVM.practiceTimingsMondayCloseMinutes2 = '';
        practicesControllerVM.practiceTimingsTuesdayOpenHours1 = '';
        practicesControllerVM.practiceTimingsTuesdayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsTuesdayCloseHours1 = '';
        practicesControllerVM.practiceTimingsTuesdayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsTuesdayOpenHours2 = '';
        practicesControllerVM.practiceTimingsTuesdayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsTuesdayCloseHours2 = '';
        practicesControllerVM.practiceTimingsTuesdayCloseMinutes2 = '';
        practicesControllerVM.practiceTimingsWednesdayOpenHours1 = '';
        practicesControllerVM.practiceTimingsWednesdayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsWednesdayCloseHours1 = '';
        practicesControllerVM.practiceTimingsWednesdayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsWednesdayOpenHours2 = '';
        practicesControllerVM.practiceTimingsWednesdayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsWednesdayCloseHours2 = '';
        practicesControllerVM.practiceTimingsWednesdayCloseMinutes2 = '';
        practicesControllerVM.practiceTimingsThursdayOpenHours1 = '';
        practicesControllerVM.practiceTimingsThursdayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsThursdayCloseHours1 = '';
        practicesControllerVM.practiceTimingsThursdayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsThursdayOpenHours2 = '';
        practicesControllerVM.practiceTimingsThursdayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsThursdayCloseHours2 = '';
        practicesControllerVM.practiceTimingsThursdayCloseMinutes2 = '';
        practicesControllerVM.practiceTimingsFridayOpenHours1 = '';
        practicesControllerVM.practiceTimingsFridayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsFridayCloseHours1 = '';
        practicesControllerVM.practiceTimingsFridayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsFridayOpenHours2 = '';
        practicesControllerVM.practiceTimingsFridayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsFridayCloseHours2 = '';
        practicesControllerVM.practiceTimingsFridayCloseMinutes2 = '';
        practicesControllerVM.practiceTimingsSaturdayOpenHours1 = '';
        practicesControllerVM.practiceTimingsSaturdayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsSaturdayCloseHours1 = '';
        practicesControllerVM.practiceTimingsSaturdayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsSaturdayOpenHours2 = '';
        practicesControllerVM.practiceTimingsSaturdayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsSaturdayCloseHours2 = '';
        practicesControllerVM.practiceTimingsSaturdayCloseMinutes2 = '';
        practicesControllerVM.practiceTimingsSundayOpenHours1 = '';
        practicesControllerVM.practiceTimingsSundayOpenMinutes1 = '';
        practicesControllerVM.practiceTimingsSundayCloseHours1 = '';
        practicesControllerVM.practiceTimingsSundayCloseMinutes1 = '';
        practicesControllerVM.practiceTimingsSundayOpenHours2 = '';
        practicesControllerVM.practiceTimingsSundayOpenMinutes2 = '';
        practicesControllerVM.practiceTimingsSundayCloseHours2 = '';
        practicesControllerVM.practiceTimingsSundayCloseMinutes2 = '';

        practicesControllerVM.practiceDetailsPracticeTimingsList = [];

        
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice Services variables
        practicesControllerVM.addedServicesList = [];
        practicesControllerVM.addedServicesListCount = 3;
        practicesControllerVM.servicesList = [];
        practicesControllerVM.servicesListCount = 3;
        practicesControllerVM.practiceServicesServiceName = '';

        //Travel Service
        practicesControllerVM.addedTravelServicesList = [];
        practicesControllerVM.addedTravelServicesListCount = 3;
        practicesControllerVM.travelServicesList = [];
        practicesControllerVM.travelServicesListCount = 3;
        practicesControllerVM.practiceServicesTravelServiceName = '';
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice Premises variables
        practicesControllerVM.addedPremisesList = [];
        practicesControllerVM.addedPremisesListCount = 3;
        practicesControllerVM.premisesList = [];
        practicesControllerVM.premisesListCount = 3;
        practicesControllerVM.practicePremisesPremisName = '';
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice Languages variables
        practicesControllerVM.addedLanguagesList = [];
        practicesControllerVM.addedLanguagesListCount = 3;
        practicesControllerVM.languagesList = [];
        practicesControllerVM.languagesListCount = 3;
        practicesControllerVM.practiceLanguagesLanguageName = '';
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice Accreditations variables
        practicesControllerVM.addedAccreditationsList = [];
        practicesControllerVM.addedAccreditationsListCount = 3;
        practicesControllerVM.accreditationsList = [];
        practicesControllerVM.accreditationsListCount = 3;
        practicesControllerVM.practiceAccreditationsAccreditationName = '';
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice Insurances variables
        practicesControllerVM.addedInsurancesList = [];
        practicesControllerVM.addedInsurancesListCount = 3;
        practicesControllerVM.insurancesList = [];
        practicesControllerVM.insurancesListCount = 3;
        practicesControllerVM.practiceInsurancesInsuranceName = '';
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // ViewModel Methods
        // Visibility methods
        practicesControllerVM.showPracticeDetails = showPracticeDetails;
        practicesControllerVM.showPracticeLocation = showPracticeLocation;
        practicesControllerVM.showPracticeContants = showPracticeContants;
        practicesControllerVM.showPracticeTimings = showPracticeTimings;
        practicesControllerVM.showPracticeServices = showPracticeServices;
        practicesControllerVM.showPracticePictures = showPracticePictures;
        practicesControllerVM.showPracticeVideos = showPracticeVideos;
        practicesControllerVM.showPracticePremises = showPracticePremises;
        practicesControllerVM.showPracticeLanguages = showPracticeLanguages;
        practicesControllerVM.showPracticeAccreditations = showPracticeAccreditations;
        practicesControllerVM.showPracticeInsurances = showPracticeInsurances;

        practicesControllerVM.showPracticeContactsSecondaryPhone = showPracticeContactsSecondaryPhone;
        practicesControllerVM.showPracticeContactsSecondaryEmailId = showPracticeContactsSecondaryEmailId;

        practicesControllerVM.hidePracticeContactsSecondaryPhone = hidePracticeContactsSecondaryPhone;
        practicesControllerVM.hidePracticeContactsSecondaryEmailId = hidePracticeContactsSecondaryEmailId;
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Practice edit details methods
        practicesControllerVM.getPracticeDetails = getPracticeDetails;
        practicesControllerVM.addPracticeDetails = addPracticeDetails;

        practicesControllerVM.getPracticeLocation = getPracticeLocation;

        practicesControllerVM.addPracticeLocation = addPracticeLocation;
        practicesControllerVM.addPracticeContacts = addPracticeContacts;

        practicesControllerVM.getPracticeContacts = getPracticeContacts;

        practicesControllerVM.practiceTimingsCopyToAll = practiceTimingsCopyToAll;
        practicesControllerVM.getPracticeTimings = getPracticeTimings;
        practicesControllerVM.addPracticeTimings = addPracticeTimings;

        practicesControllerVM.getProviderDetailsOnLoad = getProviderDetailsOnLoad;

        practicesControllerVM.getServices = getServices;
        practicesControllerVM.getAddedServices = getAddedServices;
        practicesControllerVM.loadMoreServices = loadMoreServices;
        practicesControllerVM.addPracticeServices = addPracticeServices;
        practicesControllerVM.addToPracticeServices = addToPracticeServices;
        practicesControllerVM.removePracticeServices = removePracticeServices;

        practicesControllerVM.getTravelServices = getTravelServices;
        practicesControllerVM.getAddedTravelServices = getAddedTravelServices;
        practicesControllerVM.loadMoreTravelServices = loadMoreTravelServices;
        practicesControllerVM.addPracticeTravelServices = addPracticeTravelServices;
        practicesControllerVM.addToPracticeTravelServices = addToPracticeTravelServices;
        practicesControllerVM.removePracticeTravelServices = removePracticeTravelServices;

        practicesControllerVM.getPremises = getPremises;
        practicesControllerVM.getAddedPremises = getAddedPremises;
        practicesControllerVM.loadMorePremises = loadMorePremises;
        practicesControllerVM.addPracticePremises = addPracticePremises;
        practicesControllerVM.addToPracticePremises = addToPracticePremises;
        practicesControllerVM.removePracticePremises = removePracticePremises;

        practicesControllerVM.getPracticeBillingCurrency = getPracticeBillingCurrency;

        practicesControllerVM.getPracticeType = getPracticeType;

        practicesControllerVM.getPracticeCountry = getPracticeCountry;

        practicesControllerVM.getProviderPractices = getProviderPractices;

        practicesControllerVM.getLanguages = getLanguages;
        practicesControllerVM.getAddedLanguages = getAddedLanguages;
        practicesControllerVM.loadMoreLanguages = loadMoreLanguages;
        practicesControllerVM.addPracticeLanguages = addPracticeLanguages;
        practicesControllerVM.addToPracticeLanguages = addToPracticeLanguages;
        practicesControllerVM.removePracticeLanguages = removePracticeLanguages;

        practicesControllerVM.getAccreditations = getAccreditations;
        practicesControllerVM.getAddedAccreditations = getAddedAccreditations;
        practicesControllerVM.loadMoreAccreditations = loadMoreAccreditations;
        practicesControllerVM.addPracticeAccreditations = addPracticeAccreditations;
        practicesControllerVM.addToPracticeAccreditations = addToPracticeAccreditations;
        practicesControllerVM.removePracticeAccreditations = removePracticeAccreditations;

        practicesControllerVM.getInsurances = getInsurances;
        practicesControllerVM.getAddedInsurances = getAddedInsurances;
        practicesControllerVM.loadMoreInsurances = loadMoreInsurances;
        practicesControllerVM.addPracticeInsurances = addPracticeInsurances;
        practicesControllerVM.addToPracticeInsurances = addToPracticeInsurances;
        practicesControllerVM.removePracticeInsurances = removePracticeInsurances;

        practicesControllerVM.practiceTimingsClose1Open2Visibility = practiceTimingsClose1Open2Visibility;
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Implementation
        // Visibility methods implementation

        function showPracticeContactsSecondaryPhone() {
            practicesControllerVM.isVisibleSecondaryPhone = true;
        }

        function showPracticeContactsSecondaryEmailId() {
            practicesControllerVM.isVisibleSecondaryEmailId = true;
        }

        function hidePracticeContactsSecondaryPhone() {
            practicesControllerVM.isVisibleSecondaryPhone = false;
            practicesControllerVM.practiceContactsSecondaryPhone = '';
        }

        function hidePracticeContactsSecondaryEmailId() {
            practicesControllerVM.isVisibleSecondaryEmailId = false;
            practicesControllerVM.practiceContactsSecondaryEmailId = '';
        }

        function showPracticeDetails() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeDetails = true;
            document.getElementById("practiceDetailsLI").className = "active";
            document.getElementById("practiceDetailsLI2").className = "active";
        }

        function showPracticeLocation() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeLocation = true;
            document.getElementById("practiceLocationLI").className = "active";
            document.getElementById("practiceLocationLI2").className = "active";
            $scope.initializeMap();
        }

        function showPracticeContants() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeContants = true;
            document.getElementById("practiceContactsLI").className = "active";
            document.getElementById("practiceContactsLI2").className = "active";
        }

        function showPracticeTimings() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeTimings = true;
            document.getElementById("practiceTimingsLI").className = "active";
            document.getElementById("practiceTimingsLI2").className = "active";
        }

        function showPracticeServices() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeServices = true;
            document.getElementById("practiceServicesLI").className = "active";
            document.getElementById("practiceServicesLI2").className = "active";
        }

        function showPracticePictures() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticePictures = true;
            document.getElementById("practicePicturesLI").className = "active";
            document.getElementById("practicePicturesLI2").className = "active";
        }

        function showPracticeVideos() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeVideos = true;
            document.getElementById("practiceVideosLI").className = "active";
            document.getElementById("practiceVideosLI2").className = "active";
        }

        function showPracticePremises() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticePremises = true;
            document.getElementById("practicePremisesLI").className = "active";
            document.getElementById("practicePremisesLI2").className = "active";
        }

        function showPracticeLanguages() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeLanguages = true;
            document.getElementById("practiceLanguagesLI").className = "active";
            document.getElementById("practiceLanguagesLI2").className = "active";
        }

        function showPracticeAccreditations() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeAccreditations = true;
            document.getElementById("practiceAccreditationsLI").className = "active";
            document.getElementById("practiceAccreditationsLI2").className = "active";
        }

        function showPracticeInsurances() {
            clearAllDivs();
            $scope.reset();
            practicesControllerVM.isVisiblePracticeInsurances = true;
            document.getElementById("practiceInsurancesLI").className = "active";
            document.getElementById("practiceInsurancesLI2").className = "active";
        }

        function clearAllDivs() {
            practicesControllerVM.isVisiblePracticeDetails = false;
            document.getElementById("practiceDetailsLI").className = "";
            document.getElementById("practiceDetailsLI2").className = "";
            practicesControllerVM.isVisiblePracticeLocation = false;
            document.getElementById("practiceLocationLI").className = "";
            document.getElementById("practiceLocationLI2").className = "";
            practicesControllerVM.isVisiblePracticeContants = false;
            document.getElementById("practiceContactsLI").className = "";
            document.getElementById("practiceContactsLI2").className = "";
            practicesControllerVM.isVisiblePracticeTimings = false;
            document.getElementById("practiceTimingsLI").className = "";
            document.getElementById("practiceTimingsLI2").className = "";
            practicesControllerVM.isVisiblePracticeServices = false;
            document.getElementById("practiceServicesLI").className = "";
            document.getElementById("practiceServicesLI2").className = "";
            practicesControllerVM.isVisiblePracticePictures = false;
            document.getElementById("practicePicturesLI").className = "";
            document.getElementById("practicePicturesLI2").className = "";
            practicesControllerVM.isVisiblePracticeVideos = false;
            document.getElementById("practiceVideosLI").className = "";
            document.getElementById("practiceVideosLI2").className = "";
            practicesControllerVM.isVisiblePracticePremises = false;
            document.getElementById("practicePremisesLI").className = "";
            document.getElementById("practicePremisesLI2").className = "";
            practicesControllerVM.isVisiblePracticeLanguages = false;
            document.getElementById("practiceLanguagesLI").className = "";
            document.getElementById("practiceLanguagesLI2").className = "";
            practicesControllerVM.isVisiblePracticeAccreditations = false;
            document.getElementById("practiceAccreditationsLI").className = "";
            document.getElementById("practiceAccreditationsLI2").className = "";
            practicesControllerVM.isVisiblePracticeInsurances = false;
            document.getElementById("practiceInsurancesLI").className = "";
            document.getElementById("practiceInsurancesLI2").className = "";
        }

        function practiceTimingsClose1Open2Visibility() {
            if (practicesControllerVM.practiceTimingsMonday == true || practicesControllerVM.practiceTimingsTuesday == true ||
                practicesControllerVM.practiceTimingsWednesday == true || practicesControllerVM.practiceTimingsThursday == true ||
                practicesControllerVM.practiceTimingsFriday == true || practicesControllerVM.practiceTimingsSaturday == true ||
                practicesControllerVM.practiceTimingsSunday == true)
            { practicesControllerVM.practiceTimingsClose1Open2Visible = true; }
            else {
                practicesControllerVM.practiceTimingsClose1Open2Visible = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Google map methods implementation   
        var txtCity = document.getElementById("practiceLocationCity");
        if (txtCity != null) {
            txtCity.onblur = function () {
                $scope.codeAddress();
            }
        }
        //else {
        //    txtCity.onblur = function () {
        //        $scope.codeAddress();
        //    }
        //}
        $scope.geocoder;
        var gMap;
        $scope.initializeMap = function () {

            $scope.geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(24.8600, 67.0100);
            var mapOptions = {
                zoom: 8,
                center: latlng
            }
            gMap = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
        }

        $scope.codeAddress = function () {

            var locality = document.getElementById("practiceLocationLocality").value;
            var city = document.getElementById("practiceLocationCity").value;
            var country = document.getElementById("practiceLocationCountry").value;

            var address = locality + ', ' + city + ', ' + country;
            $scope.geocoder.geocode({ 'address': address }, function (results, status) {

                if (status == google.maps.GeocoderStatus.OK) {
                    var mapOptions = {
                        zoom: 8,
                        center: results[0].geometry.location,
                    }
                    gMap = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
                    gMap.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        gMap: gMap,
                        position: results[0].geometry.location
                    });
                } else {
                    //alert("Geocode was not successful for the following reason: " + status);
                }
            });
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        function getProviderDetailsOnLoad(infoType) {
            debugger;
            var url = document.URL;
            var myUrl = new String(url);
            var separatedByQuestionMark = myUrl.split('?');
            if (separatedByQuestionMark.length > 1) {
                var separatedByEquals = separatedByQuestionMark[1].split('=');
                practicesControllerVM.editProviderProviderId = parseInt(separatedByEquals[1]);
                switch (infoType) {
                    case 1:
                        practicesControllerVM.getPracticeDetails(practicesControllerVM.editProviderProviderId);
                        break;
                        case 2:
                            practicesControllerVM.getPracticeLocation(practicesControllerVM.editProviderProviderId);
                            break;
                        case 3:
                            practicesControllerVM.getPracticeContacts(practicesControllerVM.editProviderProviderId);                        
                            break;
                    case 4:
                        practicesControllerVM.getPracticeTimings(practicesControllerVM.editProviderProviderId);
                        break;
                    case 5:
                        practicesControllerVM.getAddedServices(practicesControllerVM.editProviderProviderId);
                        practicesControllerVM.getAddedTravelServices(practicesControllerVM.editProviderProviderId);
                        break;
                        //case 6:
                        //    practicesControllerVM.getAddedPictures(practicesControllerVM.editProviderProviderId);
                        //    break;
                        //case 7:
                        //    practicesControllerVM.getAddedVideos(practicesControllerVM.editProviderProviderId);
                        //    break;
                    case 8:
                        practicesControllerVM.getAddedPremises(practicesControllerVM.editProviderProviderId);
                        break;
                    case 9:
                        practicesControllerVM.getAddedLanguages(practicesControllerVM.editProviderProviderId);
                        break;
                    case 10:
                        practicesControllerVM.getAddedAccreditations(practicesControllerVM.editProviderProviderId);
                        break;
                    case 11:
                        practicesControllerVM.getAddedInsurances(practicesControllerVM.editProviderProviderId);
                        break;


                    case 12:
                        practicesControllerVM.addPracticeDetails(practicesControllerVM.editProviderProviderId);
                        break;
                        case 13:
                            practicesControllerVM.addPracticeLocation(practicesControllerVM.editProviderProviderId);
                            break;
                        case 14:
                            practicesControllerVM.addPracticeContacts(practicesControllerVM.editProviderProviderId);
                            break;
                    case 15:
                        practicesControllerVM.addPracticeTimings(practicesControllerVM.editProviderProviderId);
                        break;
                    case 16:
                        practicesControllerVM.addPracticeServices(practicesControllerVM.editProviderProviderId);
                        practicesControllerVM.addPracticeTravelServices(practicesControllerVM.editProviderProviderId);
                        break;
                        //case 17:
                        //    practicesControllerVM.addPracticePictures(practicesControllerVM.editProviderProviderId);
                        //    break;
                        //case 18:
                        //    practicesControllerVM.addPracticeVideos(practicesControllerVM.editProviderProviderId);
                        //    break;
                    case 19:
                        practicesControllerVM.addPracticePremises(practicesControllerVM.editProviderProviderId);
                        break;
                    case 20:
                        practicesControllerVM.addPracticeLanguages(practicesControllerVM.editProviderProviderId);
                        break;
                    case 21:
                        practicesControllerVM.addPracticeAccreditations(practicesControllerVM.editProviderProviderId);
                        break;
                    case 22:
                        practicesControllerVM.addPracticeInsurances(practicesControllerVM.editProviderProviderId);
                        break;
                    default:
                        break;
                }
            }
            else {
                switch (infoType) {
                    case 1:
                        practicesControllerVM.getPracticeDetails(0);
                         break;
                        case 2:
                            practicesControllerVM.getPracticeLocation(0);
                            break;
                        case 3:
                            practicesControllerVM.getPracticeContacts(0);
                            break;
                    case 4:
                        practicesControllerVM.getPracticeTimings(0);
                        break;
                    case 5:
                        practicesControllerVM.getAddedServices(0);
                        practicesControllerVM.getAddedTravelServices(0);
                        break;
                        //case 6:
                        //    practicesControllerVM.getAddedPictures(0);
                        //    break;
                        //case 7:
                        //    practicesControllerVM.getAddedVideos(0);
                        //    break;
                    case 8:
                        practicesControllerVM.getAddedPremises(0);
                        break;
                    case 9:
                        practicesControllerVM.getAddedLanguages(0);
                        break;
                    case 10:
                        practicesControllerVM.getAddedAccreditations(0);
                        break;
                    case 11:
                        practicesControllerVM.getAddedInsurances(0);
                        break;



                    case 12:
                        practicesControllerVM.addPracticeDetails(0);
                        break;
                        case 13:
                            practicesControllerVM.addPracticeLocation(0);
                            break;
                        case 14:
                            practicesControllerVM.addPracticeContacts(0);
                            break;
                    case 15:
                        practicesControllerVM.addPracticeTimings(0);
                        break;
                    case 16:
                        practicesControllerVM.addPracticeServices(0);
                        practicesControllerVM.addPracticeTravelServices(0);
                        break;

                        //case 17:
                        //    practicesControllerVM.addPracticePictures(0);
                        //    break;
                        //case 18:
                        //    practicesControllerVM.addPracticeVideos(0);
                        //    break;

                    case 19:
                        practicesControllerVM.addPracticePremises(0);
                        break;
                        
                    case 20:
                        practicesControllerVM.addPracticeLanguages(0);
                        break;
                    case 21:
                        practicesControllerVM.addPracticeAccreditations(0);
                        break;
                    case 22:
                        practicesControllerVM.editPracticeInsurance(0);
                        break;
                    default:
                        break;
                }
            }
        }


        //-------Methods-------------//

        // Practice edit details methods implementation\

        //Practice Detail
        function addPracticeDetails() {
            $scope.reset();
            var logo = document.getElementById('exampleInputFile').value;
            var name = practicesControllerVM.practiceDetailsName.trim();
            var tagline = practicesControllerVM.practiceDetailsTagLine.trim();
            var description = practicesControllerVM.practiceDetailsDescription.trim();
            var billingCurrency = practicesControllerVM.practiceDetailsBillingCurrency.trim();
            var type = practicesControllerVM.practiceDetailsType.trim();

            if (name != '') {
                $scope.startSpin();

                practicesService.addPracticeDetails({
                    uploadLogo: logo, name: name, tagLine: tagline, description: description, billingCurrency: billingCurrency,
                    type: type
                }).then(function (data) {
                    var response = data.results;
                    $scope.reset();
                    successAlert(response);
                    $scope.stopSpin();
                });
            }
            else { failureAlert("Practice name is required"); }

            document.getElementById('exampleInputFile').value = '';
            practicesControllerVM.practiceDetailsName = '';
            practicesControllerVM.practiceDetailsTagLine = '';
            practicesControllerVM.practiceDetailsDescription = '';
            practicesControllerVM.practiceDetailsBillingCurrency = '';
            practicesControllerVM.practiceDetailsType = '';
        }

        function getPracticeDetails(providerId) {
            $scope.startSpin();
            debugger;
            return practicesService.getPracticeDetails({ providerId: providerId }).then(function (data) {
                var response = data.results;
                practicesControllerVM.practiceDetailPracticeDetailList = response;
                $scope.stopSpin();
                setPracticeDetails();
                return response;
            });
        }

        function setPracticeDetails() {
            debugger;
            if (practicesControllerVM.practiceDetailPracticeDetailList.length > 0) {
                console.log(practicesControllerVM.practiceDetailPracticeDetailList);
                practicesControllerVM.practiceDetailsPracticeName = practicesControllerVM.practiceDetailPracticeDetailList[0].practiceDetailsPracticeName;
               practicesControllerVM.practiceDetailsPracticeTagLine = practicesControllerVM.practiceDetailPracticeDetailList[0].practiceDetailsTagline;
                practicesControllerVM.practiceDetailsPracticeDescription = practicesControllerVM.practiceDetailPracticeDetailList[0].practiceDetailsPracticeDescription;
                practicesControllerVM.practiceDetailsBillingCurrencyName = practicesControllerVM.practiceDetailPracticeDetailList[0].practiceDetailsBillingCurrencyName;
                 practicesControllerVM.practiceDetailsPracticeType = practicesControllerVM.practiceDetailPracticeDetailList[0].practiceDetailsPracticeType;
            }
        }


        // Location
        function addPracticeLocation() {

            var streetAddress = practicesControllerVM.practiceLocationStreetAddress.trim();
            var landmark = practicesControllerVM.practiceLocationLandmark.trim();
            var locality = practicesControllerVM.practiceLocationLocality.trim();
            var city = practicesControllerVM.practiceLocationCity.trim();
            var state = practicesControllerVM.practiceLocationState.trim();
            var zipcode = practicesControllerVM.practiceLocationZipcode.trim();
            var country = practicesControllerVM.practiceLocationCountry.trim();

            $scope.startSpin();

            practicesService.addPracticeLocation({
                streetAddress: streetAddress, landmark: landmark, locality: locality, city: city, state: state,
                zipcode: zipcode, countryId: country
            }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();

            });
            practicesControllerVM.practiceLocationStreetAddress = '';
            practicesControllerVM.practiceLocationLandmark = '';
            practicesControllerVM.practiceLocationLocality = '';
            practicesControllerVM.practiceLocationCity = '';
            practicesControllerVM.practiceLocationState = '';
            practicesControllerVM.practiceLocationZipcode = '';
            practicesControllerVM.practiceLocationCountry = '';
        }

        function getPracticeLocation(providerId) {
            $scope.startSpin();
            debugger;
            return practicesService.getPracticeLocation({ providerId: providerId }).then(function (data) {
                var response = data.results;
                practicesControllerVM.practiceDetailsPracticeLocationList = response;
                $scope.stopSpin();
                setPracticeLocation();
                return response;
            });
        }

        function setPracticeLocation() {
            debugger;
            console.log(practicesControllerVM.practiceDetailsPracticeLocationList);
            if (practicesControllerVM.practiceDetailsPracticeLocationList.length > 0) {
                practicesControllerVM.practiceLocationStreetAddress = practicesControllerVM.practiceDetailsPracticeLocationList[0].streetAddress;
                practicesControllerVM.practiceLocationLandmark = practicesControllerVM.practiceDetailsPracticeLocationList[0].landmark;
                practicesControllerVM.practiceLocationLocality = practicesControllerVM.practiceDetailsPracticeLocationList[0].localityName;
                practicesControllerVM.practiceLocationCity = practicesControllerVM.practiceDetailsPracticeLocationList[0].cityName;
                practicesControllerVM.practiceLocationState = practicesControllerVM.practiceDetailsPracticeLocationList[0].stateName;
                practicesControllerVM.practiceLocationZipcode = practicesControllerVM.practiceDetailsPracticeLocationList[0].zipCode;
                practicesControllerVM.practiceLocationCountry = practicesControllerVM.practiceDetailsPracticeLocationList[0].countryName;
             }
        }


        //  Contact
        function addPracticeContacts() {
            $scope.reset();
            var primaryPhone = practicesControllerVM.practiceContactsPrimaryPhone.trim();
            var secondaryPhone = practicesControllerVM.practiceContactsSecondaryPhone.trim();
            var primaryEmailId = practicesControllerVM.practiceContactsPrimaryEmailId.trim();
            var secondaryEmailId = practicesControllerVM.practiceContactsSecondaryEmailId.trim();
            var websiteAddress = practicesControllerVM.practiceContactsWebsiteAddress.trim();

            if (primaryPhone == '')
            { failureAlert("Primary phone is required."); }
            if (primaryEmailId == '')
            { failureAlert("Primary email id is required."); }
            if (practicesControllerVM.isVisibleSecondaryPhone == true && secondaryPhone == '')
            { failureAlert("Secondary phone is required."); }
            if (practicesControllerVM.isVisibleSecondaryEmailId == true && secondaryEmailId == '')
            { failureAlert("Secondary email id is required."); }

            if (primaryPhone != '' && primaryEmailId != '') {

                if (practicesControllerVM.isVisibleSecondaryPhone == false && practicesControllerVM.isVisibleSecondaryEmailId == false) {
                    $scope.startSpin();

                    practicesService.addPracticeContacts({
                        primaryPhone: primaryPhone, primaryEmailId: primaryEmailId, websiteAddress: websiteAddress, secondaryPhone: secondaryPhone,
                        secondaryEmailId: secondaryEmailId
                    }).then(function (data) {
                        var response = data.results;
                        $scope.reset();
                        successAlert(response);

                        $scope.stopSpin();
                    });
                    practicesControllerVM.practiceContactsPrimaryPhone = '';
                    practicesControllerVM.practiceContactsSecondaryPhone = '';
                    practicesControllerVM.practiceContactsPrimaryEmailId = '';
                    practicesControllerVM.practiceContactsSecondaryEmailId = '';
                    practicesControllerVM.practiceContactsWebsiteAddress = '';
                }

                if (practicesControllerVM.isVisibleSecondaryPhone == true && secondaryPhone != '') {
                    if (practicesControllerVM.isVisibleSecondaryEmailId == true) {
                        if (secondaryEmailId == '') {
                            failureAlert("Secondary email id is required.");
                        }
                        else {
                            $scope.startSpin();

                            practicesService.addPracticeContacts({
                                primaryPhone: primaryPhone, primaryEmailId: primaryEmailId, websiteAddress: websiteAddress, secondaryPhone: secondaryPhone,
                                secondaryEmailId: secondaryEmailId
                            }).then(function (data) {
                                var response = data.results;
                                $scope.reset();
                                successAlert(response);
                                $scope.stopSpin();
                            });
                            practicesControllerVM.practiceContactsPrimaryPhone = '';
                            practicesControllerVM.practiceContactsSecondaryPhone = '';
                            practicesControllerVM.practiceContactsPrimaryEmailId = '';
                            practicesControllerVM.practiceContactsSecondaryEmailId = '';
                            practicesControllerVM.practiceContactsWebsiteAddress = '';
                        }
                    }
                    else {
                        $scope.startSpin();
                        practicesService.addPracticeContacts({
                            primaryPhone: primaryPhone, primaryEmailId: primaryEmailId, websiteAddress: websiteAddress, secondaryPhone: secondaryPhone,
                            secondaryEmailId: secondaryEmailId
                        }).then(function (data) {
                            var response = data.results;
                            $scope.reset();
                            successAlert(response);
                            $scope.stopSpin();
                        });
                        practicesControllerVM.practiceContactsPrimaryPhone = '';
                        practicesControllerVM.practiceContactsSecondaryPhone = '';
                        practicesControllerVM.practiceContactsPrimaryEmailId = '';
                        practicesControllerVM.practiceContactsSecondaryEmailId = '';
                        practicesControllerVM.practiceContactsWebsiteAddress = '';
                    }
                }
                else if (practicesControllerVM.isVisibleSecondaryEmailId == true && secondaryEmailId != '') {
                    if (practicesControllerVM.isVisibleSecondaryPhone == true) {
                        if (secondaryPhone == '') {
                            failureAlert("Secondary phone is required.");
                        }
                        else {
                            $scope.startSpin();
                            practicesService.addPracticeContacts({
                                primaryPhone: primaryPhone, primaryEmailId: primaryEmailId, websiteAddress: websiteAddress, secondaryPhone: secondaryPhone,
                                secondaryEmailId: secondaryEmailId
                            }).then(function (data) {
                                var response = data.results;
                                $scope.reset();
                                successAlert(response);
                                $scope.stopSpin();
                            });
                            practicesControllerVM.practiceContactsPrimaryPhone = '';
                            practicesControllerVM.practiceContactsSecondaryPhone = '';
                            practicesControllerVM.practiceContactsPrimaryEmailId = '';
                            practicesControllerVM.practiceContactsSecondaryEmailId = '';
                            practicesControllerVM.practiceContactsWebsiteAddress = '';
                        }
                    }
                    else {
                        $scope.startSpin();
                        practicesService.addPracticeContacts({
                            primaryPhone: primaryPhone, primaryEmailId: primaryEmailId, websiteAddress: websiteAddress, secondaryPhone: secondaryPhone,
                            secondaryEmailId: secondaryEmailId
                        }).then(function (data) {
                            var response = data.results;
                            $scope.reset();
                            successAlert(response);
                            $scope.stopSpin();
                        });
                        practicesControllerVM.practiceContactsPrimaryPhone = '';
                        practicesControllerVM.practiceContactsSecondaryPhone = '';
                        practicesControllerVM.practiceContactsPrimaryEmailId = '';
                        practicesControllerVM.practiceContactsSecondaryEmailId = '';
                        practicesControllerVM.practiceContactsWebsiteAddress = '';
                    }
                }
            }
        }

        function getPracticeContacts(providerId) {
            $scope.startSpin();
            debugger;
            return practicesService.getPracticeContacts({ providerId: providerId }).then(function (data) {
                var response = data.results;
                practicesControllerVM.practiceContactsList = response;
                console.log(practicesControllerVM.practiceContactsList);
                $scope.stopSpin();
                setPracticeContacts();
                return response;
            });
        }

        function setPracticeContacts() {
            debugger;
            if (practicesControllerVM.practiceContactsList.length > 0) {
                practicesControllerVM.PracticeContactsPrimaryPhone = practicesControllerVM.practiceContactsList[0].practiceContactsPrimaryPhone;
                practicesControllerVM.PracticeContactsPrimaryEmail = practicesControllerVM.practiceContactsList[0].practiceContactsPrimaryEmail;
                practicesControllerVM.PracticeContactsWebsiteAddress = practicesControllerVM.practiceContactsList[0].practiceContactsWebsiteAddress;
                practicesControllerVM.PracticeContactsSecondaryPhone = practicesControllerVM.practiceContactsList[0].practiceContactsSecondaryPhone;
                practicesControllerVM.PracticeContactsSecondaryEmail = practicesControllerVM.practiceContactsList[0].practiceContactsSecondaryEmail;
            }
        }

        // Timings

        function practiceTimingsCopyToAll() {
            practicesControllerVM.practiceTimingsTuesday = practicesControllerVM.practiceTimingsMonday;
            practicesControllerVM.practiceTimingsWednesday = practicesControllerVM.practiceTimingsMonday;
            practicesControllerVM.practiceTimingsThursday = practicesControllerVM.practiceTimingsMonday;
            practicesControllerVM.practiceTimingsFriday = practicesControllerVM.practiceTimingsMonday;
            practicesControllerVM.practiceTimingsSaturday = practicesControllerVM.practiceTimingsMonday;
            practicesControllerVM.practiceTimingsSunday = practicesControllerVM.practiceTimingsMonday;

            practicesControllerVM.practiceTimingsTuesdayOpenHours1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            practicesControllerVM.practiceTimingsTuesdayOpenMinutes1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            practicesControllerVM.practiceTimingsTuesdayCloseHours1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            practicesControllerVM.practiceTimingsTuesdayCloseMinutes1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            practicesControllerVM.practiceTimingsTuesdayOpenHours2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            practicesControllerVM.practiceTimingsTuesdayOpenMinutes2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            practicesControllerVM.practiceTimingsTuesdayCloseHours2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            practicesControllerVM.practiceTimingsTuesdayCloseMinutes2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;
            practicesControllerVM.practiceTimingsWednesdayOpenHours1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            practicesControllerVM.practiceTimingsWednesdayOpenMinutes1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            practicesControllerVM.practiceTimingsWednesdayCloseHours1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            practicesControllerVM.practiceTimingsWednesdayCloseMinutes1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            practicesControllerVM.practiceTimingsWednesdayOpenHours2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            practicesControllerVM.practiceTimingsWednesdayOpenMinutes2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            practicesControllerVM.practiceTimingsWednesdayCloseHours2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            practicesControllerVM.practiceTimingsWednesdayCloseMinutes2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;
            practicesControllerVM.practiceTimingsThursdayOpenHours1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            practicesControllerVM.practiceTimingsThursdayOpenMinutes1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            practicesControllerVM.practiceTimingsThursdayCloseHours1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            practicesControllerVM.practiceTimingsThursdayCloseMinutes1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            practicesControllerVM.practiceTimingsThursdayOpenHours2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            practicesControllerVM.practiceTimingsThursdayOpenMinutes2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            practicesControllerVM.practiceTimingsThursdayCloseHours2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            practicesControllerVM.practiceTimingsThursdayCloseMinutes2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;
            practicesControllerVM.practiceTimingsFridayOpenHours1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            practicesControllerVM.practiceTimingsFridayOpenMinutes1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            practicesControllerVM.practiceTimingsFridayCloseHours1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            practicesControllerVM.practiceTimingsFridayCloseMinutes1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            practicesControllerVM.practiceTimingsFridayOpenHours2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            practicesControllerVM.practiceTimingsFridayOpenMinutes2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            practicesControllerVM.practiceTimingsFridayCloseHours2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            practicesControllerVM.practiceTimingsFridayCloseMinutes2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;
            practicesControllerVM.practiceTimingsSaturdayOpenHours1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            practicesControllerVM.practiceTimingsSaturdayOpenMinutes1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            practicesControllerVM.practiceTimingsSaturdayCloseHours1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            practicesControllerVM.practiceTimingsSaturdayCloseMinutes1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            practicesControllerVM.practiceTimingsSaturdayOpenHours2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            practicesControllerVM.practiceTimingsSaturdayOpenMinutes2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            practicesControllerVM.practiceTimingsSaturdayCloseHours2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            practicesControllerVM.practiceTimingsSaturdayCloseMinutes2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;
            practicesControllerVM.practiceTimingsSundayOpenHours1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            practicesControllerVM.practiceTimingsSundayOpenMinutes1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            practicesControllerVM.practiceTimingsSundayCloseHours1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            practicesControllerVM.practiceTimingsSundayCloseMinutes1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            practicesControllerVM.practiceTimingsSundayOpenHours2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            practicesControllerVM.practiceTimingsSundayOpenMinutes2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            practicesControllerVM.practiceTimingsSundayCloseHours2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            practicesControllerVM.practiceTimingsSundayCloseMinutes2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;
        }

        function getPracticeTimings(providerId) {
            $scope.startSpin();
            debugger;
            return practicesService.getPracticeTimings({ providerId: providerId }).then(function (data) {
                var response = data.results;
                practicesControllerVM.practiceDetailsPracticeTimingsList = response;
                console.log(practicesControllerVM.practiceDetailsPracticeTimingsList);
                $scope.stopSpin();
                setPracticeTimings();
                return response;
            });
        }

         function setPracticeTimings() {
            if (practicesControllerVM.practiceDetailsPracticeTimingsList.length > 0) {
                console.log(practicesControllerVM.practiceDetailsPracticeTimingsList);
                practicesControllerVM.practiceTimingsMonday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].monday;
                var monOpenHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenHour1);
                if (monOpenHour1 > 12) {
                    practicesControllerVM.practiceTimingsMondayOpenHours1 = (monOpenHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsMondayOpenHours1 = monOpenHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsMondayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsMondayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenMinute1; }
                var monCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseHour1);
                if (monCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsMondayCloseHours1 = (monCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsMondayCloseHours1 = monCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsMondayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsMondayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseMinute1; }

                var monOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenHour2);
                if (monOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsMondayOpenHours2 = (monOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsMondayOpenHours2 = monOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsMondayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsMondayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].monOpenMinute2; }

                var monCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseHour2);
                if (monCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsMondayCloseHours2 = (monCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsMondayCloseHours2 = monCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsMondayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsMondayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].monCloseMinute2; }


                practicesControllerVM.practiceTimingsTuesday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].tuesday;
                var tueOpeneHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenHour1);
                if (tueOpeneHour1 > 12) {
                    practicesControllerVM.practiceTimingsTuesdayOpenHours1 = (tueOpeneHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsTuesdayOpenHours1 = tueOpeneHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsTuesdayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsTuesdayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenMinute1; }

                var tueCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseHour1);
                if (tueCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsTuesdayCloseHours1 = (tueCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsTuesdayCloseHours1 = tueCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsTuesdayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsTuesdayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseMinute1; }



                var tueOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenHour2);
                if (tueOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsTuesdayOpenHours2 = (tueOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsTuesdayOpenHours2 = tueOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsTuesdayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsTuesdayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueOpenMinute2; }


                var tueCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseHour2);
                if (tueCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsTuesdayCloseHours2 = (tueCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsTuesdayCloseHours2 = tueCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsTuesdayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsTuesdayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].tueCloseMinute2; }


                practicesControllerVM.practiceTimingsWednesday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].wednesday;
                var wedOpenHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenHour1);
                if (wedOpenHour1 > 12) {
                    practicesControllerVM.practiceTimingsWednesdayOpenHours1 = (wedOpenHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsWednesdayOpenHours1 = wedOpenHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsWednesdayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsWednesdayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenMinute1; }


                var wedCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseHour1);
                if (wedCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsWednesdayCloseHours1 = (wedCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsWednesdayCloseHours1 = wedCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsWednesdayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsWednesdayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseMinute1; }

                var wedOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenHour2);
                if (wedOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsWednesdayOpenHours2 = (wedOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsWednesdayOpenHours2 = wedOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsWednesdayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsWednesdayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedOpenMinute2; }

                var wedCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseHour2);
                if (wedCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsWednesdayCloseHours2 = (wedCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsWednesdayCloseHours2 = wedCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsWednesdayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsWednesdayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].wedCloseMinute2; }

                practicesControllerVM.practiceTimingsThursday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].thursday;
                var thuOpenHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenHour1);
                if (thuOpenHour1 > 12) {
                    practicesControllerVM.practiceTimingsThursdayOpenHours1 = (thuOpenHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsThursdayOpenHours1 = thuOpenHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsThursdayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsThursdayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenMinute1; }

                var thuCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseHour1);
                if (thuCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsThursdayCloseHours1 = (thuCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsThursdayCloseHours1 = thuCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsThursdayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsThursdayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseMinute1; }

                var thuOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenHour2);
                if (thuOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsThursdayOpenHours2 = (thuOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsThursdayOpenHours2 = thuOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsThursdayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsThursdayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuOpenMinute2; }

                var thuCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseHour2);
                if (thuCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsThursdayCloseHours2 = (thuCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsThursdayCloseHours2 = thuCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsThursdayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsThursdayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].thuCloseMinute2; }


                practicesControllerVM.practiceTimingsFriday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].friday;
                var friOpenHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenHour1);
                if (friOpenHour1 > 12) {
                    practicesControllerVM.practiceTimingsFridayOpenHours1 = (friOpenHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsFridayOpenHours1 = friOpenHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsFridayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsFridayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenMinute1; }

                var friCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseHour1);
                if (friCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsFridayCloseHours1 = (friCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsFridayCloseHours1 = friCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsFridayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsFridayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseMinute1; }

                var friOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenHour2);
                if (friOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsFridayOpenHours2 = (friOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsFridayOpenHours2 = friOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsFridayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsFridayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].friOpenMinute2; }

                var friCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseHour2);
                if (friCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsFridayCloseHours2 = (friCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsFridayCloseHours2 = friCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsFridayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsFridayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].friCloseMinute2; }


                practicesControllerVM.practiceTimingsSaturday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].saturday;
                var satOpenHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenHour1);
                if (satOpenHour1 > 12) {
                    practicesControllerVM.practiceTimingsSaturdayOpenHours1 = (satOpenHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSaturdayOpenHours1 = satOpenHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsSaturdayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsSaturdayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenMinute1; }


                var satCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseHour1);
                if (satCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsSaturdayCloseHours1 = (satCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSaturdayCloseHours1 = satCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsSaturdayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsSaturdayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseMinute1; }

                var satOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenHour2);
                if (satOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsSaturdayOpenHours2 = (satOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSaturdayOpenHours2 = satOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsSaturdayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsSaturdayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].satOpenMinute2; }

                var satCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseHour2);
                if (satCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsSaturdayCloseHours2 = (satCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSaturdayCloseHours2 = satCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsSaturdayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsSaturdayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].satCloseMinute2; }


                practicesControllerVM.practiceTimingsSunday = practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunday;
                var sunOpenHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenHour1);
                if (sunOpenHour1 > 12) {
                    practicesControllerVM.practiceTimingsSundayOpenHours1 = (sunOpenHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSundayOpenHours1 = sunOpenHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenMinute1) < 10) {
                    practicesControllerVM.practiceTimingsSundayOpenMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenMinute1;
                }
                else { practicesControllerVM.practiceTimingsSundayOpenMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenMinute1; }


                var sunCloseHour1 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseHour1);
                if (sunCloseHour1 > 12) {
                    practicesControllerVM.practiceTimingsSundayCloseHours1 = (sunCloseHour1 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSundayCloseHours1 = sunCloseHour1 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseMinute1) < 10) {
                    practicesControllerVM.practiceTimingsSundayCloseMinutes1 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseMinute1;
                }
                else { practicesControllerVM.practiceTimingsSundayCloseMinutes1 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseMinute1; }


                var sunOpenHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenHour2);
                if (sunOpenHour2 > 12) {
                    practicesControllerVM.practiceTimingsSundayOpenHours2 = (sunOpenHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSundayOpenHours2 = sunOpenHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenMinute2) < 10) {
                    practicesControllerVM.practiceTimingsSundayOpenMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenMinute2;
                }
                else { practicesControllerVM.practiceTimingsSundayOpenMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunOpenMinute2; }

                var sunCloseHour2 = parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseHour2);
                if (sunCloseHour2 > 12) {
                    practicesControllerVM.practiceTimingsSundayCloseHours2 = (sunCloseHour2 % 12) + ' pm';
                }
                else { practicesControllerVM.practiceTimingsSundayCloseHours2 = sunCloseHour2 + ' am'; }
                if (parseInt(practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseMinute2) < 10) {
                    practicesControllerVM.practiceTimingsSundayCloseMinutes2 = '0' + practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseMinute2;
                }
                else { practicesControllerVM.practiceTimingsSundayCloseMinutes2 = practicesControllerVM.practiceDetailsPracticeTimingsList[0].sunCloseMinute2; }
            }
        }

        function addPracticeTimings(providerId) {
            $scope.reset();
            var mondy = practicesControllerVM.practiceTimingsMonday;
            var monOpenHr1 = practicesControllerVM.practiceTimingsMondayOpenHours1;
            var monOpenMnt1 = practicesControllerVM.practiceTimingsMondayOpenMinutes1;
            var monCloseHr1 = practicesControllerVM.practiceTimingsMondayCloseHours1;
            var monCloseMnt1 = practicesControllerVM.practiceTimingsMondayCloseMinutes1;
            var monOpenHr2 = practicesControllerVM.practiceTimingsMondayOpenHours2;
            var monOpenMnt2 = practicesControllerVM.practiceTimingsMondayOpenMinutes2;
            var monCloseHr2 = practicesControllerVM.practiceTimingsMondayCloseHours2;
            var monCloseMnt2 = practicesControllerVM.practiceTimingsMondayCloseMinutes2;

            var tuesday = practicesControllerVM.practiceTimingsTuesday;
            var tueOpenHr1 = practicesControllerVM.practiceTimingsTuesdayOpenHours1;
            var tueOpenMnt1 = practicesControllerVM.practiceTimingsTuesdayOpenMinutes1;
            var tueCloseHr1 = practicesControllerVM.practiceTimingsTuesdayCloseHours1;
            var tueCloseMnt1 = practicesControllerVM.practiceTimingsTuesdayCloseMinutes1;
            var tueOpenHr2 = practicesControllerVM.practiceTimingsTuesdayOpenHours2;
            var tueOpenMnt2 = practicesControllerVM.practiceTimingsTuesdayOpenMinutes2;
            var tueCloseHr2 = practicesControllerVM.practiceTimingsTuesdayCloseHours2;
            var tueCloseMnt2 = practicesControllerVM.practiceTimingsTuesdayCloseMinutes2;

            var wednesday = practicesControllerVM.practiceTimingsWednesday;
            var wedOpenHr1 = practicesControllerVM.practiceTimingsWednesdayOpenHours1;
            var wedOpenMnt1 = practicesControllerVM.practiceTimingsWednesdayOpenMinutes1;
            var wedCloseHr1 = practicesControllerVM.practiceTimingsWednesdayCloseHours1;
            var wedCloseMnt1 = practicesControllerVM.practiceTimingsWednesdayCloseMinutes1;
            var wedOpenHr2 = practicesControllerVM.practiceTimingsWednesdayOpenHours2;
            var wedOpenMnt2 = practicesControllerVM.practiceTimingsWednesdayOpenMinutes2;
            var wedCloseHr2 = practicesControllerVM.practiceTimingsWednesdayCloseHours2;
            var wedCloseMnt2 = practicesControllerVM.practiceTimingsWednesdayCloseMinutes2;

            var thursday = practicesControllerVM.practiceTimingsThursday;
            var thuOpenHr1 = practicesControllerVM.practiceTimingsThursdayOpenHours1;
            var thuOpenMnt1 = practicesControllerVM.practiceTimingsThursdayOpenMinutes1;
            var thuCloseHr1 = practicesControllerVM.practiceTimingsThursdayCloseHours1;
            var thuCloseMnt1 = practicesControllerVM.practiceTimingsThursdayCloseMinutes1;
            var thuOpenHr2 = practicesControllerVM.practiceTimingsThursdayOpenHours2;
            var thuOpenMnt2 = practicesControllerVM.practiceTimingsThursdayOpenMinutes2;
            var thuCloseHr2 = practicesControllerVM.practiceTimingsThursdayCloseHours2;
            var thuCloseMnt2 = practicesControllerVM.practiceTimingsThursdayCloseMinutes2;

            var friday = practicesControllerVM.practiceTimingsFriday;
            var friOpenHr1 = practicesControllerVM.practiceTimingsFridayOpenHours1;
            var friOpenMnt1 = practicesControllerVM.practiceTimingsFridayOpenMinutes1;
            var friCloseHr1 = practicesControllerVM.practiceTimingsFridayCloseHours1;
            var friCloseMnt1 = practicesControllerVM.practiceTimingsFridayCloseMinutes1;
            var friOpenHr2 = practicesControllerVM.practiceTimingsFridayOpenHours2;
            var friOpenMnt2 = practicesControllerVM.practiceTimingsFridayOpenMinutes2;
            var friCloseHr2 = practicesControllerVM.practiceTimingsFridayCloseHours2;
            var friCloseMnt2 = practicesControllerVM.practiceTimingsFridayCloseMinutes2;

            var saturday = practicesControllerVM.practiceTimingsSaturday;
            var satOpenHr1 = practicesControllerVM.practiceTimingsSaturdayOpenHours1;
            var satOpenMnt1 = practicesControllerVM.practiceTimingsSaturdayOpenMinutes1;
            var satCloseHr1 = practicesControllerVM.practiceTimingsSaturdayCloseHours1;
            var satCloseMnt1 = practicesControllerVM.practiceTimingsSaturdayCloseMinutes1;
            var satOpenHr2 = practicesControllerVM.practiceTimingsSaturdayOpenHours2;
            var satOpenMnt2 = practicesControllerVM.practiceTimingsSaturdayOpenMinutes2;
            var satCloseHr2 = practicesControllerVM.practiceTimingsSaturdayCloseHours2;
            var satCloseMnt2 = practicesControllerVM.practiceTimingsSaturdayCloseMinutes2;

            var sunday = practicesControllerVM.practiceTimingsSunday;
            var sunOpenHr1 = practicesControllerVM.practiceTimingsSundayOpenHours1;
            var sunOpenMnt1 = practicesControllerVM.practiceTimingsSundayOpenMinutes1;
            var sunCloseHr1 = practicesControllerVM.practiceTimingsSundayCloseHours1;
            var sunCloseMnt1 = practicesControllerVM.practiceTimingsSundayCloseMinutes1;
            var sunOpenHr2 = practicesControllerVM.practiceTimingsSundayOpenHours2;
            var sunOpenMnt2 = practicesControllerVM.practiceTimingsSundayOpenMinutes2;
            var sunCloseHr2 = practicesControllerVM.practiceTimingsSundayCloseHours2;
            var sunCloseMnt2 = practicesControllerVM.practiceTimingsSundayCloseMinutes2;
            $scope.startSpin();

            practicesService.addPracticeTimings({
                providerId: providerId,
                monday: mondy, monOpenHour1: monOpenHr1, monOpenMinute1: monOpenMnt1, monCloseHours1: monCloseHr1, monCloseMinutes1: monCloseMnt1,
                monOpenHour2: monOpenHr2, monOpenMinute2: monOpenMnt2, monCloseHours2: monCloseHr2, monCloseMinutes2: monCloseMnt2,
                tuesday: tuesday, tueOpenHour1: tueOpenHr1, tueOpenMinute1: tueOpenMnt1, tueCloseHours1: tueCloseHr1, tueCloseMinutes1: tueCloseMnt1,
                tueOpenHour2: tueOpenHr2, tueOpenMinute2: tueOpenMnt2, tueCloseHours2: tueCloseHr2, tueCloseMinutes2: tueCloseMnt2,
                wednesday: wednesday, wedOpenHour1: wedOpenHr1, wedOpenMinute1: wedOpenMnt1, wedCloseHours1: wedCloseHr1, wedCloseMinutes1: wedCloseMnt1,
                wedOpenHour2: wedOpenHr2, wedOpenMinute2: wedOpenMnt2, wedCloseHours2: wedCloseHr2, wedCloseMinutes2: wedCloseMnt2,
                thursday: thursday, thuOpenHour1: thuOpenHr1, thuOpenMinute1: thuOpenMnt1, thuCloseHours1: thuCloseHr1, thuCloseMinutes1: thuCloseMnt1,
                thuOpenHour2: thuOpenHr2, thuOpenMinute2: thuOpenMnt2, thuCloseHours2: thuCloseHr2, thuCloseMinutes2: thuCloseMnt2,
                friday: friday, friOpenHour1: friOpenHr1, friOpenMinute1: friOpenMnt1, friCloseHours1: friCloseHr1, friCloseMinutes1: friCloseMnt1,
                friOpenHour2: friOpenHr2, friOpenMinute2: friOpenMnt2, friCloseHours2: friCloseHr2, friCloseMinutes2: friCloseMnt2,
                saturday: saturday, satOpenHour1: satOpenHr1, satOpenMinute1: satOpenMnt1, satCloseHours1: satCloseHr1, satCloseMinutes1: satCloseMnt1,
                satOpenHour2: satOpenHr2, satOpenMinute2: satOpenMnt2, satCloseHours2: satCloseHr2, satCloseMinutes2: satCloseMnt2,
                sunday: sunday, sunOpenHour1: sunOpenHr1, sunOpenMinute1: sunOpenMnt1, sunCloseHours1: sunCloseHr1, sunCloseMinutes1: sunCloseMnt1,
                sunOpenHour2: sunOpenHr2, sunOpenMinute2: sunOpenMnt2, sunCloseHours2: sunCloseHr2, sunCloseMinutes2: sunCloseMnt2
            }).then(function (data) {
                var response = data.results;
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getPracticeTimings(providerId);
                successAlert(response);
            });

            practicesControllerVM.practiceTimingsMondayOpenHours1 = '';
            practicesControllerVM.practiceTimingsMondayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsMondayCloseHours1 = '';
            practicesControllerVM.practiceTimingsMondayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsMondayOpenHours2 = '';
            practicesControllerVM.practiceTimingsMondayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsMondayCloseHours2 = '';
            practicesControllerVM.practiceTimingsMondayCloseMinutes2 = '';
            practicesControllerVM.practiceTimingsTuesdayOpenHours1 = '';
            practicesControllerVM.practiceTimingsTuesdayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsTuesdayCloseHours1 = '';
            practicesControllerVM.practiceTimingsTuesdayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsTuesdayOpenHours2 = '';
            practicesControllerVM.practiceTimingsTuesdayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsTuesdayCloseHours2 = '';
            practicesControllerVM.practiceTimingsTuesdayCloseMinutes2 = '';
            practicesControllerVM.practiceTimingsWednesdayOpenHours1 = '';
            practicesControllerVM.practiceTimingsWednesdayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsWednesdayCloseHours1 = '';
            practicesControllerVM.practiceTimingsWednesdayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsWednesdayOpenHours2 = '';
            practicesControllerVM.practiceTimingsWednesdayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsWednesdayCloseHours2 = '';
            practicesControllerVM.practiceTimingsWednesdayCloseMinutes2 = '';
            practicesControllerVM.practiceTimingsThursdayOpenHours1 = '';
            practicesControllerVM.practiceTimingsThursdayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsThursdayCloseHours1 = '';
            practicesControllerVM.practiceTimingsThursdayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsThursdayOpenHours2 = '';
            practicesControllerVM.practiceTimingsThursdayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsThursdayCloseHours2 = '';
            practicesControllerVM.practiceTimingsThursdayCloseMinutes2 = '';
            practicesControllerVM.practiceTimingsFridayOpenHours1 = '';
            practicesControllerVM.practiceTimingsFridayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsFridayCloseHours1 = '';
            practicesControllerVM.practiceTimingsFridayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsFridayOpenHours2 = '';
            practicesControllerVM.practiceTimingsFridayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsFridayCloseHours2 = '';
            practicesControllerVM.practiceTimingsFridayCloseMinutes2 = '';
            practicesControllerVM.practiceTimingsSaturdayOpenHours1 = '';
            practicesControllerVM.practiceTimingsSaturdayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsSaturdayCloseHours1 = '';
            practicesControllerVM.practiceTimingsSaturdayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsSaturdayOpenHours2 = '';
            practicesControllerVM.practiceTimingsSaturdayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsSaturdayCloseHours2 = '';
            practicesControllerVM.practiceTimingsSaturdayCloseMinutes2 = '';
            practicesControllerVM.practiceTimingsSundayOpenHours1 = '';
            practicesControllerVM.practiceTimingsSundayOpenMinutes1 = '';
            practicesControllerVM.practiceTimingsSundayCloseHours1 = '';
            practicesControllerVM.practiceTimingsSundayCloseMinutes1 = '';
            practicesControllerVM.practiceTimingsSundayOpenHours2 = '';
            practicesControllerVM.practiceTimingsSundayOpenMinutes2 = '';
            practicesControllerVM.practiceTimingsSundayCloseHours2 = '';
            practicesControllerVM.practiceTimingsSundayCloseMinutes2 = '';
        }


        //Billing Currency
        function getPracticeBillingCurrency() {
            debugger;
            var billingCurrency = practicesControllerVM.practiceDetailsBillingCurrency;
                $scope.startSpin();
            return practicesService.getPracticeBillingCurrency().then(function (data) {
                var response = data.results;
                practicesControllerVM.billingCurrencyList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.billingCurrencyList;
            });

            practicesControllerVM.practiceDetailsBillingCurrency = '';
        }


        //Practice Type
        function getPracticeType() {
            debugger;
            var practiceType = practicesControllerVM.practiceDetailsPracticeType;
            $scope.startSpin();
            return practicesService.getPracticeType().then(function (data) {
                var response = data.results;
                practicesControllerVM.practiceTypeList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.practiceTypeList;
            });

            practicesControllerVM.practiceDetailsPracticeType = '';
        }


        //Country
        function getPracticeCountry() {
            debugger;
            var practiceCountry = practicesControllerVM.practiceLocationCountry;
            $scope.startSpin();
            return practicesService.getPracticeCountry().then(function (data) {
                var response = data.results;
                practicesControllerVM.practiceCountryList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.practiceCountryList;
            });

            practicesControllerVM.practiceLocationCountry = '';
        }


        //Provider Practices
        function getProviderPractices() {
            debugger;
            var providerPractices = practicesControllerVM.providerPractices;
            $scope.startSpin();
            return practicesService.getProviderPractices().then(function (data) {
                var response = data.results;
                practicesControllerVM.ProviderPracticesList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.ProviderPracticesList;
            });

            practicesControllerVM.providerPractices = '';
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Services
        function getServices() {
            var service = practicesControllerVM.practiceServicesServiceName.trim();
            $scope.startSpin();
            return practicesService.getServices().then(function (data) {
                var response = data.results;
                practicesControllerVM.servicesList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.servicesList;
            });

            practicesControllerVM.practiceServicesServiceName = '';
        }

        function getAddedServices() {
            $scope.startSpin();
            return practicesService.getAddedServices().then(function (data) {
                var response = data.results;
                practicesControllerVM.addedServicesList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.addedServicesList;
            });
        }

        function loadMoreServices() {
            if (practicesControllerVM.addedServicesListCount < practicesControllerVM.addedServicesList.length)
            { practicesControllerVM.addedServicesListCount += 5; }
        }

        function addPracticeServices() {
            var service = practicesControllerVM.practiceServicesServiceName.trim();
            $scope.startSpin();
            practicesService.addPracticeServices({ title: service }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getServices();
            });

            practicesControllerVM.practiceServicesServiceName = '';
        }

        function addToPracticeServices() {
            var service = practicesControllerVM.practiceServicesServiceName;
            $scope.startSpin();
            var serviceId = '';
            for (var i = 0 ; i < practicesControllerVM.servicesList.length; i++) {
                if (practicesControllerVM.servicesList[i].title == service) {
                    serviceId = parseInt(practicesControllerVM.servicesList[i].serviceId);
                    break;
                }
            }
            practicesService.addToPracticeServices({ serviceId: serviceId }).then(function (data) {
                var response = data.results;
                successAlert(response);
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedServices();

                return practicesControllerVM.addedServicesList;
            });
            practicesControllerVM.practiceServicesServiceName = '';
        }

        function removePracticeServices(serviceId) {
            $scope.startSpin();
            practicesService.removePracticeServices({ serviceId: serviceId }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getAddedServices();
            });
        }

        //Travel Service
        function getTravelServices() {
            var service = practicesControllerVM.practiceServicesTravelServiceName.trim();
            $scope.startSpin();
            return practicesService.getTravelServices().then(function (data) {
                var response = data.results;
                practicesControllerVM.travelServicesList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.travelServicesList;
            });

            practicesControllerVM.practiceServicesTravelServiceName = '';

        }

        function getAddedTravelServices() {
            $scope.startSpin();
            return practicesService.getAddedTravelServices().then(function (data) {
                var response = data.results;
                practicesControllerVM.addedTravelServicesList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.addedTravelServicesList;
            });
        }

        function loadMoreTravelServices() {
            if (practicesControllerVM.addedTravelServicesListCount < practicesControllerVM.addedTravelServicesList.length)
            { practicesControllerVM.addedTravelServicesListCount += 5; }
        }

        function addPracticeTravelServices() {
            var travelService = practicesControllerVM.practiceServicesTravelServiceName.trim();
            $scope.startSpin();
            practicesService.addPracticeTravelServices({ title: travelService }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getTravelServices();
            });

            practicesControllerVM.practiceServicesTravelServiceName = '';
        }

        function addToPracticeTravelServices() {
            debugger;
            var travelservices = practicesControllerVM.practiceServicesTravelServiceName;
            debugger;
            $scope.startSpin();
            var travelserviceId = '';
            for (var i = 0 ; i < practicesControllerVM.travelServicesList.length; i++) {
                if (practicesControllerVM.travelServicesList[i].title == travelservices) {
                    travelserviceId = parseInt(practicesControllerVM.travelServicesList[i].travelserviceId);
                    break;
                }
            }
            practicesService.addToPracticeTravelServices({ travelserviceId: travelserviceId }).then(function (data) {
                var response = data.results;
                successAlert(response);
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedTravelServices();
                return practicesControllerVM.addedTravelServicesList;
            });
            practicesControllerVM.practiceServicesTravelServiceName = '';
        }

        function removePracticeTravelServices(travelService) {
            $scope.startSpin();
            practicesService.removePracticeTravelServices({ name: travelService }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
            });
        }

        // Premises
        function getPremises() {
            debugger;
            $scope.startSpin();
            return practicesService.getPremises().then(function (data) {
                var response = data.results;
                practicesControllerVM.premisesList = response;
                $scope.stopSpin();
                return practicesControllerVM.premisesList;
            });

            practicesControllerVM.practicePremisesPremisName = '';
        }

        function getAddedPremises() {
            $scope.startSpin();
            return practicesService.getAddedPremises().then(function (data) {
                var response = data.results;
                practicesControllerVM.addedPremisesList = response;
                $scope.stopSpin();
                return practicesControllerVM.addedPremisesList;
            });
        }

        function loadMorePremises() {
            if (practicesControllerVM.addedPremisesListCount < practicesControllerVM.addedPremisesList.length)
            { practicesControllerVM.addedPremisesListCount += 5; }
        }

        function addPracticePremises() {
            debugger;
            var persentlength = parseInt(practicesControllerVM.premisesList.length);

            var premises = practicesControllerVM.practicePremisesPremisName.trim();
            $scope.startSpin();
            practicesService.addPracticePremises({ name: premises }).then(function (data) {
                var response = data.results;
                var newlength1 = parseInt(data.results.length);
                practicesControllerVM.premisesList = response;
                $scope.reset();
                $scope.stopSpin();
                if (newlength1 > persentlength) {
                    successAlert("Practice Premise added successfully");

                }
            });

            practicesControllerVM.practicePremisesPremisName = '';
        }

        function addToPracticePremises() {
            debugger;
            var premises = practicesControllerVM.practicePremisesPremisName;
            debugger;
            $scope.startSpin();
            var premisesId = '';
            for (var i = 0 ; i < practicesControllerVM.premisesList.length; i++) {
                if (practicesControllerVM.premisesList[i].name == premises) {
                    premisesId = parseInt(practicesControllerVM.premisesList[i].premisesId);
                    break;
                }
            }
            practicesService.addToPracticePremises({ premisesId: premisesId }).then(function (data) {
                var response = data.results;
                successAlert(response);
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedPremises();
                return practicesControllerVM.addedPremisesList;
            });
            practicesControllerVM.practicePremisesPremisName = '';
        }


        function removePracticePremises(premisesId) {
            debugger;
            $scope.startSpin();
            practicesService.removePracticePremises({ premisesId: premisesId }).then(function (data) {
                var response = data.results;
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedPremises();

            });
        }

        //Languages
        function getLanguages() {
            debugger;
            $scope.startSpin();
            return practicesService.getLanguages().then(function (data) {
                var response = data.results;
                practicesControllerVM.languagesList = response;
                $scope.stopSpin();
                return practicesControllerVM.languagesList;
            });
            practicesControllerVM.practiceLanguagesLanguageName = '';
        }

        function getAddedLanguages() {
            $scope.startSpin();
            return practicesService.getAddedLanguages().then(function (data) {
                var response = data.results;
                practicesControllerVM.addedLanguagesList = response;
                //    $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.addedLanguagesList;
            });
        }

        function loadMoreLanguages() {
            if (practicesControllerVM.addedLanguagesListCount < practicesControllerVM.addedLanguagesList.length)
            { practicesControllerVM.addedLanguagesListCount += 5; }
        }

        function addPracticeLanguages() {
            debugger;
            var prelength = parseInt(practicesControllerVM.languagesList.length);
            var language = practicesControllerVM.practiceLanguagesLanguageName.trim();
            $scope.startSpin();
            practicesService.addPracticeLanguages({ name: language }).then(function (data) {
                var response = data.results;
                var newLength = parseInt(data.results.length);
                practicesControllerVM.languagesList = response;
                $scope.reset();
                $scope.stopSpin();
                if (newLength > prelength) {
                    successAlert("Practice Langauge added successfully")
                }
            });

            practicesControllerVM.practiceLanguagesLanguageName = '';
        }

        function addToPracticeLanguages() {
            debugger;
            var language = practicesControllerVM.practiceLanguagesLanguageName;
            debugger;
            $scope.startSpin();
            var languageId = '';
            for (var i = 0 ; i < practicesControllerVM.languagesList.length; i++) {
                if (practicesControllerVM.languagesList[i].name == language) {
                    languageId = parseInt(practicesControllerVM.languagesList[i].languageId);
                    break;
                }
            }
            practicesService.addToPracticeLanguages({ languageId: languageId }).then(function (data) {
                var response = data.results;
                successAlert(response);
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedLanguages();
                //practicesService.getAddedLanguages();
                return practicesControllerVM.addedLanguagesList;
            });
            practicesControllerVM.practiceLanguagesLanguageName = '';
        }

        function removePracticeLanguages(languageId) {
            debugger;
            $scope.startSpin();
            practicesService.removePracticeLanguages({ languageId: languageId }).then(function (data) {
                var response = data.results;
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedLanguages();
                successAlert(response);
            });
        }

        //Accreditation
        function getAccreditations() {
            debugger;
            var accreditation = practicesControllerVM.practiceAccreditationsAccreditationName.trim();
            $scope.startSpin();
            return practicesService.getAccreditations().then(function (data) {
                var response = data.results;
                practicesControllerVM.accreditationsList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.accreditationsList;

            });
            practicesControllerVM.practiceAccreditationsAccreditationName = '';
        }

        function getAddedAccreditations() {
            $scope.startSpin();
            return practicesService.getAddedAccreditations().then(function (data) {
                var response = data.results;
                practicesControllerVM.addedAccreditationsList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.addedAccreditationsList;
            });
        }

        function loadMoreAccreditations() {
            if (practicesControllerVM.addedAccreditationsListCount < practicesControllerVM.addedAccreditationsList.length)
            { practicesControllerVM.addedAccreditationsListCount += 5; }
        }

        function addPracticeAccreditations() {
            var accreditation = practicesControllerVM.practiceAccreditationsAccreditationName.trim();
            $scope.startSpin();
            practicesService.addPracticeAccreditations({ title: accreditation }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getAccreditations();
            });

            practicesControllerVM.practiceAccreditationsAccreditationName = '';
        }

        function addToPracticeAccreditations() {
            debugger;
            var accreditation = practicesControllerVM.practiceAccreditationsAccreditationName;
            debugger;
            $scope.startSpin();
            var accreditationId = '';
            for (var i = 0 ; i < practicesControllerVM.accreditationsList.length; i++) {
                if (practicesControllerVM.accreditationsList[i].title == accreditation) {
                    accreditationId = parseInt(practicesControllerVM.accreditationsList[i].accreditationId);
                    break;
                }
            }
            practicesService.addToPracticeAccreditations({ accreditationId: accreditationId }).then(function (data) {
                var response = data.results;
                successAlert(response);
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedAccreditations();

                return practicesControllerVM.addedAccreditationsList;
            });
            practicesControllerVM.practiceAccreditationsAccreditationName = '';
        }

        function removePracticeAccreditations(accreditationId) {
            $scope.startSpin();
            practicesService.removePracticeAccreditations({ accreditationId: accreditationId }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getAddedAccreditations();
            });
        }

        //Insurance
        function getInsurances() {
            var insurance = practicesControllerVM.practiceInsurancesInsuranceName.trim();
            $scope.startSpin();
            return practicesService.getInsurances().then(function (data) {
                var response = data.results;
                practicesControllerVM.insurancesList = response;
                $scope.reset();
                $scope.stopSpin();

                return practicesControllerVM.insurancesList;
            })
            practicesControllerVM.practiceInsurancesInsuranceName = '';
        }

        function getAddedInsurances() {
            $scope.startSpin();
            return practicesService.getAddedInsurances().then(function (data) {
                var response = data.results;
                practicesControllerVM.addedInsurancesList = response;
                $scope.reset();
                $scope.stopSpin();
                return practicesControllerVM.addedInsurancesList;
            });
        }

        function loadMoreInsurances() {
            if (practicesControllerVM.addedInsurancesListCount < practicesControllerVM.addedInsurancesList.length)
            { practicesControllerVM.addedInsurancesListCount += 5; }
        }

        function addPracticeInsurances() {
            var insurance = practicesControllerVM.practiceInsurancesInsuranceName.trim();
            $scope.startSpin();
            practicesService.addPracticeInsurances({ title: insurance }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getInsurances();
            });
            practicesControllerVM.practiceInsurancesInsuranceName = '';
        }

        function addToPracticeInsurances() {
            debugger;
            var insurance = practicesControllerVM.practiceInsurancesInsuranceName;
            debugger;
            $scope.startSpin();
            var insuranceId = '';
            for (var i = 0 ; i < practicesControllerVM.insurancesList.length; i++) {
                if (practicesControllerVM.insurancesList[i].title == insurance) {
                    insuranceId = parseInt(practicesControllerVM.insurancesList[i].insuranceId);
                    break;
                }
            }
            practicesService.addToPracticeInsurances({ insuranceId: insuranceId }).then(function (data) {
                var response = data.results;
                successAlert(response);
                $scope.reset();
                $scope.stopSpin();
                practicesControllerVM.getAddedInsurances();

                return practicesControllerVM.addedInsurancesList;
            });
            practicesControllerVM.practiceInsurancesInsuranceName = '';
        }

        function removePracticeInsurances(insuranceId) {
            $scope.startSpin();
            practicesService.removePracticeInsurances({ insuranceId: insuranceId }).then(function (data) {
                var response = data.results;
                $scope.reset();
                successAlert(response);
                $scope.stopSpin();
                practicesControllerVM.getAddedInsurances();
            });
        }
    }
})();