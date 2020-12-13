using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020.Day13
{
    public class BusSequence
    {
        public List<string> RawIds { get; }

        public BusSequence(List<string> rawIds)
        {
            RawIds = rawIds;
        }

        public BigInteger FindTimestampWhereBusesLeaveInSequence()
        {
            var offsets = new List<(int BusId, int Offset)>();
            for (var k = 0; k < RawIds.Count; ++k)
            {
                if (int.TryParse(RawIds[k], out var value))
                {
                    offsets.Add((value, k));
                }
            }

            var n = offsets.Select(x => x.BusId).ToArray();
            var a = offsets.Select(x => x.BusId - x.Offset).ToArray();

            return ChineseRemainderTheorem.Solve(n, a); // well, I didn't know this math concept, thank you r/adventofcode for telling me about it
        }
    }
}