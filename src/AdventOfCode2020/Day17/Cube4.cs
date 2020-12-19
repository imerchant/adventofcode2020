namespace AdventOfCode2020.Day17
{
    public class Cube4
    {
        public (int X, int Y, int Z, int W) Location { get; }

        public bool IsActive { get; private set; }
        public bool WillBeActive { get; set; }

        public Cube4((int X, int Y, int Z, int W) location, bool isActive = false)
        {
            Location = location;
            IsActive = WillBeActive = isActive;
        }

        public Cube4 WillBe(bool willBe)
        {
            WillBeActive = willBe;
            return this;
        }

        public void Commit() => IsActive = WillBeActive;

        public override string ToString() => $"({Location.X}, {Location.Y}, {Location.Z}, {Location.W}) {(IsActive ? '#' : '.')}";
    }
}