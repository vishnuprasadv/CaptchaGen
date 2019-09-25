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
            var captcha = CaptchaGen.CaptchaCodeFactory.GenerateCaptchaCode(6);
            Assert.IsTrue(captcha.Length == 6);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Error is not thrown for an illegal size")]
        public void GenerateCaptchaCodeTest1()
        {
            var captcha = CaptchaGen.CaptchaCodeFactory.GenerateCaptchaCode(-2);
        }
    }
}
