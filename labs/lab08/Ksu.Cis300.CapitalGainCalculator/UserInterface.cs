/* UserInterface.cs
 * Author: Rod Howell
 * Edited: Joe Webster 
 * Class: CIS 300 | M W F 11:30-1:20pm
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

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A user interface for a simple captial gain calculator for a single stock commodity.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// This is instantiating a private field "_shareCost" of type Queue<decimal>
        /// </summary>
        private Queue<decimal> _shareCost = new Queue<decimal>();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for "Buy" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBuy_Click(object sender, EventArgs e)
        {
            decimal numbShares = uxNumber.Value;
            decimal costShares = uxCost.Value;

            for (decimal i = 0; i < numbShares; i++)
            {
                _shareCost.Enqueue(costShares);
            }

            uxOwned.Text = _shareCost.Count.ToString();
        }

        /// <summary>
        /// Event handler for "Sell" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSell_Click(object sender, EventArgs e)
        {
            decimal sharesSold = uxNumber.Value;
            decimal costShares = uxCost.Value;

            if (sharesSold > _shareCost.Count)
            {
                MessageBox.Show("You cannot sell more shares than you own!");
            }
            else
            {
                decimal gainSoFar = Convert.ToDecimal(uxGain.Text);

                for (decimal i = 0; i < sharesSold; i++)
                {
                    decimal _originCost = _shareCost.Dequeue();
                    gainSoFar += (costShares -_originCost);
                }//end for 

                uxOwned.Text = _shareCost.Count.ToString();
                uxGain.Text = gainSoFar.ToString();

            }//end else
        }
    }
}
