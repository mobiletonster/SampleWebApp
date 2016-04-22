using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleWebApp.Controllers
{
    public class StaticController : ApiController
    {
        string _basePath = "C:/";
        public StaticController()
        {

        }

        //public async Task<HttpResponseMessage> Get()
        //{
        //    var url = RequestContext.Url;
        //    var response = new HttpResponseMessage();
        //    response.Content = new StreamContent(File.Open(url.ToString(), FileMode.Open));
        //    return response;
        //}
        public async Task<HttpResponseMessage> Get(string url)
        {

            var response = new HttpResponseMessage();
            var path = _basePath + url;
            var file = File.Open(path, FileMode.Open);

            response.Content = new StreamContent(file);
            // response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }

    }
}
