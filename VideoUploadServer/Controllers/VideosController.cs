using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using VideoUploadServer.Models;
using System.Web;

namespace VideoUploadServer.Controllers
{
    public class VideosController : ApiController
    {
        public IEnumerable<VideoModel> Get()
        {
            var videos = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Content"));
            var ret = videos.Select(v=> new VideoModel
            {
                 name=Path.GetFileNameWithoutExtension(v), 
                 source="/content/"+Path.GetFileName(v)
            });
        
            return ret;
        }
    }
}
