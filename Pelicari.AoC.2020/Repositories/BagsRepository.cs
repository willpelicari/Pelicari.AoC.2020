using Pelicari.AoC._2020.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pelicari.AoC._2020.Repositories
{
    public class BagsRepository : IBagsRepository
    {
        private IInputsRepository _inputsRepository;

        public BagsRepository(IInputsRepository inputsRepository)
        {
            _inputsRepository = inputsRepository;
        }

        public IEnumerable<Bag> ParseBags()
        {
            var bags = new List<Bag>();
            var inputBags = _inputsRepository.GetInputs(7, 1); //Remove hardcode
            foreach (var input in inputBags)
                bags.Add(ParseRules(input));
            return bags;
        }

        private Bag ParseRules(string input)
        {
            var bag = new Bag();
            var ruleParts = input.ToLower().Split("contain");

            bag.Quantity = 1;
            bag.Color = TrimBags(ruleParts[0]);
            bag.Content = new List<Bag>();
            var numberPattern = @"[0-9]+";
            foreach (var inputBag in ruleParts[1].Split(","))
            {
                if (inputBag.Trim() == "no other bags.") continue;
                var bagObj = new Bag();
                var regex = Regex.Match(inputBag, numberPattern);
                bagObj.Quantity = int.Parse(regex.Value.Trim());
                bagObj.Color = TrimBags(inputBag.Replace(regex.Value, ""));
                bag.Content.Add(bagObj);
            }
            return bag;
        }

        private string TrimBags(string color)
        {
            return color
                .Replace("bags.", "")
                .Replace("bags", "")
                .Replace("bag.", "")
                .Replace("bag", "")
                .Trim();
        }
    }
}
