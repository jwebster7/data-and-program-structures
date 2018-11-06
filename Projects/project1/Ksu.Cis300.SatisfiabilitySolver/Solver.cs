/* Author: Joe Webster
 * Class: CIS 300
 * Assignment: HW1
 * Date: 9.14.17
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.SatisfiabilitySolver
{
    public static class Solver
    { 
        /// <summary>
        /// IsValidFormula 
        /// </summary>
        /// <param name="strFormula"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        private static bool IsValidFormula(string[] strFormula, int numVar)
        {
            if(numVar < 1 || numVar > 26)
            {
                throw new IOException("The number of variables must be a positive integer no greater than 26");
            }
            //outer for loop for the rows
            for (int i = 1; i < strFormula.Length - 1; i++)
            {
                //inner foreach for the literals (a, b, c, A, B, C...
                foreach (char literal in strFormula[i])
                {
                    //Determing if it is in a valid range
                    if (!(literal >= 'A' && literal <= 'A' + numVar) && !(literal >= 'a' && literal <= 'a' + numVar))
                    {
                        throw new IOException("The formula is invalid");
                    }
                }                  
            }
            return true;
        }//end IsValidFormula

        /// <summary>
        /// Private method FillStack fills genericStack
        /// </summary>
        /// <param name="genericStack"></param>
        /// <param name="numVar"></param>
        private static void FillStack(Stack<bool> genericStack, int numVar)
        { 
            while (genericStack.Count < numVar)
            {
                genericStack.Push(false);
            }
        }//end FillStack

        /// <summary>
        /// Private method IsSolution
        /// </summary>
        /// <param name="assignVal"></param>
        /// <param name="strFormula"></param>
        /// <returns></returns>
        private static bool IsSolution(bool[] assignVal, string[] strFormula)
        {
            //Outer loop iterate through clauses; 
            for (int i = 1; i < strFormula.Length; i++)
            {
                bool clauseIsSolved = false;
                for (int j = 0; j < strFormula[i].Length; j++)
                {
                    char literal = strFormula[i][j];
                    //Char.IsUpper(literal) && assignVal['a' - literal]
                    //determine value assigned to var
                    if ((literal - 'a' >= assignVal.Length || literal - 'a' < 0) && (literal - 'A' >= assignVal.Length || literal - 'A' < 0))
                    {
                        throw new IndexOutOfRangeException("The formula is invalid");
                    }

                    if (Char.IsUpper(literal) && !assignVal[literal - 'A'] || Char.IsLower(literal) && assignVal[literal - 'a'])
                    {
                        clauseIsSolved = true;
                    }
                }
                if (!clauseIsSolved)
                    return false;
            }
            return true;
        }//end IsSolution

        /// <summary>
        /// This public method finds a satisfying assignment
        /// </summary>
        /// <param name="strFormula"></param>
        /// <param name="numVar"></param>
        /// <returns></returns>
        public static bool[] Solve(string[] strFormula, int numVar)
        {
            bool[] test = new bool[] { false, false, false };
            //event handling

            if (IsValidFormula(strFormula, numVar))
            {
                //Making a Stack of bool
                Stack<bool> localStack = new Stack<bool>();
                bool[] satisfiedBool = new bool[numVar];
                //Call FillStack method; fill a Stack<bool> with false values for each variable
                FillStack(localStack, numVar);
                while (localStack.Count != 0)
                {
                    //if # of elements on the stack == # of var, copy val from stack to new bool[] using ToArray
                    if (localStack.Count == numVar)
                    {
                        satisfiedBool = localStack.ToArray();
                        if (IsSolution(satisfiedBool, strFormula))
                        {
                            return satisfiedBool;
                        }
                    }//end outer if
                    if (!localStack.Pop())
                    {
                        localStack.Push(true);
                        FillStack(localStack, numVar);
                    }
                }
            }
            return null;
        }//end isSatisfied
    }
}
