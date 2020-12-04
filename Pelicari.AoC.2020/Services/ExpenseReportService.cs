using Pelicari.AoC._2020.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class ExpenseReportService : IExpenseReportService
    {
        public IEnumerable<int> FindAddendsOfYear(IEnumerable<int> inputs, int numberOfAddends)
        {
            switch (numberOfAddends)
            {
                case 2:
                    return FindTwoAddends(inputs);
                case 3:
                    return FindThreeAddends(inputs);
                default:
                    throw new NotImplementedException();
            }
        }

        private List<int> FindTwoAddends(IEnumerable<int> inputs, int year = 2020)
        {
            List<int> foundAddends = new List<int>();

            foreach (var firstAddend in inputs)
            {
                var secondAddend = inputs.FirstOrDefault(i => i + firstAddend == year);
                if (secondAddend != default)
                {
                    foundAddends.AddRange(new[] { firstAddend, secondAddend });
                    return foundAddends;
                }
            }

            return null;
        }

        private List<int> FindThreeAddends(IEnumerable<int> inputs)
        {
            List<int> foundAddends = new List<int>();
            foreach (var firstAddend in inputs)
            {
                var maxSumAllowed = 2020 - firstAddend;
                var secondAndThirdAddends = FindTwoAddends(inputs.Where(i => i != firstAddend), maxSumAllowed);
                if (secondAndThirdAddends?.Count == 2)
                {
                    foundAddends.Add(firstAddend);
                    foundAddends.AddRange(secondAndThirdAddends);
                    return foundAddends;
                }
            }

            return null;
        }

        public int MultiplyAddends(IEnumerable<string> inputs, int numberOfAddends)
        {
            var intInputs = inputs.Select(int.Parse).ToArray();
            int[] addends;
            switch (numberOfAddends)
            {
                case 2:
                    addends = FindAddendsOfYear(intInputs, numberOfAddends).ToArray();
                    return addends[0] * addends[1];
                case 3:
                    addends = FindAddendsOfYear(intInputs, numberOfAddends).ToArray();
                    return addends[0] * addends[1] * addends[2];
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
