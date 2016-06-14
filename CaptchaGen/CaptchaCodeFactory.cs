using System;
using System.Security.Cryptography;

namespace CaptchaGen
{
    public static class CaptchaCodeFactory
    {

        /// <summary>
        /// Generates and returns a random sequence of strings
        /// </summary>
        /// <param name="size">Length of the string to be returned.</param>
        /// <returns>Captcha string</returns>
        public static string GenerateCaptchaCode(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size cannot be less than or equal to 0");
            }
            string captcha = null;
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[size];
            int number;
            byte[] fillBuffer = new byte[4];

            //CryptoService random byte generator for randomization
            RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();


            for (int i = 0; i < stringChars.Length; i++)
            {
                rngCSP.GetBytes(fillBuffer);
                number = Math.Abs(BitConverter.ToInt32(fillBuffer, 0)) % 60;
                stringChars[i] = chars[number];
            }

            captcha = new string(stringChars);

            return captcha;
        }

    }
}
