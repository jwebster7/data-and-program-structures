/* Author: Joe Webster
 * Date: 11/29/2017 - 12/1/2017
 * Instructor: Dr. Weese
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
using System.IO;

namespace Ksu.Cis300.TravelingSalesperson
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads a graph from a filename and constructs a new graph
        /// </summary>
        /// <param name="fileName">the filename passed in</param>
        /// <returns></returns>
        private UndirectedGraph ReadGraph(string fileName)
        {
            UndirectedGraph graph;
            using (StreamReader sr = new StreamReader(fileName))
            {
                int size = Convert.ToInt32(sr.ReadLine());
                graph = new UndirectedGraph(size);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] fields = line.Split(',');
                    graph.AddEdge(fields[0], fields[1], Convert.ToInt32(fields[2]));
                }

            }
            return graph;
        }

        /// <summary>
        /// Event handler for the opening a graph; constructs a tree
        /// </summary>
        /// <param name="sender">general object passed in</param>
        /// <param name="e">event object passed in</param>
        private void uxLoadGraph_Click(object sender, EventArgs e)
        {
            try
            {
                UndirectedGraph graph;
                MSTNode node;
                TreeForm tf;
                if (uxOpenDialog.ShowDialog() == DialogResult.OK)
                {
                    graph = ReadGraph(uxOpenDialog.FileName);
                    node = graph.GetMinSpanningTree();
                    tf = new TreeForm(node, 100);
                    tf.Show();
                    uxTour.Text = node.Walk();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //These two event handlers weren't needed, but they cause an error 
        //when removed from the code. 
        private void uxTourLabel_Click(object sender, EventArgs e)
        {

        }

        private void uxTour_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
