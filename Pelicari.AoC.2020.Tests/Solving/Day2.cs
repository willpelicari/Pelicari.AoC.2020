using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day2
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 2;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IPasswordPolicyValidationService, PasswordPolicyValidationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day2_Puzzle1()
        {
            //Arrange
            var inputs = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var policyType = PolicyType.SledRental;
            var passwordPolicyValidationService = _serviceProvider.GetService<IPasswordPolicyValidationService>();

            //Act
            var result = passwordPolicyValidationService.CountNumberOfValidPasswords(inputs, policyType);

            //Assert
            result.Should().Be(383);
        }

        [TestMethod]
        public void Day2_Puzzle2()
        {
            //Arrange
            var inputs = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var policyType = PolicyType.NorthPoleToboggan;
            var passwordPolicyValidationService = _serviceProvider.GetService<IPasswordPolicyValidationService>();

            //Act
            var result = passwordPolicyValidationService.CountNumberOfValidPasswords(inputs, policyType);

            //Assert
            result.Should().Be(272);
        }
    }
}
