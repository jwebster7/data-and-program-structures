/* Author: Joe Webster
 * Date: 11/8/2017
 * Assignment: Homework 5
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    public static class TextAnalyzer
    {
        /// <summary>
        /// This method processes a file using fileName, fileNumber, & wordDictionary
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="fileNumber">The number of files</param>
        /// <param name="wordDictionary">The dictionary of words and WordCount</param>
        /// <returns>Returns the total number of words in the file</returns>
        public static int ProcessFile(string fileName, int fileNumber, Dictionary<string, WordCount> wordDictionary)
        {
            int wordCount = 0;
            using (StreamReader input = new StreamReader(fileName))
            {
                while(!input.EndOfStream)
                {
                    string fileText = input.ReadLine().ToLower();
                    string[] textToSplit = Regex.Split(fileText, "[^abcdefghijklmnopqrstuvwxyz]+");
                    foreach(string word in textToSplit)
                    {
                        if(word != "")
                        {
                            wordCount++;
                            WordCount count;
                            bool wordExists = wordDictionary.TryGetValue(word, out count);
                            if(wordExists == false)
                            {
                                count = new WordCount(word, 2);
                                wordDictionary.Add(word, count);
                            }
                            count.Increment(fileNumber);
                        }//end if word != ""
                    }//end foreach word in textToSplit
                }//end !input.EndOfStream
            }//end Streamreader
            return wordCount;
        }//end ProcessFile

        /// <summary>
        /// This method removes the minimum priority object in the queue
        /// </summary>
        /// <param name="wordDictionary">This dictionary holds words and WordCounts</param>
        /// <param name="wordCount">The count of words</param>
        /// <param name="wordsToGet">The number of words to get</param>
        /// <returns>Returns the frequencies in each file of the most common words</returns>
        public static MinPriorityQueue<float, WordFrequency> GetMostCommonWords(Dictionary<string, WordCount> wordDictionary, int[] wordCount, int wordsToGet)
        {
            MinPriorityQueue<float, WordFrequency> minimumQueue = new MinPriorityQueue<float, WordFrequency>();
            foreach(WordCount w in wordDictionary.Values)
            {
                WordFrequency frequency = new WordFrequency(w, wordCount);
                minimumQueue.Add(frequency[0] + frequency[1], frequency);
                if (minimumQueue.Count > wordsToGet)
                {
                    minimumQueue.RemoveMinimumPriority();
                }//end if
            }// foreach
            return minimumQueue;
        }// end GetMostCommonWords

        /// <summary>
        /// This method finds the difference measure between the frequency of the words to use
        /// </summary>
        /// <param name="frequency">frequency of the word in MinPriorityQueue</param>
        /// <returns>Returns the difference between the frequencies</returns>
        public static float GetDifference(MinPriorityQueue<float, WordFrequency> frequency)
        {
            float diffMeasured = 0;
            while (frequency.Count > 0)
            {
                WordFrequency wordFrequency = frequency.RemoveMinimumPriority();
                diffMeasured += (wordFrequency[0] - wordFrequency[1]) * (wordFrequency[0] - wordFrequency[1]);
            }
            float squareRoot = 100 * (float)Math.Sqrt(diffMeasured);
            return squareRoot;
        }//end GetDifference
    }
}
