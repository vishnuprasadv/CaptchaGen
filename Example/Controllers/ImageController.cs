using CaptchaGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example.Controllers
{
    /// <summary>
    /// Image controller class
    /// </summary>
    public class ImageController : ApiController
    {
        /// <summary>
        /// Returns a response message as an image.
        /// </summary>
        /// <param name="id">Captcha string for which the image is to be generated</param>
        /// <returns>HttpResponseMessage with "image/jpeg" header</returns>
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var imageStream = ImageFactory.GenerateImage(id);
                imageStream.Position = 0;
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(imageStream);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                return response;
            }
            catch (Exception ex)
            {
                var res = new HttpResponseMessage();
                res.StatusCode = HttpStatusCode.BadRequest;
                return res;
            }

        }
    }
}
