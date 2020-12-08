using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day7
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 7;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IBagsRepository, BagsRepository>();
            services.AddScoped<ILuggageProcessingService, LuggageProcessingService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day7_Puzzle1()
        {
            //Arrange
            var luggageProcessingService = _serviceProvider.GetService<ILuggageProcessingService>();

            //Act
            var result = luggageProcessingService.CountBagContainers("shiny gold");

            //Assert
            result.Should().Be(224);
        }

        [TestMethod]
        public void Day7_Puzzle2()
        {
            //Arrange
            var luggageProcessingService = _serviceProvider.GetService<ILuggageProcessingService>();

            //Act
            var result = luggageProcessingService.CountExtraLuggages("shiny gold");

            //Assert
            result.Should().Be(1488);
        }
    }
}
