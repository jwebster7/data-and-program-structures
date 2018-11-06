/* UserInterface.cs
 * Author: Rod Howell
 * Edited: Joe Webster
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
    /// <summary>
    /// A GUI for a program that sorts files of integers.
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
        /// Sorts the given list
        /// </summary>
        /// <param name="list">list to sort</param>
        /// <param name="start">where to start</param>
        /// <param name="len">length of portion to sort</param>
        private void Sort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int len1 = len / 2; //this finds the length of the first half
                int len2 = len - len1; //this find the length of the second half
                Sort(list, start, len1); //This sorts the first half of the list
                Sort(list, start + len1, len2); //This sorts the second half of the list
                Merge(list, start, len1, len2); //This merges the two halves 
            }
        }

        /// <summary>
        /// Merges the two split lists recursively
        /// </summary>
        /// <param name="list">the list which will be split</param>
        /// <param name="start">the starting int that will be used to split the list</param>
        /// <param name="len1">the length of the first half</param>
        /// <param name="len2">the length of the second half</param>
        private void Merge(IList<int> list, int start, int len1, int len2)
        {
            int[] sortedValues = new int[len1 + len2];

            int startOne = start; //index of first part
            int endOne = start + len1; //index of end of first part

            int startTwo = endOne; //index of second part
            int endTwo = startTwo + len2; //index of end of second part

            int i = 0; //counter

            //As long as both of the unshaded areas are nonempty...
            while (startOne < endOne && startTwo < endTwo)
            {
                if (list[startOne] <= list[startTwo])
                {
                    sortedValues[i] = list[startOne];
                    startOne++;
                    i++;
                }
                else
                {
                    sortedValues[i] = list[startTwo];
                    startTwo++;
                    i++;
                }
            }

            //If one of the nonshaded areas are still nonempty
            while (startOne < endOne)
            {
                sortedValues[i] = list[startOne];
                startOne++;
                i++;
            }
            
            while (startTwo < endTwo)
            {
                sortedValues[i] = list[startTwo];
                startTwo++;
                i++;
            }
            for (int j = 0; j < sortedValues.Length; j++)
            {
                list[j + start] = sortedValues[j];
            }
        }

        /// <summary>
        /// Swaps the values at the given locations in the given list.
        /// </summary>
        /// <param name="list">The list containing the elements to swap.</param>
        /// <param name="i">The location of one of the elements to swap.</param>
        /// <param name="j">The location of the other element.</param>
        private void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given list using insertion sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        private void Sort(IList<int> list)
        {
            Sort(list, 0, list.Count);
        }

        /// <summary>
        /// Handles a Click event on the "Sort File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSort_Click(object sender, EventArgs e)
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
