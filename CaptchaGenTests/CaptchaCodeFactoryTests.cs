using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaptchaGen.Tests
{
    [TestClass()]
    public class CaptchaCodeFactoryTests
    {
        [TestMethod()]
        public void GenerateCaptchaCodeTest()
        {
            string captcha = CaptchaGen.CaptchaCodeFactory.GenerateCaptchaCode(6);
            Assert.IsTrue(captcha.Length == 6);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Error is not thrown for an illegal size")]
        public void GenerateCaptchaCodeTest1()
        {
            string captcha = CaptchaGen.CaptchaCodeFactory.GenerateCaptchaCode(-2);
        }
    }
}
