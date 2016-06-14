using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaptchaGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptchaGen.Tests
{
    [TestClass()]
    public class AudioFactoryTests
    {
        [TestMethod()]
        public void GenerateAudioTest()
        {
            String testString = "fEwS21";
            var stream = AudioFactory.GenerateAudio(testString);
            Assert.IsNotNull(stream);
        }

        [TestMethod()]
        public void GenerateAudioTestWithROI()
        {
            String testString = "fEwS21";
            var stream = AudioFactory.GenerateAudio(testString,-7);
            Assert.IsNotNull(stream);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Error is not thrown for an illegal captchaCode")]
        public void GenerateAudioIllegalCaptchaCodeTest()
        {
            String testString = "";
            var stream = AudioFactory.GenerateAudio(testString, -7);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Error is not thrown for an null captchaCode")]
        public void GenerateAudioEmptyCaptchaCodeTest()
        {
            String testString = null;
            var stream = AudioFactory.GenerateAudio(testString, -7);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Error is not thrown for an illegal speechRate")]
        public void ThrowExceptionOnSpeechRateTest()
        {
            String testString = "fEwS21";
            var stream = AudioFactory.GenerateAudio(testString, -73);
        }
    }
}