/*
 * Author: Joe Webster
 * Class: CIS 300 M W F | 11:30-1:20pm
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.StackLibrary
{
    /// <summary>
    /// This is a class for a generic Stack
    /// </summary>
    /// <typeparam name="T">This parameter represents the number of items in the stack</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// this is a generic array of type T
        /// </summary>
        private T[] _genericStack = new T[5];

        /// <summary>
        /// this is an int variable
        /// </summary>
        private int _items = 0;

        /// <summary>
        /// This is a property that gets the # of items in the stack array T[].
        /// </summary>
        public int Count
        {
            get
            {
                return _items;
            }
        }

        /// <summary>
        /// Pushes T type items to a new array and doubles the size of the array.
        /// </summary>
        /// <param name="x"></param>
        public void Push(T x)
        {
            if (_items == _genericStack.Length)
            {
                T[] _localStack = new T[2*_items];
                _genericStack.CopyTo(_localStack, 0);
                _genericStack = _localStack;
            }
            _genericStack[_items] = x;
            _items++;
        }//end Push method

        /// <summary>
        /// Peek looks at the top of the T[].
        /// </summary>
        /// <returns>Returns T-type items</returns>
        public T Peek()
        {
            if (_items == 0)
            {
                //throw an exception if stack is empty
                throw new InvalidOperationException();
            }
            else
            {
                //top element is the one preceding the location indexed by the number of elements.
                return _genericStack[_items-1];
            }
        }//end T Peek method

        /// <summary>
        /// Pop peeks at the top item, then removes it.
        /// </summary>
        /// <returns>Returns T-type items</returns>
        public T Pop()
        {
            T _localItem = Peek();
            _genericStack[_items - 1] = default(T);
            _items--;
            return _localItem;
        }//end T Pop method
    }
}
