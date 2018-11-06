/* Author: Joe Webster
 * Date: 10/24/2017
 */
using KansasStateUniversity.TreeViewer2;
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

namespace Ksu.Cis300.BTrees
{
    public partial class NameLookup : Form
    {
        public NameLookup()
        {
            InitializeComponent();
            uxMinimumDegree.Value = 2;
        }

        /// <summary>
        /// Stores the tree that is created by reading in a NameInformation file
        /// </summary>
        private BTree<string, NameInformation> _names;

        /// <summary>
        /// Takes in the file name of a NameInformation file and reads it using a Streamreader
        /// </summary>
        /// <param name="fn">filename of NameInformation file</param>
        /// <returns></returns>
        private BTree<string, NameInformation> ReadFile(string fn)
        {
            int minimumDeg = Convert.ToInt32(uxMinimumDegree.Value);
            BTree<string, NameInformation> tempTree = new BTree<string, NameInformation>(minimumDeg);
            using (StreamReader sr = new StreamReader(fn))
            {
                while (!sr.EndOfStream)
                {
                    string name = sr.ReadLine().Trim();
                    float freq = Convert.ToSingle(sr.ReadLine());
                    int rank = Convert.ToInt32(sr.ReadLine());
                    NameInformation tempName = new NameInformation(name, freq, rank);
                    tempTree.Insert(name, tempName);
                }
            }
            return tempTree;
        }

        /// <summary>
        /// Event handler for the Make Tree button
        /// </summary>
        /// <param name="sender">general object</param>
        /// <param name="e">the argument object </param>
        private void uxMakeTree_Click(object sender, EventArgs e)
        {
            int minimumDeg = (int)uxMinimumDegree.Value;
            int count = Convert.ToInt32(uxNumberOfItems.Text);
            BTree<int, int> tempTree = new BTree<int, int>(minimumDeg);
            for (int i = 1; i <= count; i++)
            {
                tempTree.Insert(i, i);
            }
            new TreeForm(tempTree, 100).Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenDataFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog uxOpenFile = new OpenFileDialog();
            if (uxOpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadFile(uxOpenFile.FileName);
                    new TreeForm(_names, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Event handler for Look Up or Get Statistics button
        /// </summary>
        /// <param name="sender">general object passed in</param>
        /// <param name="e">EventArgs object passed in</param>
        private void uxGetStatistics_Click(object sender, EventArgs e)
        {
            string fileName = uxNameBox.Text.Trim().ToUpper();
            //try
            //{
                NameInformation nameInfoFile = _names.Find(fileName);
                if (nameInfoFile.Name != null)
                {
                    uxFrequency.Text = nameInfoFile.Frequency.ToString();
                    uxRank.Text = nameInfoFile.Rank.ToString();
                    return;
                }
                else
                {
                    uxFrequency.Clear();
                    uxRank.Clear();
                    MessageBox.Show("Name was not found!");
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    uxFrequency.Clear();
            //    uxRank.Clear();
            //}
        }
    }
}
