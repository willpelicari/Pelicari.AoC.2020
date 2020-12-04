using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Services
{
    [TestClass]
    public class PasswordPolicyValidatorServiceTests
    {
        private PasswordPolicyValidationService _passwordPolicyValidationService;

        [TestInitialize]
        public void OnInitialize()
        {
            _passwordPolicyValidationService = new PasswordPolicyValidationService();
        }

        [TestMethod]
        public void ParsePolicy_WhenStringIsReceived_ThenReturnMappedPolicy()
        {
            //Arrange
            var stringPolicy = "1-3 a: abcde";

            //Act
            var result = _passwordPolicyValidationService.ParsePolicy(stringPolicy);

            //Assert
            result.Should().NotBeNull();
            result.FirstNumber.Should().Be(1);
            result.SecondNumber.Should().Be(3);
            result.RequiredCharacter.Should().Be('a');
            result.Password.Should().Be("abcde");
        }

        [TestMethod]
        public void ValidatePassword_WhenSledRentalPolicyAndPasswordIsValidByPolicy_ThenReturnTrue()
        {
            //Arrange
            var policyType = PolicyType.SledRental;
            var policy = new Policy()
            {
                FirstNumber = 1,
                SecondNumber = 3,
                RequiredCharacter = 'a',
                Password = "abcde"
            };

            //Act
            var result = _passwordPolicyValidationService.ValidatePassword(policyType, policy);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ValidatePassword_WhenSledRentalPolicyAndPasswordIsInvalidByPolicy_ThenReturnFalse()
        {
            //Arrange
            var policyType = PolicyType.SledRental;
            var policy = new Policy()
            {
                FirstNumber = 1,
                SecondNumber = 3,
                RequiredCharacter = 'b',
                Password = "cdefg"
            };

            //Act
            var result = _passwordPolicyValidationService.ValidatePassword(policyType, policy);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ValidatePassword_WhenNorthPoleTobogganPolicyAndPasswordIsValidByPolicy_ThenReturnTrue()
        {
            //Arrange
            var policyType = PolicyType.NorthPoleToboggan;
            var policy = new Policy()
            {
                FirstNumber = 1,
                SecondNumber = 3,
                RequiredCharacter = 'a',
                Password = "abcde"
            };

            //Act
            var result = _passwordPolicyValidationService.ValidatePassword(policyType, policy);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ValidatePassword_WhenNorthPoleTobogganPolicyAndPasswordIsInvalidByPolicy_ThenReturnFalse()
        {
            //Arrange
            var policyType = PolicyType.NorthPoleToboggan;
            var policy = new Policy()
            {
                FirstNumber = 1,
                SecondNumber = 3,
                RequiredCharacter = 'c',
                Password = "ccccccccc"
            };

            //Act
            var result = _passwordPolicyValidationService.ValidatePassword(policyType, policy);

            //Assert
            result.Should().BeFalse();
        }
    }
}
