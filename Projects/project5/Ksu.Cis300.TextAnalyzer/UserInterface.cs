/* Author: Joe Webster
 * Date: 11/8/2017
 * Assignment: Homework 5
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
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Base constructor for the UI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Selects the first file
        /// </summary>
        /// <param name="sender">generic object passed in</param>
        /// <param name="e">generic EventArgs object</param>
        private void uxSelectText1_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText1.Text = uxOpenDialog.FileName;
                if (uxSelectText2.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }//end if uxSelectText2...
            }//end if uxOpenDialog.ShowDialog()...
        }//end select1

        /// <summary>
        /// Selects the second file
        /// </summary>
        /// <param name="sender">generic object passed in</param>
        /// <param name="e">generic EventArgs object</param>
        private void uxSelectText2_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText2.Text = uxOpenDialog.FileName;
                if (uxSelectText1.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }//end if uxSelectText1...
            }//end if uxOpenDialog.ShowDialog()...
        }//end select2

        /// <summary>
        /// Analyzes the files
        /// </summary>
        /// <param name="sender">generic object passed in</param>
        /// <param name="e">generic EventArgs object</param>
        private void uxAnalyze_Click(object sender, EventArgs e)
        {
            Dictionary<string, WordCount> dictionary = new Dictionary<string, WordCount>();
            int[] wordCount = new int[2];
            wordCount[0] = TextAnalyzer.ProcessFile(uxText1.Text, 0, dictionary);
            wordCount[1] = TextAnalyzer.ProcessFile(uxText2.Text, 1, dictionary);
            MinPriorityQueue<float, WordFrequency> minimumQueue = TextAnalyzer.GetMostCommonWords(dictionary, wordCount, (int)uxNumberOfWords.Value);
            float diff = TextAnalyzer.GetDifference(minimumQueue);
            MessageBox.Show("Difference measure: " + diff.ToString());
        }//end analyze
    }
}
