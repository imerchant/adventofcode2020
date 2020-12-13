using System;
using System.Linq;

namespace AdventOfCode2020.Day13
{
    public class Schedule
    {
        public int Timestamp { get; }
        public int[] Buses { get; }

        public Schedule(int timestamp, int[] buses)
        {
            Timestamp = timestamp;
            Buses = buses;
        }

        public (int BusId, int Timestamp) FindFirstBusToLeave()
        {
            for (int k = Timestamp; k < Timestamp + 10_000; ++k)
            {
                var bus = Buses.FirstOrDefault(x => k % x == 0);

                if (bus != default)
                {
                    return (bus, k);
                }
            }

            throw new Exception("could not locate bus");
        }
    }
}
