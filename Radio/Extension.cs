using System.Collections;
using System.Collections.Generic;

namespace Radio
{
    internal static class Extension
    {
        internal static T[] OfType<T>(this IEnumerable items)
        {
            List<T> result = new List<T>();
            foreach (object item in items)
            {
                if (item is T value)
                {
                    result.Add(value);
                }
            }
            return result.ToArray();
        }

        internal static bool IsEmpty(this IEnumerable items)
        {
            return !items.GetEnumerator().MoveNext();
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
                throw new System.ArgumentNullException();
            }
            return System.Array.IndexOf(array, value) > -1;
        }

        internal static bool ContainsWithoutCase(this string text, string value)
        {
            return text.IndexOf(value, System.StringComparison.OrdinalIgnoreCase) > -1;
        }
    }
}