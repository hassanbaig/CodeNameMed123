using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Breeze.ContextProvider.EF6;
using Medicare.Data;


namespace CareHub.WebAPI.Controllers
{    
    public class BaseController : ApiController
    {
        public readonly EFContextProvider<shiner49_medicareEntities>
            _contextProvider = new EFContextProvider<shiner49_medicareEntities>();
        public shiner49_medicareEntities Context { get { return _contextProvider.Context; } }
        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }       
    }
}