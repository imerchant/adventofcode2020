﻿namespace AdventOfCode2020.Day17
{
    public class Cube3
    {
        public (int X, int Y, int Z) Location { get; }
        
        public bool IsActive { get; private set; }
        public bool WillBeActive { get; set; }

        public Cube3((int X, int Y, int Z) location, bool isActive = false)
        {
            Location = location;
            IsActive = WillBeActive = isActive;
        }

        public Cube3 WillBe(bool willBe)
        {
            WillBeActive = willBe;
            return this;
        }

        public void Commit() => IsActive = WillBeActive;

        public override string ToString() => $"({Location.X}, {Location.Y}, {Location.Z}) {(IsActive ? '#' : '.')}";
    }
}