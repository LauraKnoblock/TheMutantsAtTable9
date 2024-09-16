using Microsoft.Extensions.Logging;

namespace TheMutantsAtTable9.Models
{
    public class Question
    {
        public string? Name { get; set; }
        public string? Answer { get; set; }
        public QuestionCategory Category { get; set; }
        
        public int QuestionId { get; set; }

        public int Id { get; set; }

        public Question()
        {
        }

        public Question(string name, string answer)
        {
            Name = name;
            Answer = answer;
            
        }

        public override string? ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Question @qst && Id == @qst.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
