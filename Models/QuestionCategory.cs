namespace TheMutantsAtTable9.Models
{
    public class QuestionCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Question> Questions { get; set; }

        public QuestionCategory()
        {
        }

        public QuestionCategory(string name)
        {
            Name = name;
        }
    }
}
