using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;
using System.Numerics;

namespace Pelicari.AoC._2019.Tests.Solving
{
    [TestClass]
    public class Day3
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 3;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IPathFinderService, PathFinderService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day3_Puzzle1()
        {
            //Arrange
            var toboggan = new Toboggan();
            var inputs = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var pathFinderService = _serviceProvider.GetService<IPathFinderService>();

            //Act
            var result = pathFinderService.CountSymbols(inputs, toboggan, 3, 1, '#');

            //Assert
            result.Should().Be(284);
        }

        [TestMethod]
        public void Day3_Puzzle2()
        {
            //Arrange
            var inputs = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var pathFinderService = _serviceProvider.GetService<IPathFinderService>();

            //Act
            BigInteger slope1 = pathFinderService.CountSymbols(inputs, new Toboggan(), 1, 1, '#');
            BigInteger slope2 = pathFinderService.CountSymbols(inputs, new Toboggan(), 3, 1, '#');
            BigInteger slope3 = pathFinderService.CountSymbols(inputs, new Toboggan(), 5, 1, '#');
            BigInteger slope4 = pathFinderService.CountSymbols(inputs, new Toboggan(), 7, 1, '#');
            BigInteger slope5 = pathFinderService.CountSymbols(inputs, new Toboggan(), 1, 2, '#');
            BigInteger result = slope1 * slope2 * slope3 * slope4 * slope5;

            //Assert
            result.Should().Be(3510149120);
        }
    }
}
