using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Management.ReplacingBooks
{
    public class ReplacingBooks
    {
        private List<string> callNumbers = new List<string>();

        //generate 10 random dewey decimal system call numbers 
        public List<string> GenerateCallNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                string firstThreeDigits = random.Next(1, 1000).ToString();                  
                firstThreeDigits = AddZeros(firstThreeDigits);

                string digitsAfterPeriod = random.Next(1, 1000).ToString();

                callNumbers.Add(firstThreeDigits + "." + digitsAfterPeriod);

            }
            return callNumbers;
        }



        //sort the call numbers in ascending order using a sorting algorithm
        public List<string> SortCallNumbers()
        {
            for (int i = 0; i < callNumbers.Count; i++)
            {
                for (int j = i + 1; j < callNumbers.Count; j++)
                {
                    // Parse the call numbers into numeric values
                    double number1 = double.Parse(callNumbers[i]);
                    double number2 = double.Parse(callNumbers[j]);

                    if (number1 > number2)
                    {
                        // Swap the call numbers if they are out of order
                        string temp = callNumbers[i];
                        callNumbers[i] = callNumbers[j];
                        callNumbers[j] = temp;
                    }
                }
            }
            return callNumbers;
        }


        //recieve the list from the user and check if the order is correct
        public bool CheckOrder(List<string> userCallNumbers)
        {
            callNumbers = SortCallNumbers();

            for (int i = 0; i < callNumbers.Count; i++)
            {
                if (userCallNumbers[i] != callNumbers[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static string AddZeros(string text)
        {
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

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string randomLetters = "";

            for (int i = 0; i < 3; i++)
            {
                randomLetters += letters[random.Next(0, letters.Length)];
            }

            return randomLetters;
        }

    }
}
