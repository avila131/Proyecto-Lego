using System;
using System.Diagnostics;

namespace lego2
{
    public class LinkedList<T>
    {
        public Node<T> head { get; set; }
        public Node<T> tail { get; set; }

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public bool isEmpty()
        {
            return (head == null);
        }

        public void pushBack(ref T givenKey)
        {
            Node<T> newNode = new Node<T>(givenKey);
            if (head == null) // Empty list
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = tail.next;
            }
        }

        public void pushFront(T givenKey)
        {
            Node<T> newNode = new Node<T>(givenKey);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode.next = null;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }

        public T topFront()
        {
            return head.key;
        }

        public T popBack()
        {
            
            try
            {
                if (head.next == null)
                {
                    head = null;
                    tail = null;
                }
                Node<T> iteratorPointer = head;
                while (iteratorPointer.next.next != null)
                    iteratorPointer = iteratorPointer.next;
                iteratorPointer.next = null;
                T returnValue = tail.key;
                tail = iteratorPointer;

                return returnValue;
            }
            catch (Exception)
            { throw new Exception("List is empty"); }
        }
        public T popFront()
        {
           try
            {
                T returnValue = head.key;
                head = head.next;
                return returnValue;
            }
           catch (Exception)
               { throw new Exception("List is empty"); }
        }

    }
}
