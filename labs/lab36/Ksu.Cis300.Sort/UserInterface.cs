/* Author: Joe Webster
 * Class: CIS 300
 * Date: 11/29/2017
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

namespace Ksu.Cis300.Sort
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Helper method for Sort
        /// </summary>
        /// <param name="list">given IList</param>
        /// <param name="i">index of list</param>
        /// <param name="j">index of list</param>
        private void Swap(IList<int> list, int i, int j)
        {
            int tempInt = list[i];
            list[i] = list[j];
            list[j] = tempInt;
        }

        /// <summary>
        /// Sorts the given list
        /// </summary>
        /// <param name="list">Given IList</param>
        private void Sort(IList<int> list)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                int min = i;
                for (int j = i+1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                Swap(list, i, min);
            } 
        }

        /// <summary>
        /// Event handler for Sort File
        /// </summary>
        /// <param name="sender">generic object</param>
        /// <param name="e">EventArgs is the object argument passed in</param>
        private void uxSortFile_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK && uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                List<int> values = new List<int>();
                try
                {
                    using (StreamReader input = new StreamReader(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            int value = Convert.ToInt32(input.ReadLine());
                            values.Add(value);
                        }
                    }
                    Sort(values);
                    using (StreamWriter output = new StreamWriter(uxSaveDialog.FileName))
                    {
                        foreach (int i in values)
                        {
                            output.WriteLine("{0,10:D}", i);
                        }
                    }
                    MessageBox.Show("Sorting complete.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.ToString());
                }
            }
        }
    }
}
