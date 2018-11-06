/* Author: Joe Webster
 * Lab 32
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
using Ksu.Cis300.Graphs;

namespace Ksu.Cis300.MaxOutgoing
{
    public partial class MaxOutgoing : Form
    {
        public MaxOutgoing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the read a graph button
        /// </summary>
        /// <param name="sender">Generic object sent in</param>
        /// <param name="e">Generic EventArgs object</param>
        private void uxReadGraph_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxOpenDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(FindMax(ProcessFile(uxOpenDialog.FileName)).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Processes the file
        /// </summary>
        /// <param name="fileName">the name of the file</param>
        /// <returns>A graph of string and decimal</returns>
        private DirectedGraph<string, decimal> ProcessFile(string fileName)
        {
            DirectedGraph<string, decimal> dg = new DirectedGraph<string, decimal>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] lines = sr.ReadLine().Split(',');
                    decimal weight = Convert.ToDecimal(lines[2]);
                    dg.AddEdge(lines[0], lines[1], weight);
                }
            }
            return dg;
        }

        /// <summary>
        /// Finds the maximum sum of the edges
        /// </summary>
        /// <param name="dr">Graph passed in</param>
        /// <returns>The sum of the method</returns>
        private decimal FindMax(DirectedGraph<string, decimal> dr)
        {
            decimal max = 0;
            //traverses the nodes
            foreach (string node in dr.Nodes)
            {
                decimal sum = 0;
                foreach (Edge<string, decimal> e in dr.OutgoingEdges(node))
                {
                    sum += e.Data;
                }
                if (sum > max)
                {
                    max = sum;
                }
            }
            return max;
        }

    }
}
