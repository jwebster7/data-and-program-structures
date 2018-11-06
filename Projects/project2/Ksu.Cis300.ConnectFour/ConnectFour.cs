/* Author: Joe Webster | CIS 300
 * Date: 9.28.2017
 * Homework 2
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.ConnectFour
{
    public partial class ConnectFour : Form
    {
        /// <summary>
        /// Gives UI class access to all aspects of Game class
        /// </summary>
        private Game _game = new Game();

        /// <summary>
        /// private int discount keeps track of how many moves back
        /// </summary>
        private int _disCount = 0;

        /// <summary>
        /// Public connectfour builds the buttons
        /// </summary>
        public ConnectFour()
        {
            DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> cell = null;
            InitializeComponent();
            uxTurnLabel.BackColor = Color.Red;
            uxTurnLabel.Text = "Red";
            for (char i = 'A'; i < 'H'; i++)
            {
                Button b = new Button();
                b.Text = i.ToString();
                b.Width = 45;
                b.Height = 20;
                b.Margin = new System.Windows.Forms.Padding(5);
                b.Click += new System.EventHandler(uxPlaceButtonClick);
                uxPlaceButtonC.Controls.Add(b);

                DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> tempCell = new DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>>(b.Text);
                if (cell != null)
                {
                    cell.Next = tempCell;
                    tempCell.Prev = cell;
                    cell = cell.Next;
                }
                else
                {
                    cell = tempCell;
                    _game.Columns = tempCell;
                }
                //inner loop
                for (int size = Game.ColumnSize; size > 0; size--)
                {
                    Label l = new Label();
                    l.Width = 45;
                    l.Height = 45;
                    l.Margin = new System.Windows.Forms.Padding(5);
                    l.BackColor = Color.White;
                    l.Text = "";
                    l.Name = b.Text + size;
                    uxBoardContainer.Controls.Add(l);
                }
            }
        }

        /// <summary>
        /// Set color sets the color of the label which holds the cell 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        public void SetColor(string id, Color color)
        {
            Control[] cont = uxBoardContainer.Controls.Find(id, true);
            cont[0].BackColor = color;
        }

        /// <summary>
        /// uxPlaceButtonClick places the buttons places the buttons which holds the cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPlaceButtonClick(object sender, EventArgs e)
        {
            string button = ((Button)sender).Text;
            _game.FindColumn(button);
            Color c = _game.PlayerColors[(int)_game.Turn];
            DoubleLinkedListCell<DoubleLinkedListCell<GamePiece>> head = _game.Column;
            DoubleLinkedListCell<GamePiece> temp = head.Data;

            int count = 1;
            if (temp == null)
            {
                temp = new DoubleLinkedListCell<GamePiece>(button + "1");
                temp.Data = new GamePiece(c, 1, button[0]);
                head.Data = temp;
                //draw
            }

            else
            {
                while(temp.Next != null)
                {
                    temp = temp.Next;
                    count++;
                }
                temp.Next = new DoubleLinkedListCell<GamePiece>(button + (count+1).ToString());
                temp.Next.Data = new GamePiece(c, count + 1, button[0]);
                temp = temp.Next;
                count++;
            }

            SetColor(button + (count).ToString(), c);

            if (count == Game.ColumnSize)
            {
                ((Button)sender).Enabled = false;
                _disCount++;
            }

            if (_game.CheckWin(temp))
            {
                MessageBox.Show(_game.Turn.ToString() + " Wins!");
                Environment.Exit(0);
            }

            else if (_disCount == 7)
            {
                MessageBox.Show("Draw!");
                Environment.Exit(0);
            }

            if (_game.Turn == Game.PlayersTurn.Red)
            {
                _game.Turn = Game.PlayersTurn.Black;
                uxTurnLabel.BackColor = Color.Black;
                uxTurnLabel.ForeColor = Color.White;
                uxTurnLabel.Text = "Black";
            }
            else
            {
                _game.Turn = Game.PlayersTurn.Red;
                uxTurnLabel.BackColor = Color.Red;
                uxTurnLabel.ForeColor = Color.Black;
                uxTurnLabel.Text = "Red";
            }

        }
    }//end ConnectFour
}
