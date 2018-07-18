using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class TheGridSearch
    {
        public string TwoDimensionPattern(string[] grids, string[] patterns)
        {
            List<SearchModel> search = new List<SearchModel>();

            for (int i = 0; i < patterns.Length; i++)
            {
                for (int j = 0; j < grids.Length; j++)
                {
                    var occurs = GetIndexes(grids[j], patterns[i]);
                    search.Add(new SearchModel
                    {
                        GridIndex = j,
                        Occurs = occurs,
                        PatternIndex = i
                    });
                }
            }

            search.RemoveAll(x => x.Occurs.Count == 0);

            var orderList = search.GroupBy(x => new { x.GridIndex, x.PatternIndex }).Select(s => s.Last())
                .OrderBy(x => x.PatternIndex).ThenBy(x => x.GridIndex).ToList();


            var templst = orderList.Where(x => x.PatternIndex == 0).OrderBy(x => x.GridIndex).ToList();
            int groupIndex;
            var lastOrder = new List<SearchModel>();
            foreach (var temp in templst)
            {
                groupIndex = temp.GridIndex;
                lastOrder.Add(temp);
                groupIndex += 1;
                for (int i = 1; i < patterns.Length; i++)
                {
                    var exist = orderList.FirstOrDefault(x => x.PatternIndex == i && x.GridIndex == groupIndex);
                    if (exist == null)
                    {
                        lastOrder = new List<SearchModel>();
                        break;
                    }

                    lastOrder.Add(exist);
                    groupIndex += 1;
                }

                if (lastOrder.Count == patterns.Length)
                    break;
            }

            bool allHaveSameValue = false;



            if (lastOrder.Count == patterns.Length)
            {
                var occurs = lastOrder.Select(s => s.Occurs).ToList();
                var firstOccur = occurs.First();

                foreach (var index in firstOccur)
                {

                    for (int i = 1; i < occurs.Count; i++)
                    {
                        if (!occurs[i].Any(x => x == index))
                        {
                            allHaveSameValue = false;
                            break;
                        }

                        allHaveSameValue = true;
                    }

                    if (allHaveSameValue)
                        break;
                }
            }


            return allHaveSameValue?"YES":"NO";
        }


        private static List<int> GetIndexes(string searchText, string pattenr)
        {
            List<int> indexes = new List<int>();
            int index = 0;
            while (index != -1)
            {
                index = searchText.IndexOf(pattenr, index, StringComparison.Ordinal);
                if (index == -1)
                    break;

                indexes.Add(index);
                index = index + 1;
            }
            return indexes;
        }
    }

    class SearchModel
    {
        public int PatternIndex { get; set; }
        public int GridIndex { get; set; }
        public List<int> Occurs { get; set; }
    }
}
