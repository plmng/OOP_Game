namespace Problem2_ReformatYourOwnCode_ReFormatedd
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Represents a custom implementation of the Tail data structure (Linked List).
    /// Provides methods to add element, remove element and serch the first and last index of the element by value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private CustomListNode<T> _head;
        private CustomListNode<T> _body;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this._head == null)
            {
                this._body = this._head = new CustomListNode<T>(element);
            }
            else
            {
                this._body.NextNode = new CustomListNode<T>(element);
                this._body = this._body.NextNode;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = this._head;
            for (var i = 0; i < index - 1; i++)
            {
                current = current.NextNode;
            }

            current.NextNode = current.NextNode.NextNode;
            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            var index = -1;
            var temp = this._head;
            var isFound = false;
            do
            {
                if (temp.Value.Equals(item))
                {
                    isFound = true;
                }
                else
                {
                    temp = temp.NextNode;
                }

                index++;
            } 
            while (!isFound);
            return index;
        }

        public int LastIndexOf(T item)
        {
            var lastIndex = this.Count;
            var temp = this._head;
            var isFound = false;
            do
            {
                for (var i = 0; i < lastIndex - 1; i++)
                {
                    temp = temp.NextNode;
                }

                if (temp.Value.Equals(item))
                {
                    isFound = true;
                }
                else
                {
                    temp = this._head;
                }

                lastIndex--;
            } 
            while (!isFound);
            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this._head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
