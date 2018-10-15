using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            SingleLinkedList<int> list=new SingleLinkedList<int>();
            for (int i = 0; i <= 10; i++)
            {
                list.Append(i);
            }

            list.InsertAtBegin(44);
            list.InsertAtIndex(100,3);
            list.PrintList();
            list.BubbleSort();
            list.Reverse();
            list.PrintList();
            Console.WriteLine(list.Search(100).ToString());

            SingleLinkedList<int> list2 = list.CreatRandomintList(10);
            list2.PrintList();
            list2.BubbleSort();
            list2.PrintList();




        }
    }
}
