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
                //generate 3 random digits
                string firstThreeDigits = random.Next(1, 1000).ToString(); 

                //format the digits to have 3 digits
                firstThreeDigits = AddZeros(firstThreeDigits);

                //generate 3 random digits after the period
                string digitsAfterPeriod = random.Next(1, 1000).ToString();

                //create the call number
                callNumbers.Add(firstThreeDigits + "." + digitsAfterPeriod);

            }
            return callNumbers;
        }



        //sort the call numbers in ascending order 
        public List<string> SortCallNumbers(List<string> callNums)
        {
            for (int i = 0; i < callNums.Count; i++)
            {
                for (int j = i + 1; j < callNums.Count; j++)
                {
                    // Parse the call numbers into numeric values
                    double number1 = double.Parse(callNums[i]);
                    double number2 = double.Parse(callNums[j]);

                    if (number1 > number2)
                    {
                        // Swap the call numbers if they are out of order
                        string temp = callNums[i];
                        callNums[i] = callNums[j];
                        callNums[j] = temp;
                    }
                }
            }
            return callNums;
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
                { "Beginner", "Sort call numbers without a timer." },
                { "Intermediate", "Sort call numbers with the author's last name within 45 seconds." },
                { "Challenger", "Sort numbers and letters within 35 seconds." },
                { "Expert", "Master sorting numbers and letters within 25 seconds." }

            };

            return levels;
        }          
        
    }
}
