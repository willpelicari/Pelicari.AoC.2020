using Pelicari.AoC._2020.Entities;
using System.Collections.Generic;

namespace Pelicari.AoC._2020.Services
{
    public interface IPathFinderService
    {
        int CountSymbols(IEnumerable<string> fileInputs, Toboggan toboggan, int offsetX, int offsetY, char symbol);
        char MoveToboggan(char[][] mapPattern, Toboggan toboggan, int offsetX, int offsetY);
        char[][] ParseMapPattern(IEnumerable<string> fileLines);
    }
}