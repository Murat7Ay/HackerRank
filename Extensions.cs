using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public static class Extensions
    {

        //public static IEnumerable<int> AllIndexesOf(this string str, string value)
        //{
        //    if (String.IsNullOrEmpty(value))
        //        throw new ArgumentException("the string to find may not be empty", nameof(value));
        //    for (int index = 0; ; index += value.Length)
        //    {
        //        index = str.IndexOf(value, index, StringComparison.Ordinal);
        //        if (index == -1)
        //            break;
        //        yield return index;
        //    }
        //}

        public static string RemoveWhitespace(this string str)
        {
            return String.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
                index--;
            }
        }
    }
}
