using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.UserSet
{
    class Set<T> : IEnumerable<T> where T : IComparable
    {
        private readonly List<T> _items = new List<T>();

        public Set()
        {

        }
        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void Add(T item) 
        {
            if(Contais(item))
            {
                throw new InvalidOperationException("Уже есть в множестве");
            }
            _items.Add(item);
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }
        public bool Contais(T item)
        {
            return _items.Contains(item);
        }
        public int Count { get => _items.Count; }

        public Set<T> Union(Set<T> others)
        {
            var left = new Set<T>(_items);
            foreach(var other in others)
            {
                if(!Contais(other))
                {
                    left.Add(other);
                }
            }
            return left;
        }
        public Set<T> Intersection(Set<T> others)
        {
            var result = new Set<T>();
            foreach(var other in others)
            {
                if(Contais(other))
                {
                    result.Add(other);
                }
            }
            return result;
        }

        public Set<T> Difference(Set<T> others)
        {
            var result = new Set<T>(_items);
            foreach(var other in others)
            {
                if(Contais(other))
                {
                    result.Remove(other);
                }
            }
            return result;
        }
        public Set<T> SymmetricDiffernce(Set<T> others)
        {
            var result = new Set<T>(_items);
            foreach(var other in others)
            {
                if (Contais(other))
                    result.Remove(other);
                else result.Add(other);
            }
            return result;
        }

        
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
