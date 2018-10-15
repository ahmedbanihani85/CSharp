using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestByRefPassing
{
    class SeparateChainingHash <Tkey, Tvalue>
         where Tkey : IComparable
         where Tvalue : IComparable
    {
        private HashNode<Tkey, Tvalue> start;

        public  HashNode<Tkey, Tvalue> Start
        {
            set { start = value; }
            get { return start; }
        }


    }
}
