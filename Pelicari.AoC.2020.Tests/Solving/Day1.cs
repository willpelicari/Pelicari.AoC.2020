using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2020.Tests.Solving
{
    [TestClass, ]
    public class Day1
    {
        private ServiceProvider _serviceProvider;
        private int _challengeDay = 1;
        private int _puzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IExpenseReportService, ExpenseReportService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day1_Puzzle1()
        {
            //Arrange
            var inputs = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var expenseReportService = _serviceProvider.GetService<IExpenseReportService>();

            //Act
            var result = expenseReportService.MultiplyAddends(inputs, numberOfAddends: 2);

            //Assert
            result.Should().Be(181044);
        }

        [TestMethod]
        public void Day1_Puzzle2()
        {
            //Arrange
            var inputs = _serviceProvider.GetService<IInputsRepository>().GetInputs(_challengeDay, _puzzleNumber);
            var expenseReportService = _serviceProvider.GetService<IExpenseReportService>();

            //Act
            var result = expenseReportService.MultiplyAddends(inputs, numberOfAddends: 3);

            //Assert
            result.Should().Be(82660352);
        }
    }
}
