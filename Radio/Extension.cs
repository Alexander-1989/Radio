using System.Collections.Generic;
using System.Windows.Forms;

namespace Radio
{
    internal static class Extension
    {
        internal static bool IsEmpty(this ListBox listBox)
        {
            return !listBox.Items.GetEnumerator().MoveNext();
        }

        internal static bool IsNullOrEmpty<T>(this T[] array)
        {
            return array == null || array.Length == 0;
        }
    }
}