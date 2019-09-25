﻿using CaptchaGen;
using Example.Models;
using System.Web.Http;

namespace Example.Controllers
{

    /// <summary>
    /// Captcha Controller class
    /// </summary>
    public class CaptchaController : ApiController
    {
        /// <summary>
        /// Returns a captcha string as json object.
        /// </summary>
        /// <returns>CaptchaCode as json object</returns>
        public CaptchaCode GetCaptchaCode()
        {
            return new CaptchaCode() { sessionString = CaptchaCodeFactory.GenerateCaptchaCode(8) };
        }
    }
}
