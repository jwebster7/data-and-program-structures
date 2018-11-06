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
    public struct WordFrequency
    {
        /// <summary>
        /// String storing a word
        /// </summary>
        private string _word;

        /// <summary>
        /// Float[] storing the frequency of the word in each file
        /// </summary>
        private float[] _wordFrequency;

        /// <summary>
        /// Constructor for WordFrequency struct; 
        /// Initializes _word;
        /// Initializes _wordFrequency;
        /// </summary>
        /// <param name="wordCount">Used for grabbing the .Word and .NumberOfFiles property</param>
        /// <param name="wordsInFile">Array for comparison to find the frequency</param>
        public WordFrequency(WordCount wordCount, int[] wordsInFile)
        {
            if (wordCount.NumberOfFiles != wordsInFile.Length)
            {
                throw new ArgumentException();
            }
            else
            {
                _word = wordCount.Word; //sets _word equal to _word property of wordCount
                _wordFrequency = new float[wordsInFile.Length];
                for(int i = 0; i < _wordFrequency.Length; i++)
                {
                    _wordFrequency[i] = (float)(wordCount[i]) / wordsInFile[i];
                }
            }
        }// end Word Frequency constructor

        /// <summary>
        /// Property returning _word
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }

        /// <summary>
        /// Indexer gets the int at the location "i" in _wordFrequency
        /// </summary>
        /// <param name="i">Index of val to return</param>
        /// <returns>Returns the frequency of the word</returns>
        public float this[int i]
        {
            get
            {
                if (i < _wordFrequency.Length && i >= 0)
                {
                    return _wordFrequency[i];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
