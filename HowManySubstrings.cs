using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class HowManySubstrings
    {

        //TODO:OutOfMemoryException hatasına çözüm lazım.
        public int[] CountSubstrings(string text, int[][] queries)
        {
            List<int> sum = new List<int>();


            foreach (var query in queries)
            {
                if (query.Length != 2)
                    throw new ArgumentOutOfRangeException(query.ToString());
                //var sample = Slice(text,query.First(), query.Last());
                sum.Add(GetValues(text, query.First(), query.Last()));
                //sum.Add(CalculateSubStrings(sample, sample.Length));
            }
            return sum.ToArray();
        }

        private int CalculateSubStrings(string s, int n)
        {
            List<string> allPossible = new List<string>();
            for (int i = 0; i < n; i++)
            {
                for (int len = 1; len <= n - i; len++)
                {
                    allPossible.Add(s.Substring( i, len));
                }
            }
            return allPossible.Distinct().Count();
        }

        public static string SubStringCustom(string source,int start, int end)
        {
            return string.Join("", source.Select(s => s.ToString()).Skip(start).Take(end - start));
        }

        public static string Slice(string source, int start, int end)
        {
            return  string.Join( "",source.Select(s=>s.ToString()).Where((x,i)=>i>=start&&i<=end).Select(s=>s));
        }

        public static int GetValues(string source, int start, int end)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var slicedText = source.Select(s => s.ToString()).Where((x, i) => i >= start && i <= end).Select(s => s);

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    var text = string.Join("",
                        source.Select(s => s.ToString()).Where((x, c) => c >= i && c <= j).Select(s => s));
                    if(!string.IsNullOrEmpty(text))
                        dictionary[text] = null;
                }
            }

            return dictionary.Count;
        }
    }
}
