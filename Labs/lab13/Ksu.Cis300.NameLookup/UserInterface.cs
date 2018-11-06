/* Author: Joe Webster
 * Class: CIS 300
 * Instructor: Dr. Weese
 * Section: 11:30 M W F
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

namespace Ksu.Cis300.NameLookup
{
    public partial class UserInterface : Form
    {
        private LinkedListCell<NameInformation> _nameInfo = null;
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method Reads all lines of a file, seperates the lines out into 
        /// "name", "freq", "rank" and stores them into the LinkedListCell returned
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        private LinkedListCell<NameInformation> ReadFile(string fn)
        {   
            using (StreamReader sr = new StreamReader(fn))
            {
                LinkedListCell<NameInformation> nameInfo = null;
                while (!sr.EndOfStream)
                {
                    string name = sr.ReadLine().Trim();
                    float freq = Convert.ToSingle(sr.ReadLine());
                    int rank = Convert.ToInt32(sr.ReadLine());
                    LinkedListCell<NameInformation> tempCell = new LinkedListCell<NameInformation>();
                    tempCell.Data = new NameInformation(name, freq, rank);
                    tempCell.Next = nameInfo;
                    nameInfo = tempCell;
                }//end while
                return nameInfo;
            }
        }

        /// <summary>
        /// Opens file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fn = uxOpenDialog.FileName;
                    _nameInfo = ReadFile(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occured: " + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Get Stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            LinkedListCell<NameInformation> pointer = _nameInfo;

            while (pointer != null)
            {
                if (name.Equals(pointer.Data.Name))
                {
                    uxFrequency.Text = pointer.Data.Frequency.ToString();
                    uxRank.Text = pointer.Data.Rank.ToString();
                    return;
                }
                else
                {
                    pointer = pointer.Next;
                }
            }
            MessageBox.Show("Name not found");
            uxFrequency.Text = "";
            uxRank.Text = "";
        }
    }


}
