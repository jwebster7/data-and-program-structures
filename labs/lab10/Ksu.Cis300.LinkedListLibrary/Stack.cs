/* Author: Joe Webster
 * Class: CIS 300
 * 11:30 - 1:20pm
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    public class Stack<T>
    {   
        /// <summary>
        /// _topStack is a LinkedListCell
        /// </summary>
        private LinkedListCell<T> _topStack = null;

        /// <summary>
        /// counter for numElements
        /// </summary>
        private int _numElements;

        public int Count
        {
            get
            {
                return _numElements;
            }
            set
            {
                _numElements = value;
            }
        }//end count

        /// <summary>
        /// push puts new cells into _topStack
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
            LinkedListCell<T> element = new LinkedListCell<T>();
            element.Data = x;
            element.Next = _topStack;
            _topStack = element;
            _numElements++;
        }//end push

        /// <summary>
        /// Peek shows what element is the reference
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_numElements == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {                
                return _topStack.Data;
            }
        }//end peek

        /// <summary>
        /// Pop shows and removes the front element in _topStack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T toReturn = Peek();
            _topStack = _topStack.Next;
            _numElements--;
            return toReturn;
        }//end pop
    }
}
