/* UserInterface.cs
 * Author: Rod Howell
 * Edit: Joe Webster
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
    /// <summary>
    /// A GUI for a program to look up name information in census data.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information on all the names.
        /// </summary>
        private List<NameInformation> _names = new List<NameInformation>();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the given file into a lined list.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A linked list containing the information from the file.</returns>
        private List<NameInformation> ReadFile(string fn)
        {
            List<NameInformation> list = new List<NameInformation>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    list.Add(new NameInformation(name, freq, rank));
                }
                return list;
            }
        }

        /// <summary>
        /// Handles a Click event on the "Open Data File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadFile(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Get Statistics" button; performs binary search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            int start = 0;//keep track of the first index in  the search space; not [0] 
            int end = _names.Count;//keep track of the index PAST the search space; [n-1]
            int midpoint;//store the midpoint

            while ((end - start) > 0)
            {
                //Finding the midpoint
                midpoint = (start + end) / 2;
                //Finding the name
                int numName = _names[midpoint].Name.CompareTo(name);
                //Is the midpoint inside the range of SearchSpace?
                if (numName < 0)
                {
                    start = midpoint + 1;
                }
                else if (numName > 0)
                {
                    end = midpoint;
                }
                else
                {
                    //correct
                    uxFrequency.Text = _names[midpoint].Frequency.ToString();
                    uxRank.Text = _names[midpoint].Rank.ToString();
                    return;
                }
            }//end while

            MessageBox.Show("Name not found.");
            uxFrequency.Text = "";
            uxRank.Text = "";
        }
    }
}
