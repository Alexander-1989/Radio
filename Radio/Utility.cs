using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radio.Utilities
{
    class Utility
    {
        private static readonly Random random = new Random();

        public static Image GetScreen(Form form)
        {
            Image image = new Bitmap(form.Width, form.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CopyFromScreen(form.Location, new Point(0, 0), image.Size);
            }
            return image;
        }

        public static string GetRandomName()
        {
            return GetRandomName(4, 20, null);
        }

        public static string GetRandomName(string extension)
        {
            return GetRandomName(4, 20, extension);
        }

        public static string GetRandomName(int minLength, int maxLength)
        {
            return GetRandomName(minLength, maxLength, null);
        }

        public static string GetRandomName(int minLength, int maxLength, string extension)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int lengthLine = random.Next(minLength, maxLength);
            int lengthExtension = extension?.Length ?? 0;
            char[] result = new char[lengthLine + lengthExtension];

            for (int i = 0; i < lengthLine; i++)
            {
                result[i] = alphabet[random.Next(alphabet.Length)];
            }

            for (int j = 0; j < lengthExtension; j++)
            {
                result[lengthLine + j] = extension[j];
            }

            return new string(result);
        }
    }
}