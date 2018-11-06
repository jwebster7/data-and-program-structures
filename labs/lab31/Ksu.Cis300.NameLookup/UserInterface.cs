/* UserInterface.cs
 * Author: Rod Howell
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
using Ksu.Cis300.ImmutableBinaryTrees;
using KansasStateUniversity.TreeViewer2;

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
        private Dictionary<string, NameInformation> _names = new Dictionary<string, NameInformation>();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the given file into a dictionary.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A dictionary containing the information from the file.</returns>
        private Dictionary<string, NameInformation> ReadFile(string fn)
        {
            Dictionary<string, NameInformation> t = new Dictionary<string, NameInformation>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    t.Add(name, new NameInformation(name, freq, rank));
                }
                return t;
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
        /// Handles a Click event on the "Get Statistics" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            NameInformation info;
            if (_names.TryGetValue(name, out info))
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
                return;
            }
            else
            {
                MessageBox.Show("Name not found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
        }

        /// <summary>
        /// Writes the data from the given dictionary to the given stream in
        /// arbitrary order.
        /// </summary>
        /// <param name="output">The stream to which to write.</param>
        /// <param name="t">The dictionary containing the data to be written.</param>
        private void WriteData(StreamWriter output, Dictionary<string, NameInformation> t)
        {
            foreach (KeyValuePair<string, NameInformation> p in t)
            {
                output.WriteLine(p.Value.Name);
                output.WriteLine(p.Value.Frequency);
                output.WriteLine(p.Value.Rank);
            }
        }

        /// <summary>
        /// Handles a Click event on the Save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSave_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                    {
                        WriteData(output, _names);
                    }
                    MessageBox.Show("File written.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
