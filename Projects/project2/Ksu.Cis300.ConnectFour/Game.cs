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
    class Game
    {
        /// <summary>
        /// Private players turn initializes players turn
        /// </summary>
        private PlayersTurn _turn = PlayersTurn.Red; //should be initialized to Red's turn
        /// <summary>
        /// Public const int keeps the columns the same size
        /// </summary>
        public const int ColumnSize = 6;
        /// <summary>
        /// Public readonly playerscolors 
        /// </summary>
        public readonly Color[] PlayerColors = { Color.Red, Color.Black };//Should contain Color.Red & Color.Black
        /// <summary>
        /// Private dllc _columns
        /// </summary>
        private DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> _columns = null;//Keep track of doubly linked
        /// <summary>
        /// Private dllc _column
        /// </summary>
        private DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> _column = null;

        /// <summary>
        /// public property dllc columns 
        /// </summary>
        public DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }

        /// <summary>
        /// Public property dllc 
        /// </summary>
        public DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> Column
        {
            get
            {
                return _column;
            }
        }

        /// <summary>
        /// Property for PlayersTurn enum. Gets and sets private field _turn
        /// </summary>
        public PlayersTurn Turn
        {
            get
            {
                return _turn;
            }
            set
            {
                _turn = value;
            }
        }

        /// <summary>
        /// Nested type enumerator with 2 references "Red" and "Black"
        /// </summary>
        public enum PlayersTurn
        {
            Red,
            Black
        }

        /// <summary>
        /// Private method Check checks if the next cell is okay for data
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowDirection"></param>
        /// <param name="colDirection"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool Check(int row, char col, int rowDirection, int colDirection, Color color)
        {
            int count = 1;
            bool hasReversed = false;

            //to check if there are 4 in a row using findcell
            while (count < 5)
            {
                row += rowDirection;
                col = (char)(colDirection + col);

                DoubleLinkedListCell<GamePiece> nextCell;
                if(row < 1 || col < 65 || row > ColumnSize || col > 'G')
                {
                    nextCell = null;
                }
                else
                {
                    nextCell = FindCell((col.ToString() + row));
                }

                if (nextCell != null  && color == nextCell.Data.PieceColor)
                {
                    count++;
                }
                else
                {
                    if (hasReversed)
                    {
                        return false;
                    }
                    else
                    {
                        hasReversed = true;
                        count = 1;
                        rowDirection *= -1;
                        colDirection *= -1;
                    }
                }//end else
            }//while
            return true;
        }//end Check

        /// <summary>
        /// Checkwin is the method which will state if there is a winner or not
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public bool CheckWin(DoubleLinkedListCell<GamePiece> cell)
        {
            bool won = false;
            if (Check(cell.Data.Row, cell.Data.Column, 0, -1, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, 0, 1, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, 1, -1, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, 1, 0, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, 1, 1, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, -1, -1, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, -1, 0, cell.Data.PieceColor)) won = true;
            if (Check(cell.Data.Row, cell.Data.Column, -1, 1, cell.Data.PieceColor)) won = true;
            return won;
        }//end CheckWin

        /// <summary>
        /// Findcell finds the cell which we drop a gamepiece into
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DoubleLinkedListCell<GamePiece> FindCell(string id)
        {
            FindColumn(id);
            if (_column == null || _column.Data == null) return null;
            DoubleLinkedListCell<GamePiece> tempCell = _column.Data;
            while(tempCell.Id[1] != id[1])
            {
                tempCell = tempCell.Next;
                if (tempCell == null) return null;
            }
            return tempCell;
        }//end FindCell

        /// <summary>
        /// Method FindColumn finds the column of a gamepiece
        /// </summary>
        /// <param name="columnID"></param>
        public void FindColumn(string columnID)
        {
            char column = columnID[0];
            if (column.CompareTo('G') > 0)
            {
                _column = null;
                return;
            }
            char colLetter = columnID[0];
            DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> tempCell = _columns;
            while (tempCell.Id[0] != colLetter)
            {
                tempCell = tempCell.Next;
            }
            _column = tempCell;
        }//end FindColumn
    }//end Game
}
