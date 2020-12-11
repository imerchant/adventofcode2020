namespace AdventOfCode2020.Day11
{
    public class Floor : ISpot
    {
        private const string _floor = ".";

        public Occupied CurrentlyIs { get; } = Occupied.No;

        public override string ToString() => _floor;
    }
}