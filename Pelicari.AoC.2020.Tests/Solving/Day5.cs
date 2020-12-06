using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Entities;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day5
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 5;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<ISeatLocatorService, SeatLocatorService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day4_Puzzle1()
        {
            //Arrange
            var input = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var seatLocatorService = _serviceProvider.GetService<ISeatLocatorService>();

            //Act
            int biggestId = 0;
            foreach (var seatSpecification in input)
            {
                var result = seatLocatorService.FindSeatId(seatSpecification);
                if (result > biggestId)
                    biggestId = result;
            }

            //Assert
            biggestId.Should().Be(882);
        }

        [TestMethod]
        public void Day4_Puzzle2()
        {
            //Arrange
            var input = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var seatLocatorService = _serviceProvider.GetService<ISeatLocatorService>();

            //Act
            var results = new List<int>();
            foreach (var seatSpecification in input)
            {
                results.Add(seatLocatorService.FindSeatId(seatSpecification));
            }
            var orderedResults = results.OrderBy(i => i).ToArray();

            int mySeat = 0;
            for (int i = 1; i < orderedResults.Count(); i++)
            {
                if (orderedResults[i] - orderedResults[i - 1] > 1)
                {
                    mySeat = orderedResults[i - 1] + 1;
                    continue;
                }
            }

            //Assert
            mySeat.Should().Be(705);
        }
    }
}
