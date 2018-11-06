/* UserInterface.cs
 * Author: Rod Howell
 * Edited: Joe Webster
 * CIS 300 Lab 4 08/28/17
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
using System.IO;

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A GUI for a simple text editor.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the Open menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxDisplay.Text = File.ReadAllText(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the Save As menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAs_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveDialog.FileName, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    DisplayErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Displays the given exception as an error message.
        /// </summary>
        /// <param name="e">The exception to be displayed.</param>
        private void DisplayErrorMessage(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e);
        }

        /// <summary>
        /// Rotates the given character c n positions through the alphabet whose first
        /// letter is firstLetter and whose number of letters is alphabetLen. alphabetLen
        /// must be positive.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="n">The number of positions to rotate c.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <param name="alphabetLen">The number of letters in the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private static char Rotate(char c, int n, char firstLetter, int alphabetLen)
        {
            return (char)(firstLetter + (c - firstLetter + n) % alphabetLen);
        }

        /// <summary>
        /// This method checks to see if the char is capital or lowercase and 
        /// calls the "Rotate" method in each respective case
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private char encrypt(char c)
        {
            char temp = c;
            if (c >= 'a' && c <= 'z')
            {
                temp = Rotate(c, 13, 'a', 26);
            }

            else if (c >= 'A' && c <= 'Z')
            {
               temp = Rotate(c, 13, 'A', 26);
            }

            else
            {
                temp = c;
            }
            return temp;
        }

        /// <summary>
        /// Event handler for the "With String" box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxWithString_Click(object sender, EventArgs e)
        {
            string textBox = uxDisplay.Text;
            string resultString = "";
            char temp;
            for (int i = 0; i < textBox.Length; i++)
            {
                temp = encrypt(textBox[i]);
                resultString += temp;
            }

            uxDisplay.Text = resultString;
        }

        /// <summary>
        /// Event handler for the "With StringBuilder" box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void uxStringBuilder_Click(object sender, EventArgs e)
        {
            string textBox = uxDisplay.Text;
            StringBuilder sb = new StringBuilder();
            char temp;

            for (int i = 0; i < textBox.Length; i++)
            {
                temp = encrypt(textBox[i]);
                sb.Append(temp); 
            }

            uxDisplay.Text = sb.ToString();
        }
    }
}
