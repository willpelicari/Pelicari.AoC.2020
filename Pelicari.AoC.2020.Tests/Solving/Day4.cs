using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;
using System;
using System.Numerics;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day4
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 4;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IPassportValidationService, PassportValidationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day4_Puzzle1()
        {
            //Arrange
            var input = _serviceProvider.GetService<IInputsRepository>().GetBatch(_challengeDay, _puzzleNumber);
            var passportValidationService = _serviceProvider.GetService<IPassportValidationService>();

            //Act
            var result = passportValidationService.CountValidPassports(input, completeValidation: false);

            //Assert
            result.Should().Be(228);
        }

        [TestMethod]
        public void Day4_Puzzle2()
        {
            //Arrange
            var input = _serviceProvider.GetService<IInputsRepository>().GetBatch(_challengeDay, _puzzleNumber);
            var passportValidationService = _serviceProvider.GetService<IPassportValidationService>();

            //Act
            var result = passportValidationService.CountValidPassports(input);

            //Assert
            result.Should().Be(175);
        }
    }
}
