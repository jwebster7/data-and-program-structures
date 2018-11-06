/* UserInterface.cs
 * Author: Rod Howell
 * Edited: Joe Webster
 * Date: 9.18.2017
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

namespace Ksu.Cis300.PrimeNumbers
{
    /// <summary>
    /// A GUI for a program to find all prime numbers less than a given value.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }//userinterface

        /// <summary>
        /// Handles a Click event on the "Find Primes" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFindPrimes_Click(object sender, EventArgs e)
        {
            LinkedListCell<int> primes = GetPrimesLessThan((int)uxInput.Value);
            uxPrimes.BeginUpdate();
            uxPrimes.Items.Clear();
            for (LinkedListCell<int> p = primes; p != null; p = p.Next)
            {
                uxPrimes.Items.Add(p.Data);
            }
            uxPrimes.EndUpdate();
        }

        /// <summary>
        /// Forms a linked list containing all prime numbers less than the given value.
        /// </summary>
        /// <param name="value">The upper limit (exclusive) on the prime numbers to generate.</param>
        /// <returns>A linked list containing all the prime numbers less than value.</returns>
        private LinkedListCell<int> GetPrimesLessThan(int value)
        {
            LinkedListCell<int> tempCell = GetNumbersLessThan(value);
            LinkedListCell<int> pointer = tempCell;
            while(pointer != null)
            {

                RemoveMultiples(pointer.Data, pointer);
                pointer = pointer.Next;
            }
            return tempCell;
        }//end GetPrimesLessThan

        /// <summary>
        /// Private method GetNumbersLessThan; Returns LinkedListCell<int>;
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private LinkedListCell<int> GetNumbersLessThan(int n)
        {
            LinkedListCell<int> numLessThan = null;
            
            for (int i = n - 1; i > 1; i--)
            {
                LinkedListCell<int> tempCell = new LinkedListCell<int>();
                tempCell.Data = i;
                tempCell.Next = numLessThan;
                numLessThan = tempCell;

            }//end for
            return numLessThan; 
        }//end LinkedListCell

        /// <summary>
        /// Private method RemoveMultiples; returns null
        /// </summary>
        /// <param name="k"></param>
        /// <param name="list"></param>
        private void RemoveMultiples(int k, LinkedListCell<int> list)
        {
            LinkedListCell<int> pointer = list;
            while (pointer.Next != null)
            {
                if ((pointer.Next.Data % k) == 0)
                {
                    pointer.Next = pointer.Next.Next;
                }
                else
                {
                    pointer = pointer.Next;
                }
            }//end while
        }//RemoveMultiples
    }
}
