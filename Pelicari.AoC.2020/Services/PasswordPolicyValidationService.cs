using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Services
{
    public class PasswordPolicyValidationService : IPasswordPolicyValidationService
    {
        public int CountNumberOfValidPasswords(IEnumerable<string> inputs, PolicyType policyType)
        {
            var policies = inputs.Select(i => ParsePolicy(i));
            return policies.Count(p => ValidatePassword(policyType, p));
        }

        public Policy ParsePolicy(string stringPolicy)
        {
            var splittedBySpace = stringPolicy.Split(" ");
            var password = splittedBySpace.Last().Trim();
            var requiredCharacter = splittedBySpace.ElementAt(1).Trim(':').FirstOrDefault();
            var splittedByDash = splittedBySpace.First().Split("-").Select(int.Parse).ToArray();

            var firstNumber = splittedByDash.First();
            var secondNumber = splittedByDash.Last();

            return new Policy()
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                RequiredCharacter = requiredCharacter,
                Password = password
            };
        }

        public bool ValidatePassword(PolicyType policyType, Policy policy)
        {
            switch (policyType)
            {
                case PolicyType.SledRental:
                    var numberOfAppearances = policy.Password.Count(c => c == policy.RequiredCharacter);
                    return numberOfAppearances >= policy.FirstNumber && numberOfAppearances <= policy.SecondNumber;
                case PolicyType.NorthPoleToboggan:
                    var requiredCharacterOnFirstIndex = policy.Password[policy.FirstNumber-1] == policy.RequiredCharacter;
                    var requiredCharacterOnSecondIndex = policy.Password[policy.SecondNumber - 1] == policy.RequiredCharacter;
                    return (requiredCharacterOnFirstIndex && !requiredCharacterOnSecondIndex) || (!requiredCharacterOnFirstIndex && requiredCharacterOnSecondIndex);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
