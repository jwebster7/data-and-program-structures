/* Author: Joe Webster
 * Date: 10/20/2017
 * Class: CIS 300
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.Sort
{
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
        /// Gets the minimum priority key
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
        /// Merges leftist heaps into one
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
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
                LeftistTree<KeyValuePair<TPriority, TValue>> bigger = h2;
                LeftistTree<KeyValuePair<TPriority, TValue>> smaller = h1;
                int comparison = h1.Data.Key.CompareTo(h2.Data.Key);
                //if h1 key is less than h2 key
                if (comparison > 0)
                {
                    bigger = h1;
                    smaller = h2;
                }

                return new LeftistTree<KeyValuePair<TPriority, TValue>>(smaller.Data, smaller.LeftChild, Merge(smaller.RightChild, bigger));
            }
        }

        /// <summary>
        /// Removes the Minimum Key
        /// </summary>
        /// <returns></returns>
        public TValue RemoveMinimumPriority()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }
            TValue tempValue = _elements.Data.Value;
            _elements = Merge(_elements.LeftChild, _elements.RightChild);
            _count--;
            return tempValue;
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
    }
}
