using LMS_Management.FindingCallNumbers;

namespace LMS.Models
{
    public class FindingCallNumbers
    {
        public string Question { get; set; }
        public List<Pair> FirstLevel { get; set; }
        public List<Pair> SecondLevel { get; set; }
        public List<Pair> ThirdLevel { get; set; }

        public void SortLevels()
        {
            FirstLevel = FirstLevel.OrderBy(pair => pair.Number).ToList();
            SecondLevel = SecondLevel.OrderBy(pair => pair.Number).ToList();
            ThirdLevel = ThirdLevel.OrderBy(pair => pair.Number).ToList();
        }
    }
}
