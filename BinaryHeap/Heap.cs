﻿
using System.Collections;

namespace BinaryHeap
{
    internal class Heap : IEnumerable
    {
        private readonly List<int> _items = new();
        public int Count => _items.Count;

        public int? Peek() => Count > 0 ? _items[0] : null;

        public Heap(List<int> items)
        {
            _items.AddRange(items);

            for (int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }

        public void Add(int item)
        {
            _items.Add(item);

            var currentIndex = Count - 1;
            var parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && (_items[parentIndex] < _items[currentIndex]))
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public int GetMax()
        {
            var result = _items[0];
            _items[0] = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        private void Sort(int currentIndex)
        {
            int maxIndex = currentIndex;
            int leftIndex, rightIndex;
            
            while (currentIndex < Count)
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;

                if (leftIndex < Count && _items[leftIndex] > _items[maxIndex])
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < Count && _items[rightIndex] > _items[maxIndex])
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == currentIndex)
                    break;

                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        private static int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private void Swap(int currentIndex, int parentIndex) => (_items[currentIndex], _items[parentIndex]) = (_items[parentIndex], _items[currentIndex]);

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return GetMax();
            }
        }
    }
}
