using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Management.ReplacingBooks
{
    public class ReplacingBooks
    {
        private string[] callNumbers = new string[10];

        //generate 10 random dewey decimal system call numbers 
        public string[] GenerateCallNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                callNumbers[i] = random.Next(1, 1000).ToString() + "." + random.Next(1, 100).ToString();

            }
            return callNumbers;
        }



        //sort the call numbers in ascending order using a sorting algorithm
        public string[] SortCallNumbers()
        {
            for (int i = 0; i < callNumbers.Length; i++)
            {
                for (int j = i + 1; j < callNumbers.Length; j++)
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
        public bool CheckOrder(string[] callNumbers)
        {
            for (int i = 0; i < callNumbers.Length; i++)
            {
                if (callNumbers[i] != this.callNumbers[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
