using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHeap
{
    public enum HeapType { Max, Min };
    public class Heap<Tkey,Tvalue> 
        where Tkey: IComparable
        where Tvalue:IComparable
    {
        HeapType type;
        HeapNode<Tkey, Tvalue> root;
        Queue<HeapNode<Tkey, Tvalue>> Q;
        public HeapNode<Tkey, Tvalue> Root
        {
            set { root = value; }
            get { return root; }

        }
        public HeapType Type
        {
            set { type = value; }
            get { return type; }
        }

        public Heap(HeapType val)
        {
            Root = null;
            Q = new Queue<HeapNode<Tkey,Tvalue> >();
            Type = val;
        }

        /*public int CompreTo(  Tvalue val1,Tvalue val2)
        {
            
            //return root.Data.CompareTo(val);
        }*/

        public void InsertNode(Tkey key=default(Tkey), Tvalue val=default(Tvalue))
        {
            if (Root == null)
            {
                Root = new HeapNode<Tkey, Tvalue>();
                Root.Data = val;
                Root.Key = key;

                Console.WriteLine("Root {0},{1} has been inserted and parent {2},{3}", Root.Data.ToString(), Root.Key.ToString(), (Root.Parent != null ? Root.Data.ToString() : "NULL"), (Root.Parent != null ? Root.Key.ToString() : "NULL"));

            }

            else
            {
                InsertAtEnd(  key,val);
            }

        }

        private void InsertAtEnd(Tkey key, Tvalue val)
        {
            
            HeapNode<Tkey, Tvalue> leaf = FindLeafToInsertAt(Root);
            if (leaf.Left == null)
            {
                leaf.Left = new HeapNode<Tkey, Tvalue>();
                leaf.Left.Data = val;
                leaf.Left.Key = key;
                leaf.Left.Parent = leaf;
                Console.WriteLine("Node {0},{1} has been inserted at left of parent {2},{3}",leaf.Left.Data.ToString(),leaf.Left.Key.ToString(),(leaf.Left.Parent!=null?leaf.Left.Parent.Data.ToString():"NULL"),(leaf.Left.Parent!=null?leaf.Left.Parent.Key.ToString():"NULL"));
                if (Type == HeapType.Max)
                    ReheapifyMAXUp(leaf.Left);
                else
                    ReheapifyMINUp(leaf.Left);
            }
            else if (leaf.Right == null)
            {
                leaf.Right = new HeapNode<Tkey, Tvalue>();
                leaf.Right.Data = val;
                leaf.Right.Key = key;
                leaf.Right.Parent = leaf;
                Console.WriteLine("Node {0},{1} has been inserted at right of parent {2},{3}", leaf.Right.Data.ToString(), leaf.Right.Key.ToString(), (leaf.Right.Parent !=null ? leaf.Right.Parent.Data.ToString() : "NULL"), (leaf.Right.Parent!=null ? leaf.Right.Parent.Key.ToString() : "NULL"));
                if (Type == HeapType.Max)
                    ReheapifyMAXUp( leaf.Right);
                else
                    ReheapifyMINUp(leaf.Right);
            }
            else
                throw new Exception("Cannot Create new leaf child...");

        }
        public void SwapNodes(HeapNode<Tkey, Tvalue> node1, HeapNode<Tkey, Tvalue> node2)
        {

            HeapNode<Tkey, Tvalue> temp = new HeapNode<Tkey, Tvalue>();

            temp.Key = node1.Key;
            temp.Data = node1.Data;
            node1.Data = node2.Data;
            node1.Key = node2.Key;
            node2.Data = temp.Data;
            node2.Key = temp.Key;

        }

        private  HeapNode<Tkey, Tvalue> FindLeafToInsertAt(HeapNode<Tkey, Tvalue> node)
        {
             HeapNode<Tkey, Tvalue> temp;
            if (node != null)
            {
                Q.Clear();
                Q.Enqueue(node);
                

                while (Q.Count > 0)
                {
                    temp = Q.Dequeue();
                    //Console.Write("  " + temp.Data.ToString() + "  ");
                    if (temp.Left != null)
                    {
                        Q.Enqueue(temp.Left);
                    }
                    /*else
                    {
                        return temp;
                    }*/
                    if (temp.Right != null)
                    {
                        Q.Enqueue(temp.Right);
                    }
                    
                    else if((temp.Left == null || temp.Right == null) )
                    {
                        Q.Clear();
                        return  temp;
                    }


                }

                

            }
            Q.Clear();
            return  null;
        }
        private HeapNode<Tkey, Tvalue> FindLeaf(HeapNode<Tkey, Tvalue> node)
        {
            HeapNode<Tkey, Tvalue> temp;
            if (node != null)
            {
                Q.Clear();
                Q.Enqueue(node);


                while (Q.Count > 0)
                {
                    temp = Q.Dequeue();
                    //Console.Write("  " + temp.Data.ToString() + "  ");
                    if (temp.Left != null)
                    {
                        Q.Enqueue(temp.Left);
                    }
                    /*else
                    {
                        return temp;
                    }*/
                    if (temp.Right != null)
                    {
                        Q.Enqueue(temp.Right);
                    }

                    else if ((temp.Left == null || temp.Right == null) && Q.Count==0)
                    {
                        Q.Clear();
                        return temp;
                    }


                }



            }
            Q.Clear();
            return null;
        }

        private void ReheapifyMAXUp( HeapNode<Tkey, Tvalue> node)
        {
            Console.WriteLine("-ReheapifyMAXUp of Node {0},{1} has been started with  parent {2},{3}", node.Data.ToString(), node.Key.ToString(), (node.Parent != null ? node.Parent.Data.ToString() : "NULL"), (node.Parent != null ? node.Parent.Key.ToString() : "NULL"));

            //Tkey tempkey; Tvalue tempvalue;
            if (node.Parent.Data.CompareTo(node.Data) ==0)
            {
                List<string> lst = new List<string>();
                lst.Add(node.Parent.Key.ToString());
                lst.Add(node.Key.ToString());
                lst.Sort();
                if(lst[1]== node.Data.ToString())
                //tempkey = node.Parent.Key;
                //tempvalue = node.Parent.Data;
                //temp = node.Parent;
                //node.Parent.Data = node.Data;
                //node.Parent.Key = tempkey;

                //node.Data = tempvalue;
                //node.Key = tempkey;
                //node.Parent = temp;
                 SwapNodes(node,node.Parent);


            }
            else
            if (node.Parent.Data.CompareTo(node.Data) < 0)
            {
                /*tempkey = node.Key;
                tempvalue = node.Data;
                node.Data=node.Parent.Data;
                node.Key = node.Parent.Key;
                node.Parent.Data =tempvalue;
                node.Parent.Key = tempkey;*/
                SwapNodes(node, node.Parent);
                Console.WriteLine("--Swap of Node {0},{1} has been started with  parent {2},{3}", node.Data.ToString(), node.Key.ToString(), (node.Parent != null ? node.Parent.Data.ToString() : "NULL"), (node.Parent != null ? node.Parent.Key.ToString() : "NULL"));

            }

            if (node.Parent!=null&& node.Parent.Parent!=null && node.Parent.Data.CompareTo(node.Parent.Parent.Data) > 0)
            {
                //
                ReheapifyMAXUp(node.Parent);
            }


        }
        private void ReheapifyMINUp(HeapNode<Tkey, Tvalue> node)
        {

        }

        public  HeapNode<Tkey, Tvalue> GetHeapTop()
        {
            Console.WriteLine("Root {0},{1} has been returned as \"TOP\"  of HEAP with parent {2},{3}", Root.Data.ToString(), Root.Key.ToString(), (Root.Parent != null ? Root.Parent.Data.ToString() : "NULL"), (Root.Parent != null ? Root.Parent.Key.ToString() : "NULL"));


            if(Root!=null)
            { 
            var temp = FindLeaf(Root);
            var topval = new HeapNode<Tkey, Tvalue>();//Root;
            SwapNodes(topval,Root);
            SwapNodes(temp, Root);
            //Root = temp;
            if (temp.Parent != null && temp.Parent.Right != null )//&& temp.Parent.Left.Data.CompareTo(temp.Data) == 0)
            {
                temp.Parent.Right = null;
            }
            else if (temp.Parent != null && temp.Parent.Left != null)
            {
                temp.Parent.Left = null;
            }
            if (Root == null)
            {
                Console.WriteLine("NULL.........");
            }
            ReheapifyMAXDown(Root);
            return topval;
            }
            return new HeapNode<Tkey, Tvalue>() ;
        }

        private void ReheapifyMAXDown(HeapNode<Tkey, Tvalue> node)
        {//
            if(node.Key!=null)
            Console.WriteLine("-ReheapifyMAXDown Node {0},{1} has been inserted at left of parent {2},{3}", node.Data.ToString(), node.Key.ToString(), (node.Parent != null ? node.Parent.Data.ToString() : "NULL"), (node.Parent != null ? node.Parent.Key.ToString() : "NULL"));
            

            HeapNode< Tkey, Tvalue > temp;
            if ((node.Left!=null && node.Right!=null)&& node.Data.CompareTo(node.Left.Data) > 0 && node.Data.CompareTo(node.Right.Data) > 0)
            {
                return;

            }
            else if((node.Left!=null && node.Right!=null)&& node.Right.Data.CompareTo(node.Left.Data) > 0 )
            {
                SwapNodes(node, node.Right);

                ReheapifyMAXDown(node.Right);

            }
            else if ((node.Left != null && node.Right != null) && node.Right.Data.CompareTo(node.Left.Data) < 0)
            {
                SwapNodes(node, node.Left);

                ReheapifyMAXDown(node.Left);

            }
            else if ((node.Left != null && node.Right != null) && node.Right.Data.CompareTo(node.Left.Data) == 0)
            {
                List<string> ls = new List<string>();
                ls.Add(node.Left.Key.ToString());
                ls.Add(node.Right.Key.ToString());
                ls.Sort();
                if (ls[0] == node.Left.Key.ToString())
                {
                    SwapNodes(node, node.Left);

                    ReheapifyMAXDown(node.Left);
                }
                else
                {
                    SwapNodes(node, node.Right);

                    ReheapifyMAXDown(node.Right);

                }

            }
            else if (node.Left != null && node.Data.CompareTo(node.Left.Data) < 0)
            {

               /* temp = node;
                node= node.Left;
                node.Left = temp;*/
                SwapNodes(node,node.Left);
               
                ReheapifyMAXDown(node.Left);

            }
            else if(node.Right != null &&node.Data.CompareTo(node.Right.Data) < 0)
            {
                /*temp = node;
                node = node.Right;
                node.Right = temp;*/
                SwapNodes(node,node.Right);
                
                ReheapifyMAXDown(node.Right);
            }

            


        }


    }
}
