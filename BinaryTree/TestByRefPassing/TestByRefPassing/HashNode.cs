using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestByRefPassing
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

        public void SwapNodes(HashNode<Tkey, Tvalue> node1, HashNode<Tkey, Tvalue> node2)
        {

            HashNode<Tkey, Tvalue> temp = new HashNode<Tkey, Tvalue>(default(Tkey), default(Tvalue));

            temp.Key = node1.Key;
            temp.Value = node1.Value;
            node1.Value = node2.Value;
            node1.Key = node2.Key;
            node2.Value = temp.Value;
            node2.Key = temp.Key;

        }


    }
}
