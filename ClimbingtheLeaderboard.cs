using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ClimbingtheLeaderboard
    {
        public List<int> AliceRanks(int[] scores, int[] aliceScores)
        {
            var aliceRank = new List<int>();
            scores = scores.Distinct().ToArray();

            int i = scores.Length - 1;

            foreach (var aliceScore in aliceScores)
            {
                while ((i >= 0))
                {
                    if ((aliceScore >= scores[i]))
                    {
                        i--;
                    }
                    else
                    {
                        aliceRank.Add((i + 2));
                        break;
                    }

                }
                if (i < 0) aliceRank.Add(1);
            }

            return aliceRank;
        }
    }
}
