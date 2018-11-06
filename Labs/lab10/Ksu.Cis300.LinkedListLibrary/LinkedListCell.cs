/* Author: Joe Webster
 * Class: CIS 300
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    public class LinkedListCell<T>
    {
        /// <summary>
        /// Private _data type T
        /// </summary>
        private T _data;

        /// <summary>
        /// Private LinkedListCell<T> _next
        /// </summary>
        private LinkedListCell<T> _next;

        public T Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }//end property Data

        public LinkedListCell<T> Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }
    }
}
