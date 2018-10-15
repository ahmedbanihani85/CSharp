using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinaryTree
{
    class TreeNode<T>
    {
        private T data;
        private TreeNode<T> left;
        private TreeNode<T> right;
        //private T val;

        public T Data { set { data = value; } get { return data; } }

        public TreeNode<T> Left { set { left = value; } get { return left; } }

        public TreeNode<T> Right { set { right = value; } get { return right; } }

        public TreeNode(T val = default(T))
        {
            Data = val;
            Left = null;
            Right = null;
        }

       

    }
}
