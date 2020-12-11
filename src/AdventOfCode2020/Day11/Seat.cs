namespace AdventOfCode2020.Day11
{
    public class Seat : ISpot
    {
        private const string _occupied = "#";
        private const string _notOccupied = "L";

        public int Row { get; }
        public int Col { get; }
        public Occupied CurrentlyIs { get; private set; } = Occupied.No;
        public Occupied WillBe { get; set; }

        public Seat(in int row, in int col)
        {
            Row = row;
            Col = col;
        }

        public void Commit() => CurrentlyIs = WillBe;

        public override string ToString() => CurrentlyIs switch
        {
            Occupied.Yes => _occupied,
            _ => _notOccupied
        };
    }
}