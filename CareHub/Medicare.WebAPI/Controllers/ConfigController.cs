using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;
using Breeze.WebApi2;
using Medicare.Data;
using CareHub.Core;

namespace CareHub.WebAPI.Controllers
{
    [BreezeController]
    public class ConfigController : BaseController
    {
        [HttpGet]
        public string Metadata()
        {
            return base.Metadata;
        }

        //// GET: api/Authentication
        //public IQueryable<User> GetUsers()
        //{
        //    return db.User;
        //}

        //// GET: api/Authentication/5
        //[ResponseType(typeof(User))]
        //public IHttpActionResult GetUser(string id)
        //{
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}
               

        [HttpGet]
        public IQueryable<Medicare.Data.Specialty> GetSpecialties()
        {
            Medicare.Data.shiner49_medicareEntities db = new Medicare.Data.shiner49_medicareEntities();
            
            //specialties.Add("Allergy and Immunology");
            //specialties.Add("Orthopaedics");
            //specialties.Add("Neurology");
            //specialties.Add("General surgery");

            return db.Specialties;
        }
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool UserExists(string id)
        //{
        //    return db.User.Count(e => e.UserId == id) > 0;
        //}
    }
}