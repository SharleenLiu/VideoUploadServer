using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace VideoUploadServer.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost()]
        public ActionResult UploadVideo(HttpPostedFileBase video)
        {
            var path = Path.Combine(HttpContext.Server.MapPath("~/Content"), Path.GetFileName(video.FileName));
            video.SaveAs(path);
            return new ContentResult {Content = "sucess"};
        }

        public ActionResult Upload()
        {

            return View();
        }

        
    }
}
