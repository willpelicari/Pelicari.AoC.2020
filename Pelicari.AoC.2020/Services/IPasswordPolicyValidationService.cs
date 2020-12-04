using Pelicari.AoC._2020.Entities;
using System.Collections.Generic;

namespace Pelicari.AoC._2020.Services
{
    public interface IPasswordPolicyValidationService
    {
        int CountNumberOfValidPasswords(IEnumerable<string> inputs, PolicyType policyType);
        Policy ParsePolicy(string stringPolicy);
        bool ValidatePassword(PolicyType policyType, Policy policy);
    }
}