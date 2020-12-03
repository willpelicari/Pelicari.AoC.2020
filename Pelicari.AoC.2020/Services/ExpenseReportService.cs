using Pelicari.AoC._2020.Config;
using Pelicari.AoC._2020.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class ExpenseReportService : IExpenseReportService
    {
        private IInputsRepository _inputsRepository;
        private int _challengeDay;
        private int _puzzleNumber;

        public ExpenseReportService(IInputsRepository inputsRepository, IDay dayConfig)
        {
            _inputsRepository = inputsRepository;
            _challengeDay = dayConfig.ChallengeDay;
            _puzzleNumber = dayConfig.PuzzleNumber;
        }

        public IEnumerable<int> FindAddendsOfYear(int numberOfAddends)
        {
            var inputs = _inputsRepository.GetInputs(_challengeDay, _puzzleNumber).Select(int.Parse).ToArray();
            List<int> foundAddends = new List<int>();
            switch (numberOfAddends)
            {
                case 2:
                    foundAddends = FindTwoAddends(inputs);
                    break;
                case 3:
                    foundAddends = FindThreeAddends(inputs);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return foundAddends;
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

        private List<int> FindThreeAddends(int[] inputs)
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

        public int MultiplyAddends(int numberOfAddends)
        {
            int[] addends;
            switch (numberOfAddends)
            {
                case 2:
                    addends = FindAddendsOfYear(numberOfAddends).ToArray();
                    return addends[0] * addends[1];
                case 3:
                    addends = FindAddendsOfYear(numberOfAddends).ToArray();
                    return addends[0] * addends[1] * addends[2];
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
