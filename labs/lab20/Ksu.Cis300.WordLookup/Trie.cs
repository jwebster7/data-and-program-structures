/* Author: Joe Webster
 * Class: CIS 300
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    public class Trie
    {
        /// <summary>
        /// A bool to represent if a string is empty or not
        /// </summary>
        private bool emptyOrNot = false;

        /// <summary>
        /// Private array of type Trie; holds the children from 'a' to 'z'
        /// </summary>
        private Trie[] _children = new Trie[26];

        /// <summary>
        /// Method contains searches for the given string in the Trie array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s.Equals(""))
            {
                //return bool stored in this node
                return emptyOrNot;
            }

            else {
                int location = s[0] - 'a';
            
                if (location < 0 || location >= _children.Length || _children[location] == null)
                {
                    return false;
                }
                else
                {
                    return _children[location].Contains(s.Substring(1));
                }
            }
        }

        /// <summary>
        /// Method adds the given string to the Trie array
        /// </summary>
        /// <param name="s"></param>
        public void Add(string s)
        {
            if(s.Equals(""))
            {
                emptyOrNot = true;
            }

            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }

            else
            {
                int location = s[0] - 'a';
                if(_children[location] == null)
                {
                    _children[location] = new Trie();
                }
                _children[location].Add(s.Substring(1));
            }
        }
    }
}
