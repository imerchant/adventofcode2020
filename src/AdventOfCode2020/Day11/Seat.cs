namespace AdventOfCode2020.Day11
{
    public class Seat : ISpot
    {
        private const string Occupied = "#";
        private const string NotOccupied = "L";

        public int Row { get; }
        public int Col { get; }
        public bool IsOccupied { get; private set; }
        public bool WillBeOccupied { get; set; }

        public Seat(in int row, in int col)
        {
            Row = row;
            Col = col;
        }

        public void Commit() => IsOccupied = WillBeOccupied;

        public override string ToString() => IsOccupied ? Occupied : NotOccupied;
    }
}