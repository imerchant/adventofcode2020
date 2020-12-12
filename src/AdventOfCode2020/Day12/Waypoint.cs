using System;

namespace AdventOfCode2020.Day12
{
    public class Waypoint
    {
        public int RelativeX { get; private set; }
        public int RelativeY { get; private set; }

        public Waypoint()
        {
            Reset();
        }

        public void Reset()
        {
            RelativeX = 10;
            RelativeY = 1;
        }

        public void Move(Direction direction, int value)
        {
            RelativeX = direction switch
            {
                Direction.E => RelativeX + value,
                Direction.W => RelativeX - value,
                _ => RelativeX
            };

            RelativeY = direction switch
            {
                Direction.N => RelativeY + value,
                Direction.S => RelativeY - value,
                _ => RelativeY
            };
        }

        public void Rotate(Direction direction, int rotation)
        {
            do
            {
                (RelativeX, RelativeY) = direction switch
                {
                    Direction.R => (RelativeY, -RelativeX),
                    Direction.L => (-RelativeY, RelativeX),
                    _ => throw new Exception("trying to rotate waypoint in an invalid direction")
                };
                rotation -= 90;
            } while (rotation > 0);
        }
    }
}