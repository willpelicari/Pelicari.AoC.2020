namespace Pelicari.AoC._2020.Services
{
    public interface IHandheldDebuggerService
    {
        int GetLastValueFromAccumulator(bool autoSolveInfiniteLoop);
    }
}