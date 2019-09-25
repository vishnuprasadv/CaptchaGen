﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CaptchaGen.Tests
{
    [TestClass()]
    public class ImageFactoryTests
    {
        [TestMethod()]
        public void GenerateImageTest()
        {
            var testString = "fEwS21";
            var stream = ImageFactory.GenerateImage(testString);
            Assert.IsNotNull(stream);
            var image = Image.FromStream(stream) as Bitmap;
            Assert.AreEqual(image.Width, 150);
        }

        [TestMethod()]
        public void GenerateImageWithImageAttributesTest()
        {
            var testString = "fEwS21";
            int height = 135, width = 250;
            var stream = ImageFactory.GenerateImage(testString, height, width, 23);
            Assert.IsNotNull(stream);
            var image = Image.FromStream(stream) as Bitmap;
            Assert.AreEqual(image.Width, width);
            Assert.AreEqual(image.Height, height);
        }
    }
}