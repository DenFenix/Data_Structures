using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.UsersLinkedList
{
    class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; internal set; }

        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Previous { get; internal set; }
    }
}
