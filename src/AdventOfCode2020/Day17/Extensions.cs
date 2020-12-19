namespace AdventOfCode2020.Day17
{
    public static class Extensions
    {
        public static (int X, int Y, int Z) Add(this (int X, int Y, int Z) location, (int X, int Y, int Z) mod)
        {
            return (location.X + mod.X, location.Y + mod.Y, location.Z + mod.Z);
        }

        public static (int X, int Y, int Z, int W) Add(this (int X, int Y, int Z, int W) location, (int X, int Y, int Z, int W) mod)
        {
            return (location.X + mod.X, location.Y + mod.Y, location.Z + mod.Z, location.W + mod.W);
        }
    }
}