/* Author: Joe Webster
 * Date: 11/3/2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.Nim
{
    class Dictionary <TKey, TValue>
    {
        /// <summary>
        /// Field which stores the hashTable
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>[] _hashTable = new LinkedListCell<KeyValuePair<TKey, TValue>>[3209];

        /// <summary>
        /// Checks if the key is empty; throws exception if so
        /// </summary>
        /// <param name="k"></param>
        private void CheckKey(TKey k)
        {
            if (k == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Gets the location of TKey k and removes it using masking
        /// </summary>
        /// <param name="k">key we're looking for</param>
        /// <returns></returns>
        private int GetLocation(TKey k)
        {
            return (k.GetHashCode() & 0x7fffffff) % _hashTable.Length;
        }

        /// <summary>
        /// This gets the cell which is contains a Key equivalent to k
        /// </summary>
        /// <param name="k">Key we're looking for</param>
        /// <param name="list">Cell we are using to search for k</param>
        /// <returns></returns>
        private LinkedListCell<KeyValuePair<TKey, TValue>> GetCell(TKey k, LinkedListCell<KeyValuePair<TKey, TValue>> list)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> pointer = list;
            while (pointer != null)
            {
                if (pointer.Data.Key.Equals(k))
                {
                    return pointer;
                }
                pointer = pointer.Next;
            }
            return null;
        }

        /// <summary>
        /// Inserts given cell into _hashTable at location
        /// </summary>
        /// <param name="cell">Cell to insert</param>
        /// <param name="loc">Given location</param>
        private void Insert(LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _hashTable[loc];
            _hashTable[loc] = cell;
        }

        /// <summary>
        /// Helper method for insert
        /// </summary>
        /// <param name="k">key</param>
        /// <param name="v">value</param>
        /// <param name="loc">location</param>
        private void Insert(TKey k, TValue v, int loc)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = new LinkedListCell<KeyValuePair<TKey, TValue>>();
            KeyValuePair<TKey, TValue> keyPair = new KeyValuePair<TKey, TValue>(k, v);
            cell.Data = keyPair;
            Insert(cell, loc);
        }

        /// <summary>
        /// Attempts to find the value
        /// </summary>
        /// <param name="k">key to pass into GetCell</param>
        /// <param name="v">Value to *out*</param>
        /// <returns></returns>
        public bool TryGetValue(TKey k, out TValue v)
        {
            CheckKey(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = GetCell(k, _hashTable[GetLocation(k)]);
            if (cell == null)
            {
                v = default(TValue);
                return false;
            }
            else
            {
                v = cell.Data.Value;
                return true;
            }
        }

        /// <summary>
        /// Adds keys and values
        /// </summary>
        /// <param name="k">key to add</param>
        /// <param name="v">values to add</param>
        public void Add(TKey k, TValue v)
        {
            int index = k.GetHashCode();
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = GetCell(k, _hashTable[GetLocation(k)]);
            if (cell == null)
            {
                Insert(k, v, GetLocation(k));
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
