
using Microsoft.Extensions.Logging;
using TheMutantsAtTable9.Models;
using System;
namespace TheMutantsAtTable9.Data

{
    public class QuestionData
    {
        static private Dictionary<int, Question> Questions = new Dictionary<int, Question>();

        // GetAll
        public static IEnumerable<Question> GetAll()
        {
            return Questions.Values;
        }

        // Add
        public static void Add(Question newQuestion)
        {
            Questions.Add(newQuestion.Id, newQuestion);
        }

        // Remove
        public static void Remove(int id)
        {
            Questions.Remove(id);
        }

        // GetById
        public static Question GetById(int id)
        {
            return Questions[id];
        }
    }
}