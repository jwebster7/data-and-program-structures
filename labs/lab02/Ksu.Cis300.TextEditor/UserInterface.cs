/* Joseph Webster
 * Instructor: Dr. Josh Weese
 * Date: 8/23/2017
 * CIS 300 Lab 2
 * <summary>
 *  This Solution is a very basic text editor with
 *  no capability to save or open files
 * </summary>
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

namespace Ksu.Cis300.TextEditor
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This constructor opens a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenButton_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                String filename = uxOpenDialog.FileName;
                MessageBox.Show(filename + " cannot be opened!");
                // do things with the file
            }
            //otherwise do nothing
        }

        private void uxSaveDialog_FileOk(object sender, CancelEventArgs e)
        {
 
        }

        /// <summary>
        /// This constructer saves a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAsButton_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                String filename = uxSaveDialog.FileName;
                MessageBox.Show(filename + " cannot be saved!");
                // do things with the file
            }
            //otherwise do nothing
        }
    }
}
