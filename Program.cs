using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {

            //ExtraLongFactorials extraLongFactorials = new ExtraLongFactorials();
            //Console.WriteLine(extraLongFactorials.GetBigIntegerFactorial(1000));

            //ClimbingtheLeaderboard climbingtheLeaderboard = new ClimbingtheLeaderboard();
            //climbingtheLeaderboard.AliceRanks(new []{100,100,50,40,40,20,10},new []{2,25,50,120}).ForEach(Console.WriteLine);

            //TheGridSearch theGridSearch = new TheGridSearch();
            //theGridSearch.TwoDimensionPattern(new[]{"111111","111111","111131","212211"},new[] { "11","11", "21" });

            Encryption encryption = new Encryption();
            Console.WriteLine(encryption.EncryptionString("if man was meant to stay on the ground god would have given us roots"));
            

            Console.ReadLine();
        }

        public static string RemoveWhitespace( string str)
        {
            return String.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public static string Reverse( string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
