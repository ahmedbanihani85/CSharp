using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHeap
{
    public class Solution
    {



        private List<string> topKwords;
        private Dictionary<string, int> wordshash;

        public Solution()
        {

            topKwords = new List<string>();
            wordshash = new Dictionary<string, int>();
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {

            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (!wordshash.ContainsKey(words[i]))
                {
                    wordshash.Add(words[i], 1);

                }
                else
                {

                    count = (int)wordshash[words[i]];

                    wordshash[words[i]] = ++count;

                }

            }

            List<string> temp = new List<string>();

          //wordshash = wordshash.OrderByDescending(e => e.Value).ThenByDescending(e => e.Key).ToDictionary (;
            //var sortedwordhash = from entry in wordshash orderby entry.Value descending, entry.Key ascending select entry;
          foreach(var entry in wordshash.OrderByDescending(e=>e.Value).ThenBy(e=>e.Key))
          {

              temp.Add(entry.Key);
          }
            //temp=wordshash.Keys.ToList();
           //temp= temp.OrderBy(e=>e).ToList();// = from s in temp orderby s.ToString() select s;

          //  Heap<string, int> h = new Heap<string, int>(HeapType.Max);


            int val;
            /*for (int z=0; z< temp.Count; z++)
            {
                val = wordshash[temp[z]];
                h.InsertNode(temp[z], val);

                // Process key/value pair here
            }

            int x = temp.Count - 1;
            HeapNode<string, int> top;
            for (int j = 0; j < k; j++)
            {
                top = h.GetHeapTop();
                topKwords.Add(top.Key);
                x--;

            }*/
            int x = temp.Count - 1;
            for (int j = 0; j < k; j++)
            {
               
                topKwords.Add(temp[j]);
                x--;

            }

            //topKwords = topKwords.OrderBy(e => e).ToList();
            return topKwords;//topKwords;  

        }
    }
}
