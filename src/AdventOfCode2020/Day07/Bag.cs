using System.Collections.Generic;

namespace AdventOfCode2020.Day07
{
    public class Bag
    {
        public string Description { get; }

        public List<Bag> Contains { get; }

        public List<Bag> ContainedBy { get; }

        public Bag(string description)
        {
            Description = description;
            Contains = new List<Bag>();
            ContainedBy = new List<Bag>();
        }

        public override int GetHashCode() => Description.GetHashCode();
        public override bool Equals(object? obj) => obj is Bag bag && bag.Description == Description;
        public override string ToString() => Description;
    }
}