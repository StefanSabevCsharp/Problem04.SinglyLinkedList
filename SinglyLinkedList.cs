namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node head;
        private class Node
        {
            public Node(T item)
            {
                this.Value = item;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (this.Count == 0)
            {
                this.head = new Node(item);
            }
            else
            {
                Node newNode = new Node(item);
                newNode.Next = this.head;
                this.head = newNode;

            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            if (this.Count == 0)
            {
                this.head = new Node(item);
            }
            else
            {
                Node newNode = new Node(item);
                Node current = this.head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            this.Count++;
        }



        public T GetFirst()
        {
            CheckValidOperation();
            return this.head.Value;
        }

        public T GetLast()
        {
            CheckValidOperation();
            Node current = this.head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public T RemoveFirst()
        {
            CheckValidOperation();
            T firstElement = this.head.Value;
            this.head = this.head.Next;
            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            CheckValidOperation();
            Node current = this.head;
            Node previous = null;

            if(current.Next == null)
            {
                T element = current.Value;
                this.head = null;
                this.Count--;
                return element;
            }
            while(current.Next != null)
            {
                
                if(current.Next.Next == null)
                {
                    previous = current;
                }

                current = current.Next;
            }
            
            T lastElement = current.Value;
            previous.Next = null;
            this.Count--;
            return lastElement;

        }

        private void CheckValidOperation()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}