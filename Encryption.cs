using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Encryption
    {
        public string EncryptionString(string text)
        {
            string[] test = text.RemoveWhitespace().Reverse().Select(s => s.ToString()).ToArray();
            Stack<string> stack = new Stack<string>(test);

            double rank = Math.Sqrt(test.Length);

            var coloumn = Convert.ToInt32(Math.Ceiling(rank));

            var row = Convert.ToInt32(Math.Floor(rank));

            while (!(row * coloumn >= test.Length))
            {
                row += 1;
            }

            string[,] matrix = new string[row, coloumn];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < coloumn; j++)
                {
                    matrix[i, j] = stack.Any() ? stack.Pop() : "";
                }
            }

            for (int i = 0; i < coloumn; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    stack.Push(matrix[j, i]);
                }
                stack.Push(" ");
            }

            StringBuilder sb = new StringBuilder();

            while (stack.Any())
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString().Reverse();
        }
    }
}
