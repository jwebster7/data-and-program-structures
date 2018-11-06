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
        /// Sorts the given list using merge sort.
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

        /// <summary>
        /// Merges two sorted portions of the given list into a single sorted portion.
        /// </summary>
        /// <param name="list">The list to merge.</param>
        /// <param name="start">The index of the first element of the first sorted portion.</param>
        /// <param name="len1">The length of the first sorted portion.</param>
        /// <param name="len2">The length of the second sorted portion.</param>
        private void Merge(IList<int> list, int start, int len1, int len2)
        {
            int[] temp = new int[len1 + len2];
            int source1 = start;
            int source2 = start + len1;
            int end1 = source2;
            int dest = 0;
            int end2 = source2 + len2;
            while (source1 < end1 && source2 < end2)
            {
                if (list[source1] <= list[source2])
                {
                    temp[dest] = list[source1];
                    source1++;
                }
                else
                {
                    temp[dest] = list[source2];
                    source2++;
                }
                dest++;
            }
            while (source1 < end1)
            {
                temp[dest] = list[source1];
                source1++;
                dest++;
            }
            while (source2 < end2)
            {
                temp[dest] = list[source2];
                source2++;
                dest++;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                list[start + i] = temp[i];
            }
        }

        /// <summary>
        /// Sorts the specified portion of the given list.
        /// </summary>
        /// <param name="list">The list to sort</param>
        /// <param name="start">The first index in the portion to sort.</param>
        /// <param name="len">The number of elements in the portion to sort.</param>
        private void Sort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int pivot = list[start];
                int followingL = start;
                int precedingE = start + len - 1;
                int precedingG = start + len - 1;

                while (followingL <= precedingE)
                {
                    if (list[precedingE] < pivot)
                    {
                        Swap(list, followingL, precedingE);
                        followingL++;
                    }

                    else if (pivot == list[precedingE])
                    {
                        precedingE--;
                    }
                    else
                    {
                        Swap(list, precedingG, precedingE);
                        precedingG--;
                        precedingE--;
                    }
                }
                Sort(list, start, followingL - start);
                Sort(list, precedingG + 1, start + len - precedingG - 1);
            }
        }
    }
}
