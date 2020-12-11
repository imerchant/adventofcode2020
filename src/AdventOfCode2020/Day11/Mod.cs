namespace AdventOfCode2020.Day11
{
    public readonly struct Mod
    {
        public int Row { get; }
        public int Col { get; }

        public Mod(int row, int col) => (Row, Col) = (row, col);
    }
}