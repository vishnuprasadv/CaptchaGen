using CaptchaGen;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example.Controllers
{
    /// <summary>
    /// Audio Controller class
    /// </summary>
    public class AudioController : ApiController
    {
        /// <summary>
        /// Returns a response message with audio as content
        /// </summary>
        /// <param name="id">Captcha string for which the audio is to be generated</param>
        /// <returns>HttpResponseMessage with "audio/wav" header</returns>
        public HttpResponseMessage Get(string id)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var audioStream = AudioFactory.GenerateAudio(id);
                audioStream.Position = 0;
                response.Content = new StreamContent(audioStream);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");
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
