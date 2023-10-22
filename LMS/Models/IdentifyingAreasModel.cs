namespace LMS.Models
{
    public class IdentifyingAreasModel
    {
        public Dictionary<string, string> Areas { get; set; }
        public string[] Extras { get; set; }
        public string Mode { get; set; }

        public List<string> ShuffledKeys { get; set; }

        public List<string> ShuffledValues { get; set; }

    }
}
