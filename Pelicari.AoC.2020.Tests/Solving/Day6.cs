using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day6
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 6;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IPollGatheringService, PollGatheringService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day6_Puzzle1()
        {
            //Arrange
            var input = _serviceProvider.GetService<IInputsRepository>().GetBatch(_challengeDay, _puzzleNumber);
            var pollGatheringService = _serviceProvider.GetService<IPollGatheringService>();

            //Act
            var result = pollGatheringService.GetPollAnswers(input);

            //Assert
            result.Should().Be(6714);
        }

        [TestMethod]
        public void Day6_Puzzle2()
        {
            //Arrange
            var input = _serviceProvider.GetService<IInputsRepository>().GetBatch(_challengeDay, _puzzleNumber);
            var pollGatheringService = _serviceProvider.GetService<IPollGatheringService>();

            //Act
            var result = pollGatheringService.GetPollEqualAnswers(input);

            //Assert
            result.Should().Be(3435);
        }
    }
}
