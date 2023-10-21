namespace LMS_Management.IdentifyingAreas
{
    public class IdentifyingAreas
    {
        private Dictionary<string, string> areas;
        private string[] extras;
        private string[] descriptions;
        private const int MAX_ITEMS = 4;
        private const int EXTRAS = 3;


        public Dictionary<string, string> GenerateAreas(string mode)
        {
            SetDescriptions();
            areas = new Dictionary<string, string>();
            extras = new string[EXTRAS];
            if (mode == "Call Numbers to Description")
            {
                for (int i = 0; i < MAX_ITEMS; i++)
                {
                    int callNumber = GetCallNumber();
                    SetKeysAndValues(callNumber);
                }

                int count = 0;
                while (extras.Length < EXTRAS)
                {
                    var random = new Random();
                    int randPosition = random.Next(0, 10);

                    string description = descriptions[randPosition];

                    if (!areas.ContainsKey(description))
                    {
                        extras[count] = description;
                        count++;
                    }
                }
            }
            else if (mode == "Descriptions to Call Numbers")
            {
                
            }


            return areas;
        }

        public string[] GetExtras()
        {
            return extras;
        }

        private void SetKeysAndValues(int callNumber)
        {
            switch (callNumber)
            {
                case int num when (num >= 0 && num < 100):
                    string number = AddZeros(num);
                    string description = descriptions[0];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 100 && num < 200):
                    number = AddZeros(num);
                    description = descriptions[1];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 200 && num < 300):
                    number = AddZeros(num);
                    description = descriptions[2];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 300 && num < 400):
                    number = AddZeros(num);
                    description = descriptions[3];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 400 && num < 500):
                    number = AddZeros(num);
                    description = descriptions[4];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 500 && num < 600):
                    number = AddZeros(num);
                    description = descriptions[5];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 600 && num < 700):
                    number = AddZeros(num);
                    description = descriptions[6];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 700 && num < 800):
                    number = AddZeros(num);
                    description = descriptions[7];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 800 && num < 900):
                    number = AddZeros(num);
                    description = descriptions[8];
                    areas.Add(number, description);
                    break;
                case int num when (num >= 900 && num < 1000):
                    number = AddZeros(num);
                    description = descriptions[9];
                    areas.Add(number, description);
                    break;

            }
        }

        private int GetCallNumber()
        {
            var random = new Random();
            return random.Next(0, 1000);
        }

        private string AddZeros(int number)
        {
            if (number < 10)
            {
                return "00" + number.ToString();
            }
            else if (number < 100)
            {
                return "0" + number.ToString();
            }
            else
            {
                return number.ToString();
            }
        }

        private string GetDescription()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 10);
            return descriptions[randomNumber];
        }



        private string[] SetDescriptions()
        {
            // Descriptions Attribution
            // Link: https://snicket.fandom.com/wiki/Dewey_Decimal_System?file=Screen_Shot_2019-01-23_at_10.13.11_PM.png
            descriptions = new string[]
            {
                "How do we organize information?",
                "Who am I?",
                "How did we get here?",
                "Who are the people around me?",
                "How can I communicate with others?",
                "How can I explain the world around me?",
                "How can I control the world around me?",
                "How can I enjoy my free time?",
                "What are the stories of our lives?",
                "What was the world like in the past? What is it like now?",
            };

            return descriptions;
        }
    }

}