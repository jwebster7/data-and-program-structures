/* TrieWithOneChild.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.WordLookup
{
    /// <summary>
    /// A trie node with exactly one child.
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// This node's only child.
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// The child's label.
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// Constructs a trie containing the given nonempty string and perhaps the empty string.
        /// If the given string is empty or contains characters that are not lower-case English
        /// letters, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The nonempty string.</param>
        /// <param name="hasEmpty">Indicates whether the empty string should be added.</param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _childLabel = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }
        
        /// <summary>
        /// Builds the result of adding the given string to this trie. This trie may
        /// or may not be modified.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] == _childLabel)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
            }
        }

        /// <summary>
        /// Determines whether this trie contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether this trie contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _childLabel)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
