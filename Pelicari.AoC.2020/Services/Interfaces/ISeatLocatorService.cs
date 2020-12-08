using System.Numerics;

namespace Pelicari.AoC._2020.Services
{
    public interface ISeatLocatorService
    {
        int BinaryPartitioning(string binaryEntry, char lowerHalfSymbol, char upperHalfSymbol, (int start, int end) range);
        int FindSeatId(string seatSpecification);
    }
}