using System.Collections.Generic;

namespace Pelicari.AoC._2020.Repositories
{
    public interface ICommandRepository
    {
        IEnumerable<(string command, int value)> Compile();
    }
}