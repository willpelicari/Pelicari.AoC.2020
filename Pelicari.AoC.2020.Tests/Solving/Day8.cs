using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass]
    public class Day8
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 8;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IHandheldDebuggerService, HandheldDebuggerService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day8_Puzzle1()
        {
            //Arrange
            var handheldDebuggerService = _serviceProvider.GetService<IHandheldDebuggerService>();

            //Act
            var result = handheldDebuggerService.GetLastValueFromAccumulator(autoSolveInfiniteLoop: false);

            //Assert
            result.Should().Be(1331);
        }

        [TestMethod]
        public void Day8_Puzzle2()
        {
            //Arrange
            var handheldDebuggerService = _serviceProvider.GetService<IHandheldDebuggerService>();

            //Act
            var result = handheldDebuggerService.GetLastValueFromAccumulator(autoSolveInfiniteLoop: true);

            //Assert
            result.Should().Be(1121);
        }
    }
}
