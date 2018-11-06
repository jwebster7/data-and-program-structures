/* UserInterface.cs
 * Author: Rod Howell
 * Edited: Joe Webster
 * Course: CIS 300
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
        private BinaryTreeNode<NameInformation> _names = null;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Writes the data contained in a given binary search tree from "sw" and "node"
        /// </summary>
        /// <param name="sr">This parameter gives information to be written to the tree</param>
        /// <param name="node">This parameter gives information to be written to the tree</param>
        private void InorderTraversal(StreamWriter sw, BinaryTreeNode<NameInformation> node)
        {
            //compares thisName to node.Next.Data.Name
            if (node != null)
            {
                InorderTraversal(sw, node.LeftChild);
                sw.WriteLine(node.Data.Name);
                sw.WriteLine(node.Data.Frequency);
                sw.WriteLine(node.Data.Rank);
                InorderTraversal(sw, node.RightChild);
            }
        }

        /// <summary>
        /// Writes all lines of a file to a new file and stores it in a Stream then displays a messagebox with it
        /// </summary>
        /// <param name="sender">general object sender</param>
        /// <param name="e">event argument e</param>
        private void uxSave_Click(object sender, EventArgs e)
        { 
            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(uxSaveFileDialog.FileName))
                    {
                        InorderTraversal(sw, _names);
                    }
                    MessageBox.Show("File written");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }
            }
        }

        /// <summary>
        /// Reads the given file into a binary search tree.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A binary search tree containing the information from the file.</returns>
        private BinaryTreeNode<NameInformation> ReadFile(string fn)
        {
            BinaryTreeNode<NameInformation> t = null;
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    t = Add(new NameInformation(name, freq, rank), t);
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
                    new TreeForm(_names, 100).Show();
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
            NameInformation info = GetInformation(name, _names);
            if (info.Name == null)
            {
                MessageBox.Show("Name not found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
            else
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
                return;
            }
        }

        /// <summary>
        /// Finds the NameInformation containing the given name in the given binary search tree.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <param name="t">The binary search tree to search.</param>
        /// <returns>The NameInformation whose Name is name, or whose Name is null if t contains no
        /// such NameInformation.</returns>
        private NameInformation GetInformation(string name, BinaryTreeNode<NameInformation> t)
        {
            if (t == null)
            {
                return new NameInformation();
            }
            int comp = name.CompareTo(t.Data.Name);
            if (comp == 0)
            {
                return t.Data;
            }
            else if (comp < 0)
            {
                return GetInformation(name, t.LeftChild);
            }
            else
            {
                return GetInformation(name, t.RightChild);
            }
        }

        /// <summary>
        /// Builds the result of adding the given NameInformation to the given binary search tree.
        /// </summary>
        /// <param name="info">The NameInformation to add.</param>
        /// <param name="t">The binary search tree.</param>
        /// <returns>The resulting binary search tree.</returns>
        private BinaryTreeNode<NameInformation> Add(NameInformation info, BinaryTreeNode<NameInformation> t)
        {
            if (t == null)
            {
                return new BinaryTreeNode<NameInformation>(info, null, null);
            }
            int comp = info.Name.CompareTo(t.Data.Name);
            if (comp == 0)
            {
                throw new ArgumentException();
            }
            else if (comp < 0)
            {
                return new BinaryTreeNode<NameInformation>(t.Data, Add(info, t.LeftChild), t.RightChild);
            }
            else
            {
                return new BinaryTreeNode<NameInformation>(t.Data, t.LeftChild, Add(info, t.RightChild));
            }
        }

        /// <summary>
        /// Builds the binary search tree that results from removing the minimum name from the given
        /// binary search tree.
        /// </summary>
        /// <param name="t">The given tree.</param>
        /// <param name="min">The NameInformation removed.</param>
        /// <returns>The resulting tree.</returns>
        private BinaryTreeNode<NameInformation> RemoveMininumName(BinaryTreeNode<NameInformation> t, out NameInformation min)
        {
            if (t.LeftChild == null)
            {
                min = t.Data;
                return t.RightChild;
            }
            else
            {
                return new BinaryTreeNode<NameInformation>(t.Data, RemoveMininumName(t.LeftChild, out min), t.RightChild);
            }
        }

        /// <summary>
        /// Builds the result of removing the node with the given name from the given binary search tree.
        /// </summary>
        /// <param name="name">The name to remove.</param>
        /// <param name="t">The binary search tree.</param>
        /// <param name="removed">Indicates whether the name was found.</param>
        /// <returns>The resulting tree.</returns>
        private BinaryTreeNode<NameInformation> Remove(string name, BinaryTreeNode<NameInformation> t, out bool removed)
        {
            if (t == null)
            {
                removed = false;
                return t;
            }
            else
            {
                int comp = name.CompareTo(t.Data.Name);
                {
                    if (comp == 0)
                    {
                        removed = true;
                        if (t.LeftChild == null)
                        {
                            return t.RightChild;
                        }
                        else if (t.RightChild == null)
                        {
                            return t.LeftChild;
                        }
                        else
                        {
                            NameInformation min;
                            BinaryTreeNode<NameInformation> right = RemoveMininumName(t.RightChild, out min);
                            return new BinaryTreeNode<NameInformation>(min, t.LeftChild, right);
                        }
                    }
                    else if (comp < 0)
                    {
                        return new BinaryTreeNode<NameInformation>(t.Data, Remove(name, t.LeftChild, out removed), t.RightChild);
                    }
                    else
                    {
                        return new BinaryTreeNode<NameInformation>(t.Data, t.LeftChild, Remove(name, t.RightChild, out removed));
                    }
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Remove" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRemove_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            bool removed;
            _names = Remove(name, _names, out removed);
            if (removed)
            {
                new TreeForm(_names, 100).Show();
            }
            else
            {
                MessageBox.Show("Name not found.");
            }
            uxFrequency.Text = "";
            uxRank.Text = "";
        }

    }
}
