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
            //Set the descriptions
            SetDescriptions();
            areas = new Dictionary<string, string>();
            extras = new string[EXTRAS];

            //Store the ranges that have already been used to prevent duplicates
            HashSet<int> usedRanges = new HashSet<int>();
            while (areas.Count < MAX_ITEMS)
            {
                int callNumber = GetCallNumber();
                int range = callNumber / 100;

                //If the range has not been used yet, add it
                if (!usedRanges.Contains(range))
                {
                    SetKeysAndValues(callNumber);
                    usedRanges.Add(range);
                }

            }

            //Depending on the game mode the extras will be different
            if (mode == "Call Numbers to Description")
            {
                //If the user is matching call numbers to descriptions there will be extra descriptions
                int count = 0;
                while (count < EXTRAS)
                {
                    var random = new Random();
                    int randPosition = random.Next(0, 10);

                    string description = descriptions[randPosition];

                    //If the description is not already in the dictionary then add it to the extras
                    if (!areas.ContainsValue(description))
                    {

                        //Check if the extras array has this description
                        if (!extras.Contains(description)) {
                            extras[count] = description;
                            count++;
                        }
                            
                    }
                }
            }
            else if (mode == "Descriptions to Call Numbers")
            {
                //If the user is matching descriptions to call numbers there will be extra call numbers
                int count = 0;
                while (count < EXTRAS)
                {
                    int callNumber = GetCallNumber();
                    int range = callNumber / 100;

                    //If the range has not been used yet, add it to the extras
                    if (!usedRanges.Contains(range))
                    {
                        extras[count] = AddZeros(callNumber);
                        usedRanges.Add(range);
                    }
                }
            }

            return areas;
        }

        public string[] GetExtras()
        {
            return extras;
        }

        private void SetKeysAndValues(int callNumber)
        {
            //Set the keys and values based on the call number range
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

        public Dictionary<string, string> GameLevelDescription()
        {
            //create a dictionary where the key is the level name and the description is the value
            Dictionary<string, string> levels = new Dictionary<string, string>
            {
                { "Beginner", "Match the call numbers and descriptions without a timer." },
                { "Intermediate", "Match the call numbers and descriptions within 40 seconds." },
                { "Challenger", "Match the call numbers and descriptions within 35 seconds." },
                { "Expert", "Master matching the call numbers and descriptions within 25 seconds." }

            };

            return levels;
        }
    }

}