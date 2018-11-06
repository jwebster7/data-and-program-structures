/* UserInterface.cs
 * Author: Rod Howell
 * Edit: Joe Webster
 * Date: 12/8/2017
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
        /// This method calculates the median
        /// </summary>
        /// <param name="a">first to compare</param>
        /// <param name="b">second to compare</param>
        /// <param name="c">third to compare</param>
        /// <returns></returns>
        private int MedianOfThree(int a, int b, int c)
        {
            if (a < b)
            {
                if (b < c)
                {
                    return b;
                }
                else
                {
                    return a;
                }
            }
            else
            {
                if (a < c)
                {
                    return a;
                }
                else
                {
                    if (b < c)
                    {
                        return c;
                    }
                    else
                    {
                        return b;
                    }
                }
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
        /// Sorts the given list using quick sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        private void Sort(IList<int> list)
        {
            QuickSort(list, 0, list.Count, 0);
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
        /// <param name="list">The list to sort.</param>
        /// <param name="start">The first index in the portion to sort.</param>
        /// <param name="len">The number of elements in the portion to sort.</param>
        private void QuickSort(IList<int> list, int start, int len, int depth)
        {

            if (len > 1)
            {
                if (len < 10)
                {
                    InsertionSort(list, start, len);
                }
                else if (depth > 32)
                {
                    MergeSort(list, start, len);
                }
                else
                {
                    int p = MedianOfThree(list[start], list[start + len - 1], list[start + (len / 2)]);
                    int afterL = start;
                    int beforeE = start + len - 1;
                    int beforeG = beforeE;
                    while (afterL <= beforeE)
                    {
                        if (list[beforeE] < p)
                        {
                            Swap(list, afterL, beforeE);
                            afterL++;
                        }
                        else if (list[beforeE] == p)
                        {
                            beforeE--;
                        }
                        else
                        {
                            Swap(list, beforeE, beforeG);
                            beforeE--;
                            beforeG--;
                        }
                    }
                    depth++;
                    QuickSort(list, start, afterL - start, depth);
                    QuickSort(list, beforeG + 1, start + len - beforeG - 1, depth);
                }
            }
        }

        /// <summary>
        /// Sorts the given list using insertion sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        private void InsertionSort(IList<int> list, int start, int len)
        {
            for (int i = start; i < start + len; i++)
            {
                int temp = list[i];
                int j = i;
                while (j > 0 && temp < list[j - 1])
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = temp;
            }
        }

        /// <summary>
        /// Sorts the specified portion of the given list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="start">The first index in the portion to sort.</param>
        /// <param name="len">The number of elements in the portion to sort.</param>
        private void MergeSort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int len1 = len / 2;
                int len2 = len - len1;
                MergeSort(list, start, len1);
                MergeSort(list, start + len1, len2);
                Merge(list, start, len1, len2);
            }
        }
    }
}
