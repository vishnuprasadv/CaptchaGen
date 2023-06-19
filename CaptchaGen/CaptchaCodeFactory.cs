using System;
using System.Security.Cryptography;

namespace CaptchaGen
{
    public static class CaptchaCodeFactory
    {

        private const string OnlyDigits = "0123456789";
        private const string OnlyUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string OnlyLowwer = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Type of generated Captcha
        /// </summary>
        public enum captchaTypes
        {
            OnlyUpper,
            OnlyLowwer,
            OnlyDigits,
            UpperAndLower,
            UpperAndDigits,
            LowerAndDigits,
            UpperAndLowerAndDigits,
        }

        /// <summary>
        /// Generates and returns a random sequence of strings
        /// </summary>
        /// <param name="size">Length of the string to be returned.</param>
        /// <returns>Captcha string</returns>
        public static string GenerateCaptchaCode(int size = 4, captchaTypes charType = captchaTypes.OnlyUpper)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size cannot be less than or equal to 0");
            }

            string captcha = null;
            var chars = string.Empty;
            switch (charType)
            {
                case captchaTypes.OnlyUpper:
                    chars = OnlyUpper;
                    break;
                case captchaTypes.OnlyLowwer:
                    chars = OnlyLowwer;
                    break;
                case captchaTypes.OnlyDigits:
                    chars = OnlyDigits;
                    break;
                case captchaTypes.UpperAndLower:
                    chars = OnlyLowwer + OnlyUpper;
                    break;
                case captchaTypes.UpperAndDigits:
                    chars = OnlyUpper + OnlyDigits;
                    break;
                case captchaTypes.LowerAndDigits:
                    chars = OnlyLowwer + OnlyDigits;
                    break;
                case captchaTypes.UpperAndLowerAndDigits:
                    chars = OnlyUpper + OnlyLowwer + OnlyDigits;
                    break;
                default:
                    chars = OnlyUpper + OnlyLowwer + OnlyDigits;
                    break;
            }

            var stringChars = new char[size];
            int number;
            byte[] fillBuffer = new byte[4];

            //CryptoService random byte generator for randomization
            RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();

            for (int i = 0; i < stringChars.Length; i++)
            {
                rngCSP.GetBytes(fillBuffer);
                number = Math.Abs(BitConverter.ToInt32(fillBuffer, 0)) % chars.Length;
                stringChars[i] = chars[number];
            }

            captcha = new string(stringChars);

            return captcha;
        }
    }
}
