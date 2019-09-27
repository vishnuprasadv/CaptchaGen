using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaptchaGen.Tests
{
    [TestClass()]
    public class AudioFactoryTests
    {
        [TestMethod()]
        public void GenerateAudioTest()
        {
            var testString = "fEwS21";
            var stream = AudioFactory.GenerateAudio(testString);
            Assert.IsNotNull(stream);
        }

        [TestMethod()]
        public void GenerateAudioTestWithROI()
        {
            var testString = "fEwS21";
            var stream = AudioFactory.GenerateAudio(testString,-7);
            Assert.IsNotNull(stream);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Error is not thrown for an illegal captchaCode")]
        public void GenerateAudioIllegalCaptchaCodeTest()
        {
            var testString = "";
            _ = AudioFactory.GenerateAudio(testString, -7);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Error is not thrown for an null captchaCode")]
        public void GenerateAudioEmptyCaptchaCodeTest()
        {
            string testString = null;
            _ = AudioFactory.GenerateAudio(testString, -7);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Error is not thrown for an illegal speechRate")]
        public void ThrowExceptionOnSpeechRateTest()
        {
            var testString = "fEwS21";
            _ = AudioFactory.GenerateAudio(testString, -73);
        }
    }
}