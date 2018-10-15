using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinkedList
{
    class SingleLinkedList<T>
    {
        protected Node<T> head;
        protected int Length;

        public int ListLength { get { return Length; } }

        public SingleLinkedList()
        {
            head = null;//= new Node<T>();
            Length = 0;
        }

        public void Append(T val)
        {
            if (head== null && Length == 0)
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
                current = null;
                Length++;
            }
        }

        public void InsertAtBegin(T val)
        {
           // Node<T> current = head;
            Node<T> node = new Node<T>(val);
            node.Next = head;
            head = node;

        }
        
        public void InsertAtIndex(T val, int index)
        {
            if((index >= 0 ) &&  (index < Length))
                {

                Node<T> current = head;
                for (int i = 0; i < index-1; i++)
                {
                    current = current.Next;
                }

                if (current.Next == null)
                {
                    current.Next = new Node<T>(val);
                }
                else
                {
                    Node<T> node = new Node<T>(val);
                    node.Next = current.Next;
                    current.Next = node;
                }

                }
            else
            {

                throw new IndexOutOfRangeException("The index you provided is out of the list range...");

            }
        }

        public void InsertAtBeforeValue(T val_to_insert, T val_to_insert_before)
        {

        }
        public void InsertAtAfterValue(T val_to_insert, T val_to_insert_after)
        { }



        public int Search(T val)
        {

            Node<T> current = head;
            int index=0;
            while (current.Next != null)
            {

                if (current.Data.ToString() == val.ToString())
                    return index;

                index++;
                current = current.Next;

            }

            return -1;

        }

        public virtual void BubbleSort()
        {

            Node<T> end, prev, next;

            T temp;

           // prev = head.Next;
           // next = head.Next.Next;
            end = null;
            while (end != head.Next)
            {
                prev = head;
                next = head.Next;
                while (next!=end)
                {

                    if (int.Parse(prev.Data.ToString()) > int.Parse(next.Data.ToString()))
                    { 
                        temp = prev.Data;
                        prev.Data = next.Data;
                        next.Data = temp;
                    }
                    next = next.Next;
                    prev=prev.Next;

                }
                end = prev;
               // this.PrintList();
            }

           

        }

        public void Reverse()
        {
            Node<T> end, prev, next;

            
            next = head.Next;
            end = next.Next;
            prev = head;
            prev.Next = null;
            while (end != null)
            {
                //prev.Next = null;
                next.Next = prev;
                prev = next;
                next = end;
                end = end.Next;
                


            }

            head = prev;


            }

        public void DeleteAtBegin()
        {
            Node<T> current = head;
            head.Next = current.Next;
            

        }
        public void DeleteAtEnd()
        { }
        public void DeleteAtVal()
        { }

        public SingleLinkedList<int> CreatRandomintList(int size)
        { 
             SingleLinkedList<int>  List=new SingleLinkedList<int>();
            Random rnd=new Random ();

            for(int i=1;i<=size;i++)
            {
            List.Append(rnd.Next(1,1000));
            }

            return  List;
        
        }
        public void PrintList()
        {
            Node<T> current = head;
            int i = 1;
            while (current.Next != null)
            {
                Console.WriteLine("Element {0}={1}",i,current.Data.ToString());
                i++;
                current = current.Next;
            }

            Console.WriteLine(new string('*',20));
        }


    }
}
