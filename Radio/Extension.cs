using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Radio.Utilities;

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

        internal static bool IsNullOrEmpty(this IEnumerable items)
        {
            return items == null || !items.GetEnumerator().MoveNext();
        }

        internal static T GetFirst<T>(this IEnumerable<T> items)
        {
            IEnumerator<T> enumerator = items?.GetEnumerator();
            return enumerator != null && enumerator.MoveNext() ? enumerator.Current : default;
        }

        internal static bool Contains<T>(this T[] array, T value)
        {
            return array.IsNullOrEmpty() || value == null ? throw new ArgumentNullException() : Array.IndexOf(array, value) > -1;
        }

        internal static bool ContainsWithoutCase(this string text, string value)
        {
            return text.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1;
        }

        internal static Service.Validator GetValidator(this Control control)
        {
            return new Service.Validator(control);
        }
    }
}