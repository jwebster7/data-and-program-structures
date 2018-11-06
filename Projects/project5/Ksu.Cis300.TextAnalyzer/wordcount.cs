/* Author: Joe Webster
 * Date: 11/8/2017
 * Assignment: Homework 5
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    /// <summary>
    /// Used to store a word and accumulate its number of occurences in each file;
    /// Uses a dictionary to store the WordCounts as values, using the words as keys.
    /// </summary>
    public class WordCount
    {
        /// <summary>
        /// Stores a word
        /// </summary>
        private string _word;

        /// <summary>
        /// Number of files to be processed;
        /// Records the # of occurences of the word in each file;
        /// Size will be the number of files to be processed, and index "i" will
        /// store the # of occurnces of the above word in the "ith" file;
        /// </summary>
        private int[] _wordOccurence;

        /// <summary>
        /// Constructor for WordCount; Initializes _word and _wordOccurence
        /// </summary>
        /// <param name="word">Initial value for _word</param>
        /// <param name="wordOccurence">Initial value for _wordOccurence</param>
        public WordCount(string word, int wordOccurence)
        {
            _word = word;
            _wordOccurence = new int[wordOccurence];
        }// end WordCount

        /// <summary>
        /// Property returning the _word field
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }// end Word

        /// <summary>
        /// Property returning the length of the _wordOccurence field;
        /// Returns the number of files being processed
        /// </summary>
        public int NumberOfFiles
        {
            get
            {
                return _wordOccurence.Length;
            }
        }// end NumberOfFiles

        /// <summary>
        /// Indexer gets the int at the location "i" in wordOccurence
        /// </summary>
        /// <param name="i">Index of val to return</param>
        /// <returns>The value at _wordOccurence</returns>
        public int this[int i]
        {
            get
            {
                //if int i is a valid index in _wordOccurence...
                //maybe >= 0 as well
                if (i < _wordOccurence.Length && i >= 0)
                {
                    return _wordOccurence[i];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }// end indexer

        /// <summary>
        /// Method incrementing the number of occurences of the word in a file
        /// </summary>
        /// <param name="fileNumber"></param>
        public void Increment(int fileNumber)
        {
            //If the given file number is a valid index in _wordOccurence...
            if (fileNumber < _wordOccurence.Length)
            {
                //Increments the number of occurences of the word in that file
                _wordOccurence[fileNumber]++;
            }
            else
            {
                throw new ArgumentException();
            }
        }// end Increment
    }
}
