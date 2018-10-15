using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHeap
{
    class HashNode<Tkey, Tvalue>
         where Tkey : IComparable
        where Tvalue : IComparable
    {
        private Tkey key;
        private Tvalue value;

        public Tkey Key
        {
            set { key = value; }
            get { return key; }
        }

        public Tvalue Value
        {
            set { this.value = value; }
            get { return this.value; }
        }

        public HashNode(Tkey key, Tvalue val)
        {
            this.Key = key;
            this.Value = val;
        }

    }
}
