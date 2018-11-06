/* Author: Joe Webster
 * Date: 10/24/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.BTrees
{
    class BTree<TKey, TValue> : ITree
            where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Field for the size of the BTree
        /// </summary>
        private int _size;

        /// <summary>
        /// Field for the max children of the BTree
        /// </summary>
        private int _maxChildren;

        /// <summary>
        /// Field for the minimum keys of the BTree
        /// </summary>
        private int _minKeys;

        /// <summary>
        /// Field for the maximum keys of the BTree
        /// </summary>
        private int _maxKeys;

        /// <summary>
        /// Instantiation of a BTreeNode to become the root
        /// </summary>
        private BTreeNode<TKey, TValue> _root;

        /// <summary>
        /// Constructs objects of type BTree
        /// </summary>
        /// <param name="size">Used for initializing all fields</param>
        public BTree(int size)
        {
            if (size < 2)
            {
                throw new InvalidOperationException();
            }
            _size = size;
            _maxChildren = size * 2;
            _minKeys = size - 1;
            _maxKeys = (size * 2) - 1;//size * 2 - 1
            _root = new BTreeNode<TKey, TValue>(_minKeys, _maxKeys, _maxChildren, true);
        }

        /// <summary>
        /// Property for checking if _root is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (_root.IsEmpty)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Property for getting the children of _root
        /// </summary>
        public ITree[] Children
        {
            get
            {
                return _root.Children;
            }
        }

        public object Root
        {
            get
            {
                return _root;
            }
        }

        /// <summary>
        /// Builds and replaces _root with a new Root, or inserts a nonfull node int0 _root
        /// </summary>
        /// <param name="key">Used for constructing a new BTreeNode</param>
        /// <param name="value">Used for constructing a new BTreeNode</param>
        public void Insert(TKey key, TValue value)
        {
            if (_root.IsEmpty)
            {
                _root.AddItem(key, value);
            }
            else
            {
                if (_root.KeyCount != _maxKeys)
                {
                    _root.InsertNonFull(key, value);
                }
                else
                {
                    BTreeNode<TKey, TValue> newRoot = new BTreeNode<TKey, TValue>(_minKeys, _maxKeys, _maxChildren, false);
                    newRoot.AddChild(0, _root);
                    newRoot.SplitChild(0);
                    newRoot.InsertNonFull(key, value);
                    _root = newRoot;
                }
            }
        }

        /// <summary>
        /// Helper function which calls Find on _root
        /// </summary>
        /// <param name="key">Key to pass into _root.Find()</param>
        /// <returns></returns>
        public TValue Find(TKey key)
        {
            return _root.Find(key);
        }
    }
}
