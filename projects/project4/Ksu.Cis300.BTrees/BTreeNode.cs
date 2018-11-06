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
    class BTreeNode<TKey, TValue>: ITree 
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Keeps track of how many keys are currently in "this" node
        /// </summary>
        private int _keyCount;
        
        /// <summary>
        /// Stores the minimum # of keys "this" node can have
        /// </summary>
        private int _minKeyCount;

        /// <summary>
        /// Holds the keys of "this" node in ascending order
        /// </summary>
        private TKey[] _keys;

        /// <summary>
        /// Keeps track of the # of children in this node
        /// </summary>
        private int _childCount;

        /// <summary>
        /// Stores the pointer to the children of "this" node
        /// </summary>
        private BTreeNode<TKey, TValue>[] _children;

        /// <summary>
        /// Stores the values of the corresponding kes from the _keys array
        /// </summary>
        private TValue[] _values;

        /// <summary>
        /// Indicates if this node is a leaf or not
        /// </summary>
        private bool _isLeaf;

        /// <summary>
        /// Gets the _keyCount value
        /// </summary>
        public int KeyCount
        {
            get
            {
                return this._keyCount;
            }
        }

        /// <summary>
        /// Returns if the # of keys in "this" node is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (_keyCount == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Property returning "this" node
        /// </summary>
        public object Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Returns Itree[] "_children"
        /// </summary>
        public ITree[] Children
        {
            get
            {
                return (ITree[])(_children);
            }
        }

        /// <summary>
        /// Constructor for the BTreeNode class
        /// </summary>
        /// <param name="minKeyCount">Initializes the _minKeyCount field</param>
        /// <param name="maxKeyCount">Initializes the _keyCount field</param>
        /// <param name="maxChildCount">Initializes the _childCount field</param>
        /// <param name="leaf">Initializes the _isLeaf field</param>
        public BTreeNode(int minKeyCount, int maxKeyCount, int maxChildCount, bool leaf)
        {
            _minKeyCount = minKeyCount;
            _childCount = maxChildCount;
            _children = new BTreeNode<TKey, TValue>[maxChildCount];
            _isLeaf = leaf;
            _keys = new TKey[maxKeyCount];
            _values = new TValue[maxKeyCount];
            //_keyCount = maxKeyCount;
        }

        /// <summary>
        /// Adds an item to the private fields "_keys" and "_values"
        /// </summary>
        /// <param name="key">Used for (eventually) creating a BTreeNode</param>
        /// <param name="value">User for (eventually) creating a BTreeNode</param>
        public void AddItem(TKey key, TValue value)
        {
            for (int i = _keyCount - 1; i >= 0; i--)
            {
                int compare = _keys[i].CompareTo(key);
                //if "key" is larger than "_keys[i]"
                if (compare <= 0)
                {
                    _keys[i + 1] = key;
                    _values[i + 1] = value;
                    _keyCount++;
                    return;
                }
                //if "key" is equal to "_keys[i]"
                else
                {
                    _keys[i + 1] = _keys[i];
                    _values[i + 1] = _values[i];
                }
            }
            _keys[0] = key;
            _values[0] = value;
            _keyCount++;
        }

        /// <summary>
        /// Adds "child" at index "i" to "_children"; increments number of children (_childCount)
        /// </summary>
        /// <param name="i">The index used for adding a child</param>
        /// <param name="child">the node values inserted into _childrens[]</param>
        public void AddChild(int i, BTreeNode<TKey, TValue> child)
        {
            _children[i] = child;
            _childCount++;
        }

        /// <summary>
        /// Splits the tree 
        /// </summary>
        /// <param name="index">The int we will use to split the arrays to make a split node</param>
        public void SplitChild(int index)
        {
            BTreeNode<TKey, TValue> splitNode = _children[index];
            BTreeNode<TKey, TValue> newNode = new BTreeNode<TKey, TValue>(_minKeyCount, _keys.Length, _children.Length, splitNode._isLeaf);

            //Spliting the node 
            for (int i = 0,  k = i + _minKeyCount + 1; i < _minKeyCount; i++, k++)
            {
                newNode.AddItem(splitNode._keys[k], splitNode._values[k]);
                splitNode._keys[k] = default(TKey);
                splitNode._values[k] = default(TValue);
            }

            //moving the larger keys to the new node
            if (!newNode._isLeaf)
            {
                for (int i = splitNode._children.Length / 2, j = 0; i < splitNode._children.Length; i++, j++)
                {
                    if (splitNode._children[i] != null)
                    {
                        newNode.AddChild(j, splitNode._children[i]);
                        splitNode._children[i] = null;
                        splitNode._childCount--;
                    }
                }
            }

            //Updating the key count 
            splitNode._keyCount = _minKeyCount;

            //Shift them child nodes 
            for (int i = _keyCount; i >= index + 1; i--)
            {
                _children[i + 1] = _children[i];
            }

            //Putting the new node into the children array
            _children[index + 1] = newNode;

            //Adds the middle of the splitnode into "this" node
            AddItem(splitNode._keys[_minKeyCount], splitNode._values[_minKeyCount]);

            //Removes the values we just added to "this" node
            splitNode._keys[_minKeyCount] = default(TKey);
            splitNode._values[_minKeyCount] = default(TValue);
        }

        /// <summary>
        /// Insterts a node who is not full already
        /// </summary>
        /// <param name="key">key is the TKey we will use for inserting a nonfull node</param>
        /// <param name="value">value is the value we will insert into a nonfull node</param>
        public void InsertNonFull(TKey key, TValue value)
        {
            if (_isLeaf)
            {
                AddItem(key, value);
            }
            else
            {
                int k = _keyCount - 1;
                while (k >= 0 && _keys[k].CompareTo(key) > 0)
                {
                    k--;
                }
                k++;
                if (_children[k]._keyCount == _keys.Length)
                {
                    SplitChild(k);
                    if (_keys[k].CompareTo(key) < 0)
                    {
                        k++;
                    }
                }
                _children[k].InsertNonFull(key, value);
            }
        }

        /// <summary>
        /// Finds the given TKey in the _values array
        /// </summary>
        /// <param name="key">Key is the value we will search for</param>
        /// <returns></returns>
        public TValue Find(TKey key)
        {
            int i = Array.IndexOf(_keys, key);
            if (i > -1)
            {
                return _values[i];
            }
            else if (_isLeaf)
            {
                return default(TValue);
            }

            int count = 0;
            while (count < _keyCount && _keys[count].CompareTo(key) < 0)
            {
                count++;
            }
            return _children[count].Find(key);
        }

        /// <summary>
        /// Overrides the ToString method and builds _keys[index] with "|" to a String Builder
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            TKey[] tempArray = new TKey[_keyCount];
            for (int i = 0; i < _keyCount; i++)
            {
                tempArray[i] = _keys[i];
            }

            string printThisArray = string.Join("|", tempArray);
            return printThisArray;
        }
    }
}
