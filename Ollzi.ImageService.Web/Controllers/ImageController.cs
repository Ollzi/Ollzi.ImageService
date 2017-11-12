﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Ollzi.ImageService.Business;
using Ollzi.ImageService.Business.Action;
using Ollzi.ImageService.Contracts;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;

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

        public HttpResponseMessage GetImage(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            Image img = Image.FromFile(image);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
        }
    }
}
