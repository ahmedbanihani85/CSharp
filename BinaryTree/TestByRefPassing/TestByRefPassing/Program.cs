using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestByRefPassing
{

    class Program
    {


       
        public static void Main(string[] args)
        {
            HashNode<string, int> node1=new HashNode<string,int>("Node1",10);
            HashNode<string, int> node2=new HashNode<string, int>("Node2",20);

            HashNode<string, int> obj = new HashNode<string, int>("Farah",0);
            obj.SwapNodes(node1, node2);
            Console.WriteLine("Node1:{0},{1}",node1.Key,node1.Value.ToString());

            Console.WriteLine("Node2:{0},{1}", node2.Key, node2.Value.ToString());
        }
    }
}
