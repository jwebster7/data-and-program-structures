/*
 * Author: Joe Webster
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Bool to check if the string is stored int teh Trie rooted at a node
        /// </summary>
        private bool _emptyCheck;

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyCheck = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _emptyCheck);
            }
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _emptyCheck;
            }
            else
            {
                return false;
            }
        }
    }
}
