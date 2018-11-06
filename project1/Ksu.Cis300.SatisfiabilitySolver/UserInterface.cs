/* Author: Joe Webster
 * Class: CIS 300
 * Assignment: HW1
 * Date: 9.14.17
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

namespace Ksu.Cis300.SatisfiabilitySolver
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// public Constructor for the UserInterface class
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the Read Formula button;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxReadFormula_Click(object sender, EventArgs e)
        {
            //showing the OpenFileDialog Box
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //clearing the uxDisplaySolution TextBox
                uxDisplaySolution.Text = "";
                Update();
                //reading the file in and grabbing the length and 
                string file = uxOpenFileDialog.FileName;
                try
                {
                    string[] formulaArray = File.ReadAllLines(file);
                    int numVar = Convert.ToInt32(formulaArray[0]);
                    bool[] isSolution = Solver.Solve(formulaArray, numVar);
                    if (isSolution == null)
                    {
                        MessageBox.Show("There is no solution found.");
                    }
                    else
                    {
                        DisplaySolution(isSolution);
                    }
                }//end try
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }//end catch
            }
        }

        /// <summary>
        /// private Display Solution
        /// </summary>
        /// <param name="satisfied"></param>
        private void DisplaySolution(bool[] satisfied)
        {
            StringBuilder sb = new StringBuilder();
            int indexAddArray;
            for (int i = 0; i < satisfied.Length; i++)
            {
                if (satisfied[i])
                {
                    indexAddArray = 'a' + i;
                    sb.Append(Convert.ToChar(indexAddArray));
                }//end if
                if (!satisfied[i])
                {
                    indexAddArray = 'A' + i;
                    sb.Append(Convert.ToChar(indexAddArray));
                }
            }//end for
            uxDisplaySolution.Text = sb.ToString();
        }//end DisplaySolution
    }
}
