using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHeap
{
    public class HeapNode<Tkey, Tvalue>
        where Tkey : IComparable
        where Tvalue : IComparable
    {
        private HeapNode<Tkey, Tvalue> parent;
        private HeapNode<Tkey, Tvalue> left;
        private HeapNode<Tkey, Tvalue> right;
        private Tvalue data;
        private Tkey key;
        public HeapNode<Tkey, Tvalue> Parent
        {
            set { parent = value; }
            get { return parent; }
        }

        public HeapNode<Tkey, Tvalue> Left
        {
            set { left = value; }
            get { return left; }
        }

        public HeapNode<Tkey, Tvalue> Right
        {
            set { right = value; }
            get { return right; }
        }

        public Tvalue Data
        {
            set { data = value; }
            get { return data; }
        }
        public Tkey Key
        {
            set { key = value; }
            get { return key; }
        }
        public HeapNode()
        {

            Parent = null;
            Left = null;
            Right = null;
            Data = default(Tvalue);
            Key = default(Tkey);

        }

        public int CompreTo(Tvalue val)
        {

            return this.Data.CompareTo(val);
        }

    }
}
