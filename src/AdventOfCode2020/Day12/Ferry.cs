using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day12
{
    public class Ferry
    {
        public static readonly Regex Format = new Regex(@"(?'direction'[NESWRLF])(?'value'\d+)", RegexOptions.Compiled);

        public List<(Direction Direction, int Value)> Instructions { get; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Facing { get; private set; }
        public Waypoint Waypoint { get; }

        public int ManhattanDistance => Math.Abs(X) + Math.Abs(Y);

        public Ferry(string input)
        {
            Instructions = Format.Matches(input)
                .Select(match => (
                    match.Groups["direction"].Value.ParseEnum<Direction>(default),
                    int.Parse(match.Groups["value"].Value)))
                .ToList();

            Waypoint = new Waypoint();
        }

        public void FollowInstructions()
        {
            (X, Y, Facing) = (0, 0, Direction.E);

            foreach (var (direction, value) in Instructions)
            {
                switch (direction)
                {
                    case Direction.N:
                    case Direction.E:
                    case Direction.S:
                    case Direction.W:
                        Move(direction, value);
                        break;

                    case Direction.F:
                        Move(Facing, value);
                        break;

                    case Direction.L:
                    case Direction.R:
                        Rotate(direction, value);
                        break;
                }
            }

            static Direction NextRight(Direction facing, int rotation)
            {
                do
                {
                    facing = facing switch
                    {
                        Direction.N => Direction.E,
                        Direction.E => Direction.S,
                        Direction.S => Direction.W,
                        Direction.W => Direction.N,
                        _ => throw new Exception("trying to find next facing with a direction that isn't valid")
                    };

                    rotation -= 90;
                } while (rotation > 0);

                return facing;
            }

            static Direction NextLeft(Direction facing, int rotation)
            {
                do
                {
                    facing = facing switch
                    {
                        Direction.N => Direction.W,
                        Direction.W => Direction.S,
                        Direction.S => Direction.E,
                        Direction.E => Direction.N,
                        _ => throw new Exception("trying to find next facing with a direction that isn't valid")
                    };

                    rotation -= 90;
                } while (rotation > 0);

                return facing;
            }

            void Rotate(Direction direction, int value)
            {
                Facing = direction switch
                {
                    Direction.L => NextLeft(Facing, value),
                    Direction.R => NextRight(Facing, value),
                    _ => throw new Exception("trying to rotate with a direction that isn't valid")
                };
            }
        }

        public void FollowInstructionsWithWaypoint()
        {
            (X, Y, Facing) = (0, 0, Direction.E);
            Waypoint.Reset();

            foreach (var (direction, value) in Instructions)
            {
                switch (direction)
                {
                    case Direction.F:
                        for (var k = 0; k < value; ++k)
                        {
                            Move(Direction.E, Waypoint.RelativeX);
                            Move(Direction.N, Waypoint.RelativeY);
                        }
                        break;

                    case Direction.N:
                    case Direction.E:
                    case Direction.S:
                    case Direction.W:
                        Waypoint.Move(direction, value);
                        break;

                    case Direction.L:
                    case Direction.R:
                        Waypoint.Rotate(direction, value);
                        break;
                }
            }
        }

        private void Move(Direction direction, int value)
        {
            X = direction switch
            {
                Direction.E => X + value,
                Direction.W => X - value,
                _ => X
            };

            Y = direction switch
            {
                Direction.N => Y + value,
                Direction.S => Y - value,
                _ => Y
            };
        }
    }
}
