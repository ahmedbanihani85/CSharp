using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree<int> BT = new BinaryTree<int>();
            Random rnd = new Random();

            for ( int i=0; i<10;i++)
            {
                BT.InsertNode(rnd.Next(1, 100));
            }

            Console.WriteLine("Root Node:" + BT.Root.Data.ToString());

            BT.PreOrderTraverse(BT.Root);
            Console.WriteLine();
            BT.InOrderTraverse(BT.Root);
            Console.WriteLine();
            BT.PostOrderTraverse(BT.Root);
            Console.WriteLine();
            BT.LevelOrderTraverse();
            Console.WriteLine();
        }
    }
}
