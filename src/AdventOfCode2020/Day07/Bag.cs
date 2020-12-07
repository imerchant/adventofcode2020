using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day07
{
    public class Bag
    {
        public string Description { get; }

        public List<(Bag Bag, int Count)> Contains { get; }

        public List<Bag> ContainedBy { get; }

        public Bag(string description)
        {
            Description = description;
            Contains = new List<(Bag, int)>();
            ContainedBy = new List<Bag>();
        }

        public int CountChildren()
        {
            return 1 + Contains.Sum(child => child.Count * child.Bag.CountChildren());
        }

        public override int GetHashCode() => Description.GetHashCode();
        public override bool Equals(object obj) => obj is Bag bag && bag.Description == Description;
        public override string ToString() => Description;
    }
}