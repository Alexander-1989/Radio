﻿using System.Text;
using System.Runtime.InteropServices;

namespace System.IO
{
    class INIFile
    {
        private readonly string _FileName = null;
        private const string _name = "Config.ini";

        public INIFile()
        {
            _FileName = Path.Combine(Environment.CurrentDirectory, _name);
        }

        public INIFile(string fileName)
        {
            _FileName = Path.GetFullPath(fileName);
        }

        public bool FileExists
        {
            get
			{
				return File.Exists(_FileName);
			}
        }

        public void Write<T>(string Section, string Key, T Value) where T : IConvertible
        {
            if (Section == null)
            {
                throw new ArgumentNullException("Section");
            }

            if (Key == null)
            {
                throw new ArgumentNullException("Key");
            }

            if (Value == null)
            {
                throw new ArgumentNullException("Value");
            }

            SafeNativeMethods.WritePrivateProfileString(Section, Key, Value.ToString(), _FileName);
        }

        public string Read(string Section, string Key)
        {
            if (Section == null)
            {
                throw new ArgumentNullException("Section");
            }
            if (Key == null)
            {
                throw new ArgumentNullException("Key");
            }
            StringBuilder result = new StringBuilder(255);
            SafeNativeMethods.GetPrivateProfileString(Section, Key, null, result, result.Capacity, _FileName);
            return result.ToString();
        }

        public int Parse(string Section, string Key)
        {
            int.TryParse(Read(Section, Key), out int result);
            return result;
        }

        public T Parse<T>(string Section, string Key) where T : struct, IConvertible
        {
            try
            {
                if (typeof(T).IsEnum)
                {
                    return (T)Enum.Parse(typeof(T), Read(Section, Key), true);
                }
                else
                {
                    return (T)Convert.ChangeType(Read(Section, Key), typeof(T));
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        public string[] GetSections()
        {
            char[] result = new char[255];
            SafeNativeMethods.GetPrivateProfileString(null, null, null, result, result.Length, _FileName);
            return new string(result).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void DeleteSection(string Section)
        {
            SafeNativeMethods.WritePrivateProfileString(Section, null, null, _FileName);
        }

        public bool SectionExists(string Section)
        {
            char[] res = new char[255];
            SafeNativeMethods.GetPrivateProfileString(null, null, null, res, res.Length, _FileName);
            return new string(res).Contains(Section);
        }

        public string[] GetKeys(string Section)
        {
            char[] result = new char[255];
            SafeNativeMethods.GetPrivateProfileString(Section, null, null, result, result.Length, _FileName);
            return new string(result).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void DeleteKey(string Section, string Key)
        {
            SafeNativeMethods.WritePrivateProfileString(Section, Key, null, _FileName);
        }

        public bool KeyExists(string Section, string Key)
        {
            char[] res = new char[255];
            SafeNativeMethods.GetPrivateProfileString(Section, null, null, res, res.Length, _FileName);
            return new string(res).Contains(Key);
        }

        private static class SafeNativeMethods
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WritePrivateProfileString")]
            internal static extern int WritePrivateProfileString(string Section, string Key, string Value, string FileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileString")]
            internal static extern int GetPrivateProfileString(string Section, string Key, string Default, char[] Result, int Size, string FileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileString")]
            internal static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder Result, int Size, string FileName);
        }
    }
}