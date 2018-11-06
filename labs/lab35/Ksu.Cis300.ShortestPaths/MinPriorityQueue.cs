/* MinPriorityQueue.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.Sort
{
    /// <summary>
    /// A min-priority queue implemented using a leftist heap.
    /// </summary>
    /// <typeparam name="TPriority">The type of the priorities.</typeparam>
    /// <typeparam name="TValue">The type of the elements.</typeparam>
    public class MinPriorityQueue<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        /// <summary>
        /// A leftist heap storing the elements and their priorities.
        /// </summary>
        private LeftistTree<KeyValuePair<TPriority, TValue>> _elements = null;

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Adds the given element with the given priority.
        /// </summary>
        /// <param name="p">The priority of the element.</param>
        /// <param name="x">The element to add.</param>
        public void Add(TPriority p, TValue x)
        {
            LeftistTree<KeyValuePair<TPriority, TValue>> node =
                new LeftistTree<KeyValuePair<TPriority, TValue>>(new KeyValuePair<TPriority, TValue>(p, x), null, null);
            _elements = Merge(_elements, node);
            _count++;
        }

        /// <summary>
        /// Gets a drawing of the min-heap.
        /// </summary>
        public TreeForm HeapDrawing
        {
            get
            {
                return new TreeForm(_elements, 100);
            }
        }

        /// <summary>
        /// Gets the minimum priority in the queue.
        /// If the queue is empty, throws an InvalidOperationException.
        /// </summary>
        public TPriority MinimumPriority
        {
            get
            {
                if (_count == 0)
                {
                    throw new InvalidOperationException();
                }
                return _elements.Data.Key;
            }
        }

        /// <summary>
        /// Merges the given min-heaps into one.
        /// </summary>
        /// <param name="h1">The first min-heap.</param>
        /// <param name="h2">The second min-heap.</param>
        /// <returns>The result of merging h1 and h2.</returns>
        private static LeftistTree<KeyValuePair<TPriority, TValue>> Merge(LeftistTree<KeyValuePair<TPriority, TValue>> h1,
            LeftistTree<KeyValuePair<TPriority, TValue>> h2)
        {
            if (h1 == null)
            {
                return h2;
            }
            else if (h2 == null)
            {
                return h1;
            }
            else
            {
                LeftistTree<KeyValuePair<TPriority, TValue>> smaller = h1;
                LeftistTree<KeyValuePair<TPriority, TValue>> larger = h2;
                if (h1.Data.Key.CompareTo(h2.Data.Key) > 0)
                {
                    smaller = h2;
                    larger = h1;
                }
                return new LeftistTree<KeyValuePair<TPriority, TValue>>(smaller.Data, smaller.LeftChild, Merge(smaller.RightChild, larger));
            }
        }

        /// <summary>
        /// Removes the element with minimum priority.
        /// </summary>
        /// <returns>The element removed.</returns>
        public TValue RemoveMinimumPriority()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }
            TValue x = _elements.Data.Value;
            _elements = Merge(_elements.LeftChild, _elements.RightChild);
            _count--;
            return x;
        }
    }
}
