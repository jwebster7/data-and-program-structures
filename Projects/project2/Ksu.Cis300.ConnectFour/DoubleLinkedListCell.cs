/* Author: Joe Webster | CIS 300 | M W F 11:30-1:20
 * Date: 9.28.2017
 * Homework 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ConnectFour
{
    class DoubleLinkedListCell<T>
    {
        /// <summary>
        /// private field data
        /// </summary>
        private T _data = default(T);
        /// <summary>
        /// private string _id has letter and number
        /// </summary>
        private string _id;//should have column and row ex: "A4"
        /// <summary>
        /// Private dllc next
        /// </summary>
        private DoubleLinkedListCell<T> _next = null;
        /// <summary>
        /// Private dllc prev
        /// </summary>
        private DoubleLinkedListCell<T> _prev = null;

        /// <summary>
        /// Public property Data
        /// </summary>
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
        }

        /// <summary>
        /// Public property Id
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Public property Next
        /// </summary>
        public DoubleLinkedListCell<T> Next
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

        /// <summary>
        /// Public property dllc prev
        /// </summary>
        public DoubleLinkedListCell<T> Prev
        {
            get
            {
                return _prev;
            }
            set
            {
                _prev = value;
            }
        }

        /// <summary>
        /// Public property dllc identifier
        /// </summary>
        /// <param name="identifier"></param>
        public DoubleLinkedListCell(string identifier)
        {
            _id = identifier;
        }

    }
}
