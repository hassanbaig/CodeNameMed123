using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Breeze.ContextProvider.EF6;
using Medicare.Data;


namespace Medicare.WebAPI.Controllers
{    
    public class BaseController : ApiController
    {
        public readonly EFContextProvider<MedicareDevEntities>
            _contextProvider = new EFContextProvider<MedicareDevEntities>();
        public MedicareDevEntities Context { get { return _contextProvider.Context; } }
        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }       
    }
}