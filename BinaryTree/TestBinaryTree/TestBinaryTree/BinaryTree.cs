using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinaryTree
{
    class BinaryTree<T>
    {
        private TreeNode<T> root;
        private int nodecount;
        public TreeNode<T> Root { set { root = value; } get { return root; } }
        public int NodeCount { set { nodecount = value; } get { return nodecount; } }
        private string PrintSpaces;
        private Queue<TreeNode<T>> Q;
        public BinaryTree(T val)
        {
            root = new TreeNode<T>(val);

        }

        public BinaryTree()
        {
            root = null;
            PrintSpaces = new string(' ', 10);
            Q = new Queue<TreeNode<T>>();

        }


        public void InsertNode(T val)
        {
           
            if (root == null)
            {
                root = new TreeNode<T>(val);

            }
            else

            {
                TreeNode<T> current = Root;
                InsertNode( val,  current);
            }

        }

        

        private void InsertLeft(T val, TreeNode<T>  current)
        {
            
            if (current.Left == null)
            {
                current.Left = new TreeNode<T>(val);
            }
            else
            {
                InsertNode(val,   current.Left);
            }
           

        }
        private void InsertRight(T val,  TreeNode<T> current)
        {
            

            if (current.Right == null)
            {
                current.Right = new TreeNode<T>(val);
            }
            else
            {
                InsertNode(val,  current.Right);
            }


        }

        private void InsertNode(T val,   TreeNode<T>  current)
        {
            if (int.Parse(current.Data.ToString()) > int.Parse(val.ToString()))
            {
                InsertLeft(val, current);

            }
            else if (int.Parse(current.Data.ToString()) < int.Parse(val.ToString()))
            {
                InsertRight(val, current);

            }
            else if (int.Parse(current.Data.ToString()) == int.Parse(val.ToString()))
            {
                Console.WriteLine("This given value {0} is already exist in the Tree...", val.ToString());
            }
            else
            {
                throw new Exception("Null node has been detected. Incorrect insertion operation!");
            }

        }


        public void PreOrderTraverse(TreeNode<T> node, int level=0)
        {
            if(node!=null)
            {
                /*  for (int i=0;i<=level;i++)
                  { Console.Write(" "); }*/
                //Console.WriteLine();
                
                Console.Write("  " + node.Data.ToString() + "  ");
                level++;

                PreOrderTraverse(node.Left, level);

                PreOrderTraverse(node.Right, level);
                
          // 
            }
           // else
             //   Console.WriteLine();

        }


        public void InOrderTraverse(TreeNode<T> node, int level = 0)
        {
            if (node != null)
            {
                /*  for (int i=0;i<=level;i++)
                  { Console.Write(" "); }*/
                //Console.WriteLine();



                InOrderTraverse(node.Left, level);
                Console.Write("  " + node.Data.ToString() + "  ");
                //level++;

                InOrderTraverse(node.Right, level);

                // 
            }
            //else
               // Console.WriteLine();

        }

        public void PostOrderTraverse(TreeNode<T> node, int level = 0)
        {
            if (node != null)
            {
                /*  for (int i=0;i<=level;i++)
                  { Console.Write(" "); }*/
                //Console.WriteLine();



                PostOrderTraverse(node.Left, level);
                
                //level++;

                PostOrderTraverse(node.Right, level);
                Console.Write("  " + node.Data.ToString() + "  ");

                // 
            }
            //else
              //  Console.WriteLine();

        }

        public void LevelOrderTraverse( )
        {
            int level = 0;
            if (root != null)
            {

                Q.Enqueu(root);
                TreeNode<T> temp;

                while (Q.ListLength > 0)
                {
                    temp = Q.Dequeu();
                    Console.Write(  "  "+temp.Data.ToString()+"  ");
                    if (temp.Left != null)
                        Q.Enqueu(temp.Left);
                    if (temp.Right != null)
                        Q.Enqueu(temp.Right);



                }


                
            }
           

        }

    }
}
