using Pelicari.AoC._2020.Entities;

namespace Pelicari.AoC._2020.Services
{
    public interface IPasswordPolicyValidationService
    {
        int CountNumberOfValidPasswords(PolicyType policyType);
        Policy ParsePolicy(string stringPolicy);
        bool ValidatePassword(PolicyType policyType, Policy policy);
    }
}