using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccurenceChecker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        // Variables
        public static readonly List<string> validChars = new List<string>() { "A", "G", "C", "T" };
        public static string S, L;
        public static readonly string allowedChars = "AGCT ";
        public static string fullInput;

        public static void Main(string[] args)
        {
            //// Take inputs of the strings S and L
            // do loop, to perform the check atleast once
            do
            {
                fullInput = Console.ReadLine();
                // if 0 is input, exit the program
                if (fullInput == "0")
                {
                    Environment.Exit(0);
                }

                // Check if input is empty, if not - proceed!
                if (fullInput != "")
                {
                    if (CheckIfInputValid(fullInput))
                    {
                        string[] partInput = fullInput.Split(null);
                        if (partInput.Length >= 2)
                        {
                            S = partInput[0];
                            L = partInput[1];

                            if (S.Length <= L.Length && S.Length >= 2 && L.Length >= 2)
                            {
                                Console.WriteLine(CheckOccurrence(L, S) + " " + CheckOccuranceDelete(L, S) + " " + CheckOccuranceInsert(L, S));
                            }
                        }
                    }
                }
            } while (fullInput != "" && fullInput != null);
        }


        /*************
         * Functions**
         *************/

        // Function for checking allowed chars only
        public static bool CheckIfInputValid(string stringToCheck)
        {
            foreach (char c in stringToCheck)
            {
                if (!allowedChars.Contains(c.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        // Check occurances without any changes to S.
        public static int CheckOccurrence(string inputString, string patternString)
        {
            // Check that strings are filled!!
            if (inputString.Length < 2 || inputString == null
                || inputString.Length > 100)
            {
                return 0;
            }
            else if (patternString.Length < 2 || patternString == null
                || patternString.Length > 100)
            {
                return 0;
            }

            int result = 0;// occurrences found
            int currentIndex = 0;

            // Check for every occurrence from each index
            while (currentIndex != -1)
            {
                currentIndex = inputString.IndexOf(patternString, currentIndex);
                if (currentIndex != -1)
                {
                    result++;//found match, add to result
                    currentIndex++;
                }
            }
            currentIndex = 0;
            return result;
        }

        // Check occurances with deleting one char from S
        public static int CheckOccuranceDelete(string inputString, string patternString)
        {
            // Check that strings are filled!! 
            if (inputString.Length < 2 || inputString == null
                || inputString.Length > 100)
            {
                return 0;
            }
            else if (patternString.Length < 2 || patternString == null
                || patternString.Length > 100)
            {
                return 0;
            }

            int result = 0;
            int currentIndex = 0;
            string origPattern = patternString;
            List<string> prevPatternAdd = new List<string> { };
            int prevPatternCountDel = 0;

            // Loop through every element in the string and search for occurrences from that index
            for (int i = 0; i < origPattern.Length; i++)
            {
                patternString = patternString.Remove(i, 1);

                if (prevPatternAdd.Contains(patternString))
                {
                    currentIndex = -1;
                }

                while (currentIndex != -1)
                {
                    currentIndex = inputString.IndexOf(patternString, currentIndex);
                    if (currentIndex != -1)
                    {
                        result++;
                        currentIndex++;

                        // Use a list to insert used patterns, use a counter as index
                        prevPatternAdd.Insert(prevPatternCountDel, patternString);
                        prevPatternCountDel++;
                    }
                }
                // Reset pattern to it's orig value
                patternString = origPattern;
                currentIndex = 0;
            }
            return result;
        }

        // Check occurances with adding one char to S
        public static int CheckOccuranceInsert(string inputString, string patternString)
        {
            // Check that strings are filled!!
            if (inputString.Length < 2 || inputString == null
                || inputString.Length > 100)
            {
                return 0;
            }
            else if (patternString.Length < 2 || patternString == null
                || patternString.Length > 100)
            {
                return 0;
            }

            // Variables needed
            int result = 0; // occurrences found
            int currentIndex = 0; //index of search
            int letterAdded = 0; //noLettersadded
            int prevPatternCount = 0; //index for prev pattern count
            string origPattern = patternString; //keep the original pattern!
            List<string> prevPatternDel = new List<string> { }; //store patterns here

            for (int j = 0; j <= origPattern.Length; j++)
            {
                while (validChars.Count > letterAdded)
                {
                    patternString = patternString.Insert(j, validChars[letterAdded]);
                    letterAdded++; //Index for what char to add next!

                    if (prevPatternDel.Contains(patternString))
                    {
                        currentIndex = -1;
                    }

                    while (currentIndex != -1)
                    {
                        currentIndex = inputString.IndexOf(patternString, currentIndex);
                        if (currentIndex != -1)
                        {
                            result++;
                            currentIndex++;
                            // Use a list to insert used patterns, use a counter as index
                            prevPatternDel.Insert(prevPatternCount, patternString);
                            prevPatternCount++;
                        }
                    }
                    patternString = origPattern;
                    currentIndex = 0;
                }
                if (validChars.Count == letterAdded)
                {
                    letterAdded = 0;
                }
            }
            return result;
        }
    }
}