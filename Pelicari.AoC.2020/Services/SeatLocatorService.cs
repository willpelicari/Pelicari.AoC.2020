using System;
using System.Numerics;

namespace Pelicari.AoC._2020.Services
{
    public class SeatLocatorService : ISeatLocatorService
    {
        public int FindSeatId(string seatSpecification)
        {
            var rowSpec = seatSpecification.Substring(0, 7);
            var columnSpec = seatSpecification.Substring(7, 3);

            var row = BinaryPartitioning(rowSpec, 'F', 'B', (start: 0, end: 127));
            var column = BinaryPartitioning(columnSpec, 'L', 'R', (start: 0, end: 7));

            return row * 8 + column;
        }

        public int BinaryPartitioning(string binaryEntry, char lowerHalfSymbol, char upperHalfSymbol, (int start, int end) range)
        {
            foreach (var binary in binaryEntry)
            {
                var partitionSize = range.end - range.start;
                if (binary == lowerHalfSymbol)
                    range = (range.start, range.start + (partitionSize / 2));
                else if (binary == upperHalfSymbol)
                    range = (range.end - (partitionSize / 2), range.end);
                else
                    throw new Exception($"Unexpected symbol {binary} in binary entry {binaryEntry}");
            }

            if (range.start != range.end)
                throw new Exception($"It wasn't possible to determine a unique integer between {range.start} and {range.end} for these parameters.");

            return range.start;
        }
    }
}
