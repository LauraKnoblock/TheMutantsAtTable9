﻿using Microsoft.Extensions.Logging;

namespace TheMutantsAtTable9.Models
{
    public class Question
    {
        public string Name { get; set; }
        public string Answer { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public Question()
        {
            Id = nextId;
            nextId++;
        }

        public Question(string name, string answer)
        {
            Name = name;
            Answer = answer;
            Id = nextId;
            nextId++;
        }

        public override string ToString()
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
