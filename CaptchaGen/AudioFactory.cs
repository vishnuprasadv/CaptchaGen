using System;
using System.IO;
using System.Speech.Synthesis;

namespace CaptchaGen
{
    public static class AudioFactory
    {
        private const int SPEECHRATE = -7;

        /// <summary>
        /// Generates and returns an audio stream for the given string.
        /// </summary>
        /// <param name="captchaCode">string to be converted to audio</param>
        /// <returns>MemoryStream of audio</returns>
        public static MemoryStream GenerateAudio(string captchaCode)
        {
            if (captchaCode == null || captchaCode == String.Empty || captchaCode.Trim() == "")
            {
                throw new ArgumentException("Illegal value for captchaCode");
            }
            var audioStream = GetAudio(captchaCode,SPEECHRATE);
            audioStream.Position = 0;
            return audioStream;

        }

        /// <summary>
        /// Generates and returns an audio stream for the given string.
        /// </summary>
        /// <param name="captchaCode">string to be converted to audio</param>
        /// <param name="speechRate">Rate of the speech</param>
        /// <returns>MemoryStream of audio</returns>
        public static MemoryStream GenerateAudio(string captchaCode, int speechRate)
        {
            if (captchaCode == null || captchaCode == String.Empty || captchaCode.Trim() == "")
            {
                throw new ArgumentException("Illegal value for captchaCode");
            }
            if (Math.Abs(speechRate) > 10)
            {
                throw new ArgumentOutOfRangeException("speechRate value should be between -10 to 10");
            }
            var audioStream = GetAudio(captchaCode,speechRate);
            audioStream.Position = 0;
            return audioStream;

        }

        /// <summary>
        /// Generates the Audio. Used internally by other methods.
        /// </summary>
        /// <param name="captchaCode">string to be converted to audio</param>
        /// <param name="speechRate">Rate of the speech</param>
        /// <returns>MemoryStream of audio</returns>
        private static MemoryStream GetAudio(string input,int speechRate)
        {
            MemoryStream audioStream = new MemoryStream();

            var t = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Rate = speechRate;
                synthesizer.SetOutputToWaveStream(audioStream);

                //add a space between all characters to spell it out.
                string val = String.Join<char>(" ", input);
                synthesizer.Speak(val);

            }));

            t.Start();
            t.Join();

            return audioStream;
        }
    }
}
