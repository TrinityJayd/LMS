using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Management.ReplacingBooks
{
    public class ReplacingBooks
    {
        //generate 10 random dewey decimal system call numbers 
        public List<string> GenerateCallNumbers()
        {
            List<string> callNumbers = new List<string>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                // Generate 3 random digits
                string firstThreeDigits = random.Next(1, 1000).ToString();

                // Format the digits to have 3 digits
                firstThreeDigits = AddZeros(firstThreeDigits);

                // Decide whether to include the period or not
                bool includePeriod = random.Next(0, 10) < 7; // 70% chance of including period


                string callNumber;

                if (includePeriod)
                {
                    // Generate 3 random digits after the period
                    string digitsAfterPeriod = random.Next(1, 100).ToString();
                    callNumber = firstThreeDigits + "." + digitsAfterPeriod + " " + GenerateLetters();
                }
                else
                {
                    callNumber = firstThreeDigits + " " + GenerateLetters();
                }

                // Create the call number
                callNumbers.Add(callNumber);
            }
            return callNumbers;
        }




        //sort the call numbers in ascending order 
        public List<string> SortCallNumbers(List<string> callNums)
        {
            for (int i = 1; i < callNums.Count; i++)
            {
                string current = callNums[i];
                int j = i - 1;

                while (j >= 0 && Compare(callNums[j], current) > 0)
                {
                    callNums[j + 1] = callNums[j];
                    j--;
                }
                
                callNums[j + 1] = current;
            }

            return callNums;
        }

        public static int Compare(string val1, string val2)
        {
            //Split the numbers from the letters
            string[] partsVal1 = val1.Split(' ');
            string[] partsVal2 = val2.Split(' ');

            //There must be letters and numbers
            if (partsVal1.Length != 2 || partsVal2.Length != 2)
            {
                throw new ArgumentException("Invalid input format");
            }

            double numberX, numberY;
            if (!double.TryParse(partsVal1[0], out numberX) || !double.TryParse(partsVal2[0], out numberY))
            {
                throw new ArgumentException("Invalid numeric part");
            }

            int numericComparison = numberX.CompareTo(numberY);

            if (numericComparison != 0)
            {
                return numericComparison;
            }

            //Compare the letters
            return string.Compare(partsVal1[1], partsVal2[1], StringComparison.Ordinal);
        }


        //recieve the list from the user and check if the order is correct
        public bool CheckOrder(List<string> userCallNumbers, List<string> gameCallNumbers)
        {
            gameCallNumbers = SortCallNumbers(gameCallNumbers);

            for (int i = 0; i < gameCallNumbers.Count; i++)
            {
                var res = userCallNumbers[i] ;
                //if the user's call numbers are not in the same order as the sorted call numbers, return false
                if (userCallNumbers[i] != gameCallNumbers[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static string AddZeros(string text)
        {
            //add zeros to the front of the string if the string is less than 3 characters
            if(text.Length == 1)
            {
                text = "00" + text;
            }
            else if(text.Length == 2)
            {
                text = "0" + text;
            }   

            return text;
        }

        //generate 3 random alphabetic letters
        public static string GenerateLetters()
        {
            Random random = new Random();

            //create a string of all the letters in the alphabet
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string randomLetters = "";

            //generate 3 random letters
            for (int i = 0; i < 3; i++)
            {
                randomLetters += letters[random.Next(0, letters.Length)];
            }

            //these letters will be used to create a call number, for the authors last name
            return randomLetters;
        }

        public Dictionary<string, string> GameLevelDescription()
        {
            //create a dictionary where the key is the level name and the description is the value
            Dictionary<string, string> levels = new Dictionary<string, string>
            {
                { "Beginner", "Sort the call numbers without a timer." },
                { "Intermediate", "Sort the call numbers within 40 seconds." },
                { "Challenger", "Sort the call numbers within 35 seconds." },
                { "Expert", "Master sorting the call numbers within 25 seconds." }

            };

            return levels;
        }          
        
    }
}
