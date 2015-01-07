using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareHub.WebAPI
{
    public class Config
    {
        public static List<long> GetSpecialties()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<long> specialtiesList = new List<long>();
            specialtiesList.Add(1);
            specialtiesList.Add(2);
            specialtiesList.Add(3);
            specialtiesList.Add(4);
            //specialtiesList.Add("Allergy and Immunology");
            //specialtiesList.Add("Orthopaedics");
            //specialtiesList.Add("Neurology");
            //specialtiesList.Add("General surgery");
            
            return specialtiesList;
        }       

        public static IEnumerable<int> GetCountries()
        {
            List<int> countriesList = new List<int>();
            countriesList.Add(1);
            countriesList.Add(2);
            countriesList.Add(3);
            countriesList.Add(4);

            return countriesList.AsEnumerable<int>();
        }

        public static List<string> GetServices()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<string> servicesList = new List<string>();
            servicesList.Add("X-RAY");
            servicesList.Add("Ultrasound");
            servicesList.Add("Surgery");
            servicesList.Add("CT scan");
            servicesList.Add("Laboratory tests");

            return servicesList;
        }

        public static List<string> GetTravelServices()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<string> travelServicesList = new List<string>();
            travelServicesList.Add("A");
            travelServicesList.Add("B");
            travelServicesList.Add("C");
            travelServicesList.Add("D");
            travelServicesList.Add("E");

            return travelServicesList;
        }

        public static List<string> GetPremises()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<string> premisesList = new List<string>();
            premisesList.Add("A");
            premisesList.Add("B");
            premisesList.Add("C");
            premisesList.Add("D");
            premisesList.Add("E");
            premisesList.Add("F");

            return premisesList;
        }

        public static List<string> GetLanguages()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<string> languagesList = new List<string>();
            languagesList.Add("Arabic");
            languagesList.Add("Urdu");
            languagesList.Add("English");
            languagesList.Add("French");
            languagesList.Add("Chinese");

            return languagesList;
        }
        public static List<string> GetAccreditations()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<string> accreditationsList = new List<string>();
            accreditationsList.Add("A");
            accreditationsList.Add("B");
            accreditationsList.Add("C");
            accreditationsList.Add("D");
            accreditationsList.Add("E");
            accreditationsList.Add("F");

            return accreditationsList;
        }

        public static List<string> GetInsurances()
        {
            //CareHub.Data.shiner49_medicareEntities db = new Data.shiner49_medicareEntities();
            //return db.Specialties;

            List<string> insurancesList = new List<string>();
            insurancesList.Add("A");
            insurancesList.Add("B");
            insurancesList.Add("C");
            insurancesList.Add("D");
            insurancesList.Add("E");
            insurancesList.Add("F");

            return insurancesList;
        }

    }
}