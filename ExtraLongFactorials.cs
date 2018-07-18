using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ExtraLongFactorials
    {
        public string GetBigIntegerFactorial(int numberOfFactorial)
        {
            string multiplicand = "1";

            for (int i = 1; i < numberOfFactorial + 1; i++)
            {
                multiplicand = MultipyTwoString(i.ToString(), multiplicand);
            }
            return multiplicand;
        }


        private string MultipyTwoString(string multiplier, string multiplicand)
        {
            multiplicand = Reverse(multiplicand);
            var sumLists = new List<string>();
            var tempList = new List<string>();

            for (int i = 0; i < multiplier.Length; i++)
            {
                tempList.AddRange(Enumerable.Repeat("0", multiplier.Length - 1 - i));
                var carryOut = 0;
                for (int j = 0; j < multiplicand.Length; j++)
                {
                    var multipy = Convert.ToInt32(multiplier[i].ToString()) * Convert.ToInt32(multiplicand[j].ToString()) + carryOut;
                    tempList.Add((multipy % 10).ToString());
                    carryOut = multipy / 10;
                }
                if (carryOut > 0)
                {
                    tempList.Add(carryOut.ToString());
                }
                tempList.Reverse();
                sumLists.Add(string.Join("", tempList));
                tempList = new List<string>();
            }

            return SumStrings(sumLists);
        }


        private string SumStrings(List<string> sumStrings)
        {
            var maxLength = sumStrings.Max(x => x.Length);
            var modifiedList = sumStrings.Select(s => s.PadLeft(maxLength, '0')).Select(Reverse);
            int carryOut = 0;
            List<string> result = new List<string>();
            for (int i = 0; i < maxLength; i++)
            {
                List<int> temp = modifiedList.Select(s => Convert.ToInt32(s[i].ToString())).ToList();
                var sum = temp.Sum() + carryOut;
                result.Add((sum % 10).ToString());
                carryOut = sum / 10;
            }

            if (carryOut > 0)
            {
                result.Add(carryOut.ToString());
            }

            result.Reverse();
            return string.Join("", result);
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
