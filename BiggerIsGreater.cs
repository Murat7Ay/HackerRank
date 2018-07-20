using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class BiggerIsGreater
    {
        //geeksforgeeks.org
        private static List<string> _mutations = new List<string>();
        public string GetNextBigger(string str)
        {
            char[] arr = str.ToCharArray();
            GetPer(arr);

            string nextBigger = _mutations.OrderBy(x => x).SkipWhile(x => x != str).ElementAt(1);

            var res = str == nextBigger ? "no answer" : nextBigger;

            _mutations = new List<string>();
            return res;
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                _mutations.Add(new string(list));
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

       
    }
}
