/* Author: Joe Webster
 * Class: CIS 300 | M W F 11:30-1:20
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.ConnectFour
{
    class GamePiece
    {
        /// <summary>
        /// private char holds the column
        /// </summary>
        private char _column;
        /// <summary>
        /// private piece color holds color enums
        /// </summary>
        private Color _pieceColor;
        /// <summary>
        /// Private int row holds the num of the row
        /// </summary>
        private int _row;

        /// <summary>
        /// Public overloaded constructor
        /// </summary>
        /// <param name="color"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public GamePiece(Color color, int r, char c)
        {
            _pieceColor = color;
            _row = r;
            _column = c;
        }

        /// <summary>
        /// Public property column
        /// </summary>
        public char Column
        {
            get
            {
                return _column;
            }
            set
            {
                _column = value;
            }
        }

        /// <summary>
        /// Public property piececolor
        /// </summary>
        public Color PieceColor
        {
            get
            {
                return _pieceColor;
            }
            set
            {
                _pieceColor = value;
            }
        }

        /// <summary>
        /// public property for Row
        /// </summary>
        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }
    }//end GamePiece class
}
