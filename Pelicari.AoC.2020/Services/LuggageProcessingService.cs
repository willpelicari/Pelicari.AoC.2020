using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class LuggageProcessingService : ILuggageProcessingService
    {
        private IBagsRepository _bagsRepository;

        public LuggageProcessingService(IBagsRepository bagsRepository)
        {
            _bagsRepository = bagsRepository;
        }

        public int CountBagContainers(string givenBagColor)
        {
            var bags = _bagsRepository.ParseBags().ToList();
            var outermostBags = bags.Where(br => br.Content.Any(b => b.Color == givenBagColor)).ToList();

            List<Bag> newBagsFound;
            do
            {
                newBagsFound = new List<Bag>();
                foreach (var outermostBag in outermostBags)
                    foreach (var bag in bags.Except(outermostBags))
                        if (bag.Content.Any(b => b.Color == outermostBag.Color))
                            newBagsFound.Add(bag);
                outermostBags.AddRange(newBagsFound);
            } while (newBagsFound.Count > 0);

            return outermostBags.Select(b => b.Color).Distinct().Count();
        }

        public int CountExtraLuggages(string givenBagColor)
        {
            var bags = _bagsRepository.ParseBags().ToList();
            var givenBag = bags.FirstOrDefault(b => b.Color == givenBagColor);
            var totalBags = new List<Bag>();

            return CountInnerBags(bags, givenBag.Content);
        }

        public int CountInnerBags(List<Bag> bagRules, IEnumerable<Bag> innerBags)
        {
            if (innerBags == null)
                return 0;

            var total = 0;
            foreach (var innerBag in innerBags)
            {
                innerBag.Content = bagRules.FirstOrDefault(b => b.Color == innerBag.Color)?.Content;
                total += innerBag.Quantity + innerBag.Quantity * CountInnerBags(bagRules, innerBag.Content);
            }

            return total;
        }
    }
}
