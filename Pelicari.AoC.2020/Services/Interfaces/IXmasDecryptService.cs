namespace Pelicari.AoC._2020.Services
{
    public interface IXmasDecryptService
    {
        bool FindWeakPoint(bool considerContiguousSet, int preambleSize, out long weakPoint);
    }
}