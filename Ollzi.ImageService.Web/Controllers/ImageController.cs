using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Ollzi.ImageService.Business;
using Ollzi.ImageService.Business.Action;
using Ollzi.ImageService.Contracts;

namespace Ollzi.ImageService.Web.Controllers
{
    public class ImageController : ApiController
    {
        private ImageAction _imageAction;

        public ImageController()
        {
            _imageAction = new ImageAction();
        }

        public HttpResponseMessage GetImages()
        {
            var imageData = _imageAction.GetImages();
            var response = Request.CreateResponse(HttpStatusCode.OK, imageData);
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            return response;
        }
    }
}
