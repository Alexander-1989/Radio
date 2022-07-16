namespace Radio
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

        internal static bool Contains<T>(this T[] array, T value)
        {
            if (array.IsNullOrEmpty() || value == null)
            {
                throw new System.ArgumentException();
            }
            return System.Array.IndexOf(array, value) > -1;
        }
    }
}