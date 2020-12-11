using Pelicari.AoC._2020.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class XmasDecryptService : IXmasDecryptService
    {
        private IInputsRepository _inputsRepository;

        public XmasDecryptService(IInputsRepository inputsRepository)
        {
            _inputsRepository = inputsRepository;
        }

        public bool FindWeakPoint(bool considerContiguousSet, int preambleSize, out long weakPoint)
        {
            var inputs = _inputsRepository.GetInputs(9, 1).Select(long.Parse).ToArray();
            (int min, int max) threshold = (0, preambleSize);
            weakPoint = -1;
            while (true)
            {
                if (threshold.max >= inputs.Length)
                    return false;

                bool foundSum = false;
                for (int currentMax = threshold.max - 1; currentMax >= threshold.min + 1; currentMax--)
                {
                    foundSum = HaveSumInGivenInterval(inputs, threshold, inputs[threshold.max]);
                    if (!foundSum)
                    {
                        if (considerContiguousSet)
                        {
                            var foundValue = inputs[threshold.max];
                            var validInputs = inputs.Where(i => i < foundValue).ToList();
                            var contiguousSet = GetContiguousSet(validInputs, foundValue);
                            contiguousSet = contiguousSet.OrderBy(e => e).ToList();
                            weakPoint = contiguousSet.First() + contiguousSet.Last();
                        }
                        else
                            weakPoint = inputs[threshold.max];
                        return true;
                    }
                       
                }
                    
                threshold = (threshold.min + 1, threshold.max + 1);
            }
        }

        private IEnumerable<long> GetContiguousSet(IList<long> validInputs, long foundValue)
        {
            var contiguousSet = new List<long>();
            for (int i = 0; i < validInputs.Count(); i++)
            {
                for (int j = i; j < validInputs.Count(); j++)
                {
                    contiguousSet.Add(validInputs[j]);
                    if (contiguousSet.Sum() == foundValue)
                        return contiguousSet;
                    if (contiguousSet.Sum() > foundValue)
                    {
                        contiguousSet.Clear();
                        break;
                    }
                }
            }
            return null;
        }

        private bool HaveSumInGivenInterval(long[] inputs, (int min, int max) threshold, double targetValue)
        {
            for (int max = threshold.max; max > threshold.min; max--)
                for (int min = threshold.min; min < max; min++)
                {
                    var sum = inputs[min] + inputs[max];
                    if (sum == targetValue)
                        return true;
                }
            return false;
        }

    }
}
