/* Board.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Nim
{
    /// <summary>
    /// A representation of a Nim board.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The number of stones on each pile.
        /// </summary>
        private int[] _piles;

        /// <summary>
        /// The limit for each pile.
        /// </summary>
        private int[] _limits;

        /// <summary>
        /// This board's hash code.
        /// </summary>
        private int _hashCode;

        /// <summary>
        /// Indicates whether this board's hash code has been computed.
        /// </summary>
        private bool _hashCodeIsComputed;

        /// <summary>
        /// Gets the number of piles.
        /// </summary>
        public int NumberOfPiles
        {
            get
            {
                return _piles.Length;
            }
        }

        /// <summary>
        /// Gets the number of stones on the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The number of stones on the given pile.</returns>
        public int GetValue(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _piles[pile];
        }

        /// <summary>
        /// Gets the limit for the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The limit for the given pile.</returns>
        public int GetLimit(int pile)
        {
            if (pile < 0 || pile >= _piles.Length)
            {
                throw new ArgumentException();
            }
            return _limits[pile];
        }

        /// <summary>
        /// Constructs a board with the given number of stones and limit for each pile.
        /// If the given arrays have different lengths, throws an ArgumentException.
        /// </summary>
        /// <param name="piles">The number of stones on each pile.</param>
        /// <param name="limits">The limit for each pile.</param>
        public Board(int[] piles, int[] limits)
        {
            if (piles.Length != limits.Length)
            {
                throw new ArgumentException();
            }
            _piles = new int[piles.Length];
            piles.CopyTo(_piles, 0);
            _limits = new int[limits.Length];
            limits.CopyTo(_limits, 0);
        }

        /// <summary>
        /// Compares the given boards for equality.
        /// </summary>
        /// <param name="x">One board.</param>
        /// <param name="y">The other board.</param>
        /// <returns>Whether the two boards represent the same game position.</returns>
        public static bool operator ==(Board x, Board y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x._piles.Length == y._piles.Length)
                {
                    for (int i = 0; i < x._piles.Length; i++)
                    {
                        if (x._piles[i] != y._piles[i] || x._limits[i] != y._limits[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Compares the given boards for inequality.
        /// </summary>
        /// <param name="x">One board.</param>
        /// <param name="y">The other board.</param>
        /// <returns>Whether the two boards represent different game positions.</returns>
        public static bool operator !=(Board x, Board y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Compares this board with the given object for equality.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>Whether obj is a Board representing the same game position as this board.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Board)
            {
                return this == (Board)obj;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the result of making the given play from this board position.
        /// </summary>
        /// <param name="p">The play to make.</param>
        /// <returns>The resulting board position.</returns>
        public Board MakePlay(Play p)
        {
            if (p.Pile > _piles.Length || p.Number > _limits[p.Pile])
            {
                throw new ArgumentException();
            }
            Board b = new Board(_piles, _limits);
            b._piles[p.Pile] -= p.Number;
            b._limits[p.Pile] = Math.Min(b._piles[p.Pile], 2 * p.Number);
            return b;
        }

        /// <summary>
        /// Gets this board's hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            if (!_hashCodeIsComputed)
            {
                _hashCode = _piles.Length;
                for (int i = 0; i < _piles.Length; i++)
                {
                    unchecked
                    {
                        _hashCode *= 37;
                        _hashCode += _piles[i];
                        _hashCode *= 37;
                        _hashCode += _limits[i];
                    }
                }
                _hashCodeIsComputed = true;
            }
            return _hashCode;
        }
    }
}
