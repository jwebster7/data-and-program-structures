/* UserInterface.cs
 * Author: Rod Howell
 * Edited: Joe Webster
 * 8/25/2017
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
                    string openFile = File.ReadAllText(uxOpenDialog.FileName);
                    uxDisplay.Text = openFile;
                }
                catch (Exception err)
                {
                    ExceptionError(err);
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
                catch (Exception err)
                {
                    ExceptionError(err);
                }
            }
        }
        /// <summary>
        /// This is a private method which displays an error message
        /// </summary>
        /// <param name="message"></param>
        private void ExceptionError(Exception message)
        {
            MessageBox.Show("The following error occured: " + message);
        }
        private void UserInterface_Load(object sender, EventArgs e)
        {

        }
    }
}
