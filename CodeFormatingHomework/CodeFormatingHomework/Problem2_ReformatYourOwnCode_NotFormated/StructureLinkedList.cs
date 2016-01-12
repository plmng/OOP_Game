using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr7
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private class LListNode<T>
        {
            public T Value { get; private set; }
            public LListNode<T> nextNode { get; set; }
            public LListNode(T value)
            {
                this.Value = value;
            }
        }

        private LListNode<T> head;
        private LListNode<T> body;
        public int Count { get; private set; }
        public void Add(T element)
        {
            if (this.head == null)
            {
                this.body = this.head = new LListNode<T>(element);
            }
            else
            {
                this.body.nextNode = new LListNode<T>(element);
                this.body = this.body.nextNode;
            }
            this.Count++;
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var current = this.head;
            for (int i = 0; i < index-1; i++)
            {
                current = current.nextNode;
            }
            current.nextNode = current.nextNode.nextNode;
            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            int index = -1;
            var temp = this.head;
            bool isFound = false;
            do
            {
                if (temp.Value.Equals(item))
                {
                    isFound = true;
                }
                else
                {
                    temp = temp.nextNode;
                }
                index++;
            } while (!isFound);
            return index;
        }

        public int LastIndexOf(T item)
        {
            int lastIndex = this.Count;
            var temp = this.head;
            bool isFound = false;
            do
            {
                for (int i = 0; i < lastIndex -1 ; i++) // 0, 1, 2, 3; last index = 4, lastindex-1 //temp = [0]
                {
                    temp = temp.nextNode; // temp = [1],[2], [3], [4] // last index = 4
                }
                if (temp.Value.Equals(item))
                {
                    isFound = true;
                }
                else
                {
                    temp = this.head;
                }
                lastIndex--; // lastIndex index = 3
            } while (!isFound);

            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.nextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class Example
    {
        static void Main(string[] args)
        {
            LinkedList<int> testList = new LinkedList<int>();
            Console.WriteLine("count = {0}, array = {1}", testList.Count, String.Join(" ", testList));
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(1);
            testList.Add(2);
            Console.WriteLine("count = {0}, array = {1}", testList.Count, String.Join(" ", testList));
            Console.WriteLine("first index of (2): " + testList.FirstIndexOf(2));
            Console.WriteLine("last index of (2): " + testList.LastIndexOf(2));
            testList.Remove(2);
            Console.WriteLine("count = {0}, array = {1}", testList.Count, String.Join(" ", testList));
        }
    }
}
