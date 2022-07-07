﻿namespace Radio
{
    internal static class Extension
    {
        internal static bool IsEmpty(this System.Windows.Forms.ListBox listBox)
        {
            return !listBox.Items.GetEnumerator().MoveNext();
        }

        internal static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }

        internal static T GetFirst<T>(this T[] array)
        {
            return array.IsNullOrEmpty() ? default : array[0];
        }
    }
}