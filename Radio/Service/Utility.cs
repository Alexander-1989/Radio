using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Radio.Utilities
{
    class Utility
    {
        private static readonly Random _random = new Random();

        public static Image GetScreen(Form form)
        {
            Image image = new Bitmap(form.Width, form.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CopyFromScreen(form.Location, new Point(0, 0), image.Size);
            }
            return image;
        }

        public static List<RadioStation> ReadStationsFromTxtFile(string fileName)
        {
            List<RadioStation> stations = new List<RadioStation>();
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        int id = 1;
                        string prefix = "http";

                        while (!reader.EndOfStream)
                        {
                            int startIndex = 0;
                            int endIndex = -1;
                            string line = reader.ReadLine();

                            if (!string.IsNullOrEmpty(line) &&
                                line[0] != '#' &&
                                line[0] != ';' &&
                                (endIndex = line.IndexOf(prefix)) > -1)
                            {
                                string name = line.Substring(startIndex, endIndex - 1).Trim();
                                startIndex = endIndex;
                                endIndex = line.IndexOf(' ', startIndex);
                                string url = endIndex < startIndex ? line.Substring(startIndex) : line.Substring(startIndex, endIndex - startIndex);

                                stations.Add(new RadioStation(name, url, id++));
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
            return stations;
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
            int lengthLine = _random.Next(minLength, maxLength);
            int lengthExtension = extension?.Length ?? 0;
            char[] result = new char[lengthLine + lengthExtension];

            for (int i = 0; i < lengthLine; i++)
            {
                int index = _random.Next(alphabet.Length);
                result[i] = alphabet[index];
            }

            for (int j = 0; j < lengthExtension; j++)
            {
                result[lengthLine + j] = extension[j];
            }

            return new string(result);
        }
    }
}