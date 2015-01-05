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
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using CareHub.Factory.Factories;
using CareHub.DomainService;
using CareHub.DomainModel.Models;
using CareHub.Core.Common;

namespace CareHub.WebAPI.Controllers
{
    [BreezeController]
    public class TestController : BaseController
    {
        [HttpGet]
      //  [HttpPost]
        public string Metadata()
        {
            return base.Metadata;
        }       

        //[HttpGet]
        //public IHttpActionResult FileUpload(string name, string path)
        //{
        //    //string FilePath = Path.GetFileName(FileUploadID.PostedFile.FileName);
        //    //if (FilePath != "")
        //    //{
        //    //    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/testUpload/") + FilePath);


        //    //}
        //    return Ok("Uploaded successfully");
        //}
        //   protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {                //db.Dispose();            }
        //        base.Dispose(disposing);
        //    }

        //    //private bool UserExists(string id)
        //    //{
        //    //    return db.User.Count(e => e.UserId == id) > 0;
        //    //}
        //}

       [HttpPost]
    //   [HttpGet]
        public KeyValuePair<bool, string> UploadFile()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedFile != null)
                    {
                        // Validate the uploaded image(optional)

                        // Get the complete file path
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/MyUpload"), httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);

                        return new KeyValuePair<bool, string>(true, "File uploaded successfully.");
                    }

                    return new KeyValuePair<bool, string>(true, "Could not get the uploaded file.");
                }

                return new KeyValuePair<bool, string>(true, "No file found to upload.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file. Error Message: " + ex.Message);
            }
        }
    }
}