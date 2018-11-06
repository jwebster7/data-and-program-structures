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
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.ImmutableBinaryTrees;
using Ksu.Cis300.Sort;
using System.IO;

namespace Ksu.Cis300.HuffmanTree
{
    /// <summary>
    /// A user interface for a program that constructs and displays Huffman trees from files.
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
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectFile_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryTreeNode<byte> t = null;

                    // Add code to build the Huffman tree and assign it to t.
                    t = HuffmanTree(HuffmanTreeLeaves(FrequencyTable(uxOpenDialog.FileName)));
                    new TreeForm(t, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Creates a frequency table
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        private long[] FrequencyTable(string fn)
        {
            long[] frequencyTable = new long[256];
            using (FileStream fs = File.OpenRead(fn))
            {
                int k;
                while ((k = fs.ReadByte()) != -1)
                {
                    frequencyTable[k]++;
                }
            }
            return frequencyTable;
        }

        /// <summary>
        /// Constructs HuffmanTreeLeaves
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private MinPriorityQueue<long, BinaryTreeNode<byte>> HuffmanTreeLeaves(long[] table)
        {
            MinPriorityQueue<long, BinaryTreeNode<byte>> mPQ = new MinPriorityQueue<long, BinaryTreeNode<byte>>();
            //MinPriorityQueue<Priority, Value>
            for (int i = 0; i <  table.Length; i++)
            {
                if (table[i] != 0)
                {
                    BinaryTreeNode<byte> tempNode = new BinaryTreeNode<byte>((byte)i, null, null);
                    mPQ.Add(table[i], tempNode);
                }
            }
            return mPQ;
        }

        /// <summary>
        /// Builds a HuffmanTree
        /// </summary>
        /// <param name="minQueue"></param>
        /// <returns></returns>
        private BinaryTreeNode<byte> HuffmanTree(MinPriorityQueue<long, BinaryTreeNode<byte>> minQueue)
        {
            while(minQueue.Count > 1)
            {
                long minimumOne = minQueue.MinimumPriority;
                BinaryTreeNode<byte> minTreeOne = minQueue.RemoveMinimumPriority();
                long minimumTwo = minQueue.MinimumPriority;
                BinaryTreeNode<byte> minTreeTwo = minQueue.RemoveMinimumPriority();

                minQueue.Add(minimumOne + minimumTwo, new BinaryTreeNode<byte>(0, minTreeOne, minTreeTwo));
            }
            return minQueue.RemoveMinimumPriority();
        }
    }
}
