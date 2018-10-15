using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQueue
{

    
    class Node<T>
    {
        private T data;
        private Node<T> next;
        public T Data  {
            set {

               /* if (value != null)*/ data = value;/* else throw new Exception("User input error...");*/
                }

            get {
                    return data;
                }

        }
        public Node<T> Next { set { next = value; } get { return next; } }

        public Node(T data = default(T) )
        {
            Data = data;
            Next = null;
        }

        


    }
}
