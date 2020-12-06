using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class PollGatheringService : IPollGatheringService
    {
        public int GetPollAnswers(string fileInput)
        {
            var totalYesCounts = new List<int>();
            var pollInputs = fileInput.Split("\r\n\r\n");
            foreach (var group in pollInputs)
            {
                var yesDictGroup = new List<char>();
                var peopleAnswer = group.Split("\r\n");
                foreach (var personAnswer in peopleAnswer)
                    foreach (var answer in personAnswer)
                        yesDictGroup.Add(answer);
                var distinctAnswers = yesDictGroup.Distinct();
                totalYesCounts.Add(distinctAnswers.Count());
            }
            return totalYesCounts.Sum();
        }

        public int GetPollEqualAnswers(string fileInput)
        {
            var totalEqualAnswers = new List<int>();
            var pollInputs = fileInput.Split("\r\n\r\n");
            foreach (var group in pollInputs)
            {
                var peopleAnswerList = new List<char>();
                var peopleAnswer = group.Split("\r\n");
                foreach (var personAnswer in peopleAnswer)
                    foreach (var answer in personAnswer)
                        peopleAnswerList.Add(answer);
                var equalAnswers = peopleAnswerList.GroupBy(
                p => p);
                var equalGroupAnswers = equalAnswers.Where(a => a.Count() == peopleAnswer.Count()).Count();
                totalEqualAnswers.Add(equalGroupAnswers);
            }
            return totalEqualAnswers.Sum();
        }
    }
}
