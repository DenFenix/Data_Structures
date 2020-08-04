using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.UsersLinkedList
{
    internal class LinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; }

        public bool IsReadOnly { get => false; }

        public LinkedListNode<T> Head { get => _head;  }
        public LinkedListNode<T> Tail { get => _tail; }

        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        ///1. Создать экземпляр класса LinkedListNode.
        ///2. Найти последний узел списка.
        ///3. Установить значение поля Next последнего узла списка так, 
        ///чтобы оно указывало на созданный узел.
        public void Add(T value)
        {
            AddLast(value);
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            LinkedListNode<T> temp = _head;
            _head = node;
            _head.Next = temp;
            
            if(Count ==0)
            {
                _tail = _head;
            }
            else
            {
                temp.Previous = _head;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
           
            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            Count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> cur = _head;
            while (cur!=null)
            {
                if (cur.Value.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> cur = _head;
            while (cur != null)
            {
                array[arrayIndex++] = cur.Value;
                cur = cur.Next;
            }
        }

        ///1. Найти узел, который необходимо удалить.
        ///2. Изменить значение поля Next предыдущего узла так,
        ///чтобы оно указывало на узел, следующий за удаляемым.
        public bool Remove(T item)
        {
            LinkedListNode<T> prev = null;
            LinkedListNode<T> cur = _head;
            while(cur!= null)
            {
                if(cur.Value.Equals(item))
                {
                    if(prev != null)
                    {
                        prev.Next = cur.Next;

                        if (cur.Next == null)
                        {
                            _tail = prev;
                        }
                        else
                        {
                            cur.Next.Previous = prev;
                        }

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }

                prev = cur;
                cur = cur.Next;
            }
            return false;
        }

        public bool RemoveFirst()
        {
            if(Count !=0)
            {
                _head = _head.Next;
                Count--;
                if(Count ==0)
                {
                    _tail = null;
                }
                else
                {
                    _head.Previous = null;
                }
                return true;
            }
            return false;
        }

        public bool RemovLast()
        {
            if (Count != 0)
            {
               if(Count ==1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _tail.Previous.Next = null;
                    _tail = _tail.Previous;
                }
                Count--;
                return true;
            }
            return false;
        }


        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> cur = _head;
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
