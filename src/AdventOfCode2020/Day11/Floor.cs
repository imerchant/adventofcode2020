namespace AdventOfCode2020.Day11
{
    public class Floor : ISpot
    {
        private const string _floor = ".";

        public bool IsOccupied { get; } = false;

        public override string ToString() => _floor;
    }
}