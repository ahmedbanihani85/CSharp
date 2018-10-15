using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHeap
{
    class Program
    {
        static void Main(string[] args)
        {

            //Heap<string,int> H = new Heap<string,int>(HeapType.Max);
            //H.InsertNode("A1",10);
            //H.InsertNode("A2",10);
            //H.InsertNode("A3",30);
            //Random rnd = new Random();
            //int temp;
            //for (int i = 0; i < 3; i++)
            //{
            //    temp = rnd.Next(1, 100);
            //    H.InsertNode("N" + i.ToString(), temp);
            //    //Console.Write(temp.ToString());
            //}
            //HeapNode<string, int> x = H.GetHeapTop();
            //Console.WriteLine("\n Heap Top: {0},{1}" ,x.Key,x.Data.ToString() );
            //x = H.GetHeapTop();
            //Console.WriteLine("\n Heap Top: {0},{1}", x.Key, x.Data.ToString());
            //x = H.GetHeapTop();
            //Console.WriteLine("\n Heap Top: {0},{1}", x.Key, x.Data.ToString());
            //x = H.GetHeapTop();
            //Console.WriteLine("\n Heap Top: {0},{1}", x.Key, x.Data.ToString());
            //x = H.GetHeapTop();
            //Console.WriteLine("\n Heap Top: {0},{1}", x.Key, x.Data.ToString());
            //x = H.GetHeapTop();
            //Console.WriteLine("\n Heap Top: {0},{1}", x.Key, x.Data.ToString());

            Solution s = new Solution();
           // string[] words = { "i", "love", "leetcode", "i", "love", "coding" };
            //string[] words = { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            string[] words = { "a", "aa", "aaa" };
           IList<string> r= s.TopKFrequent(words,2);
        }
    }
}
