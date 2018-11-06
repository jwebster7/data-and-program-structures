/* UserInterface.cs
 * Author: Rod Howell
 * Modified by: Joe Webster
 * Date: 9.27.2017
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

namespace Ksu.Cis300.FolderSizes
{
    /// <summary>
    /// A GUI for a program that finds the sizes of folders.
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
        /// Recursive method calculating the # of bytes in folders and files
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private long TotalSize(DirectoryInfo folder)
        {
            long size = 0;
            try
            {
                foreach (DirectoryInfo dir in folder.GetDirectories())
                {
                    size += TotalSize(dir);
                }

                foreach (FileInfo files in folder.GetFiles())
                {
                    size += files.Length;
                }
            }
            catch
            {
                return 0;
            }
            return size;
        }

        // <summary>
        /// Sets the currently-analyzed folder to the given path name.
        /// </summary>
        /// <param name="folder">The path name for the folder to analyze.</param>
        private void SetCurrentFolder(DirectoryInfo folder)
        {
            uxCurrentFolder.Text = folder.FullName;
            long size = TotalSize(folder);
            uxSize.Text = size.ToString("N0");
            uxFolderList.Items.Clear();
            uxUp.Enabled = (folder.Parent != null);
            try
            {
                foreach (DirectoryInfo d in folder.GetDirectories())
                {
                    uxFolderList.Items.Add(d);
                }
            }
            catch
            {
                // If we can't access the sub-folders, we can't add them to the list.
            }
        }

        private void uxSetFolder_Click(object sender, EventArgs e)
        {
            if (uxFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                SetCurrentFolder(new DirectoryInfo(uxFolderBrowser.SelectedPath));
            }
        }

        private void uxFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo d = (DirectoryInfo)uxFolderList.SelectedItem;
            if (d != null)
            {
                SetCurrentFolder(d);
            }
        }

        private void uxUp_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(uxCurrentFolder.Text);
            SetCurrentFolder(d.Parent);
        }
    }
}
