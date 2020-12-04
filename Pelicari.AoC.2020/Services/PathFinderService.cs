using Pelicari.AoC._2020.Entities;
using System.Collections.Generic;

namespace Pelicari.AoC._2020.Services
{
    public class PathFinderService : IPathFinderService
    {
        public char[][] ParseMapPattern(IEnumerable<string> fileLines)
        {
            var mapPattern = new List<char[]>();
            foreach (var line in fileLines)
            {
                var axisX = new List<char>();
                foreach (var symbol in line)
                    axisX.Add(symbol);
                mapPattern.Add(axisX.ToArray());
            }
            return mapPattern.ToArray();
        }

        public char MoveToboggan(char[][] mapPattern, Toboggan toboggan, int offsetX, int offsetY)
        {
            toboggan.X += offsetX;
            if (toboggan.X > mapPattern[toboggan.Y].Length - 1)
                toboggan.X -= mapPattern[toboggan.Y].Length;

            toboggan.Y += offsetY;
            if (toboggan.Y > mapPattern.Length - 1)
                toboggan.Y -= mapPattern.Length;

            return mapPattern[toboggan.Y][toboggan.X];
        }

        public int CountSymbols(IEnumerable<string> inputs, Toboggan toboggan, int offsetX, int offsetY, char symbol)
        {
            int count = 0;
            var mapPattern = ParseMapPattern(inputs);

            while (toboggan.Y < mapPattern.Length - 1)
            {
                var foundSymbol = MoveToboggan(mapPattern, toboggan, offsetX, offsetY);
                if (foundSymbol == symbol)
                    count++;
            }

            return count;
        }
    }
}
