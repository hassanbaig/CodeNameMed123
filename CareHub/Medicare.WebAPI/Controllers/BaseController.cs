using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Breeze.ContextProvider.EF6;
using CareHub.Data;


namespace CareHub.WebAPI.Controllers
{    
    public class BaseController : ApiController
    {
        public readonly EFContextProvider<shiner49_CareHubEntities>
            _contextProvider = new EFContextProvider<shiner49_CareHubEntities>();
        public shiner49_CareHubEntities Context { get { return _contextProvider.Context; } }
        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }       
    }
}