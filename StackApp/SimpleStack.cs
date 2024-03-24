using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    internal class SimpleStack<T>
    {
        private readonly T[] _items;
        private int _currentIndex = -1;

        public int Count => _currentIndex + 1;
        public SimpleStack()
        {
            _items = new T[10];
        }
        internal void push(T item)
        {
            _items[++_currentIndex] = item;
        }
        public T pop()
        {
            return _items[_currentIndex--];
        }
    }
}
