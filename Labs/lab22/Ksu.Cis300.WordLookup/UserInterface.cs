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

namespace Ksu.Cis300.WordLookup
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The dictionary of words.
        /// </summary>
        private ITrie _dictionary;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Open Dictionary" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                _dictionary = new TrieWithNoChildren();
                try
                {
                    using (StreamReader input = File.OpenText(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            string word = input.ReadLine();
                            _dictionary = _dictionary.Add(word);
                        }
                    }
                    MessageBox.Show("Dictionary successfully read.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Look up Word" button.
        /// </summary>
        /// <param name="sender">boject from the event</param>
        /// <param name="e">event object</param>
        private void uxLookUp_Click(object sender, EventArgs e)
        {
            uxCompletions.Items.Clear();

            ITrie completions = _dictionary.GetCompletions(uxWord.Text);// Fill in code to get the trie containing all completions of uxWord.Text

            if (completions != null)
            {
                uxCompletions.BeginUpdate();

                // Add code to place all words beginning with uxWord.Text into the IList uxCompletions.Items.
                StringBuilder prefix = new StringBuilder(uxWord.Text);
                completions.AddAll(prefix, uxCompletions.Items);

                uxCompletions.EndUpdate();
            }
        }


    }
}
