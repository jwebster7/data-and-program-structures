/* 
 * Edit: Joe Webster | CIS 300 11:30 - 1:20
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

namespace Ksu.Cis300.ParenthesisMatcher
{
    public partial class uxMatcher : Form
    {
        public uxMatcher()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This button checks the User input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCheck_Click(object sender, EventArgs e)
        {
            Stack<char> _charStack = new Stack<char>();
            string check = uxTextBox.Text;

            foreach (char c in check)
            {
                //is Opening;
                if (IsOpeningParenthesis(c))
                {
                    _charStack.Push(c);
                }

                //is Closing?
                else if (IsClosingParenthesis(c))
                {
                    if (_charStack.Count > 0 && Matches(_charStack.Peek(), c))
                    {
                        _charStack.Pop();
                    }
                    else
                    {
                        ShowError();
                        return;
                    }
                }

                //ignoring all other characters
                else
                {
                    continue;
                }//end if-else

            }//end foreach
            
            // show error or success
            if (_charStack.Count > 0)
            {
                ShowError();
            }
            else if (_charStack.Count == 0)
            {
                ShowSuccess();
            }//end else if

        }//end 

        /// <summary>
        /// Determines whether the given character is an opening parenthesis.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>Whether c is an opening parenthesis.</returns>
        private bool IsOpeningParenthesis(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        /// <summary>
        /// Determines whether the given character is a closing parenthesis.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns>Whether c is a closing parenthesis.</returns>
        private bool IsClosingParenthesis(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        /// <summary>
        /// Determines whether the given characters for a matched pair
        /// of parentheses.
        /// </summary>
        /// <param name="a">The opening character.</param>
        /// <param name="b">The closing character.</param>
        /// <returns>Whether a and b form a matched pair of parentheses.</returns>
        private bool Matches(char a, char b)
        {
            return (a == '(' && b == ')') || (a == '[' && b == ']') ||
                (a == '{' && b == '}');
        }

        /// <summary>
        /// Displays a success message.
        /// </summary>
        private void ShowSuccess()
        {
            MessageBox.Show("The string is matched.");
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        private void ShowError()
        {
            MessageBox.Show("The string is not matched.");
        }


    }//end class
}//end namespace
