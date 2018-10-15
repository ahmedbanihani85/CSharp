using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBinaryTree
{
    class Queue<T>
    {

        private Node<T> head;
        private int Length;
        public int ListLength { get { return Length; } }

        public Queue()
        {
            head = null;
            Length = 0;
        }


        public void Enqueu(T val)
        {
            Append(val);
        }

        public T Dequeu()
        {
            return DeleteAtBegin();
        }

        public T CheckTop()
        {

            return head.Data;

        }
        private void Append(T val)
        {
            if (head == null && Length == 0)
            {
                head = new Node<T>(val);
                //head.Next.Next = new Node<T>(val);
                Length++;
            }

            else
            {

                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new Node<T>(val);
                //current = null;
                Length++;
            }
        }

        private T DeleteAtBegin()
        {

            if (head != null && Length>0)
            {
                Node<T> current = head;
                head = head.Next;
                Length--;
                return current.Data;
            }
            return default(T);


        }

    }
}
