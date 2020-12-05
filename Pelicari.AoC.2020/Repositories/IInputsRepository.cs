using System.Collections.Generic;

namespace Pelicari.AoC._2020.Repositories
{
    public interface IInputsRepository
    {
        public IEnumerable<string> GetInputs(int day, int puzzleNumber);
        public string GetBatch(int day, int puzzleNumber);
    }
}