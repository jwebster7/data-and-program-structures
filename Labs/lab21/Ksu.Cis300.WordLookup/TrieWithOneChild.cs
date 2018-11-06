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
    public class TrieWithOneChild : ITrie
    {
        public ITrie Add(string s)
        {
            if (s == "")
            {
                throw new ArgumentException();
            }

            else
            {
                if (s[0] != _childLabel)
                {
                    return new TrieWithManyChildren(s, _emptyCheck,_childLabel,_onlyChild);
                }
                else
                {
                   _onlyChild = _onlyChild.Add(s.Substring(1));
                    return this;
                }
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
                if (s[0] == _childLabel)
                {
                    return _onlyChild.Contains(s.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Private bool to see if the ITrie we are looking at contains an empty string
        /// </summary>
        private bool _emptyCheck;

        /// <summary>
        /// Private ITrie only child can be any implementation
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// Private char holds the label for the child
        /// </summary>
        private char _childLabel;

        public TrieWithOneChild(string s, bool hasEmpty)
        { 
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _emptyCheck = hasEmpty;
            _childLabel = s[0];
            /*
             * Initialize the ITrie field with the result of constructing a new TrieWithNoChildren and adding to it the substring of the given string following the first character.
            */
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));

        }
    }
}
