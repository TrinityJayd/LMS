namespace LMS_Management.IdentifyingAreas
{
    public class IdentifyingAreas
    {
        private Dictionary<string, string> areas;
        private string[] extras;
        private Dictionary<string, string> descriptions;
        private const int MAX_ITEMS = 4;
        private const int EXTRAS = 3;

        public Dictionary<string, string> GenerateAreas(string mode)
        {
            //Set the descriptions
            SetKeysAndDescriptions();

            areas = new Dictionary<string, string>();
            extras = new string[EXTRAS];

            while (areas.Count < MAX_ITEMS)
            {
                int randomIndex = new Random().Next(descriptions.Count);

                //Get a random pair
                var randomPair = descriptions.ElementAt(randomIndex);

                //If the pair has not been used yet, add it
                if (!areas.ContainsKey(randomPair.Key))
                {                 
                    areas.Add(randomPair.Key, randomPair.Value);
                }

            }

            //Depending on the game mode the extras will be different
            if (mode == "Call Numbers to Description")
            {
                //If the user is matching call numbers to descriptions there will be extra descriptions
                int count = 0;
                while (count < EXTRAS)
                {
                    int randomIndex = new Random().Next(descriptions.Count);

                    var randomPair = descriptions.ElementAt(randomIndex);

                    //If the description is not already in the dictionary then add it to the extras
                    if (!areas.ContainsValue(randomPair.Value))
                    {
                        //Check if the extras array has this description
                        if (!extras.Contains(randomPair.Value)) {
                            extras[count] = randomPair.Value;
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
                    int randomIndex = new Random().Next(descriptions.Count);

                    var randomPair = descriptions.ElementAt(randomIndex);

                    //If the pair has not been used yet, add it to the extras
                    if (!areas.ContainsKey(randomPair.Key))
                    {
                        if (!extras.Contains(randomPair.Key))
                        {
                            extras[count] = randomPair.Key;
                            count++;
                        }                      
                    }
                }
            }

            return areas;
        }

        public string[] GetExtras()
        {
            return extras;
        }

       

        private Dictionary<string, string> SetKeysAndDescriptions()
        {
            // Descriptions Attribution
            // Link: https://snicket.fandom.com/wiki/Dewey_Decimal_System?file=Screen_Shot_2019-01-23_at_10.13.11_PM.png
            descriptions = new Dictionary<string, string>
            {
                { "000", "How do we organize information?" },
                { "100", "Who am I?" },
                { "200", "How did we get here?" },
                { "300", "Who are the people around me?" },
                { "400", "How can I communicate with others?" },
                { "500", "How can I explain the world around me?" },
                { "600", "How can I control the world around me?" },
                { "700", "How can I enjoy my free time?" },
                { "800", "What are the stories of our lives?" },
                { "900", "What was the world like in the past? What is it like now?" }
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

        public bool CheckUserDictionary(Dictionary<string, string> correctAreas, Dictionary<string, string> userAreas)
        {
            // Code Attribution
            // Link: https://www.tutorialspoint.com/check-if-two-dictionary-objects-are-equal-in-chash#:~:text=In%20C%23%2C%20you%20can%20check,order%20of%20key%2Dvalue%20pairs.
            return correctAreas.OrderBy(x => x.Key).SequenceEqual(userAreas.OrderBy(x => x.Key));
        }
    }

}