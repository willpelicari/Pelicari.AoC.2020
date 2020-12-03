using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Config;
using Pelicari.AoC._2020.Repositories;
using Pelicari.AoC._2020.Services;

namespace Pelicari.AoC._2019.Tests.Solving
{
    [TestClass]
    public class Day1
    {
        private ServiceProvider _serviceProvider;

        [TestInitialize]
        public void OnInitialize()
        {
            var services = new ServiceCollection();

            services.AddScoped<IInputsRepository, InputsRepository>();
            services.AddScoped<IExpenseReportService, ExpenseReportService>();
            services.AddScoped<IDay, _2020.Config.Days.Day1>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Day1_Puzzle1()
        {
            //Arrange
            var expenseReportService = _serviceProvider.GetService<IExpenseReportService>();

            //Act
            var result = expenseReportService.MultiplyAddends(numberOfAddends: 2);

            //Assert
            result.Should().Be(181044);
        }

        [TestMethod]
        public void Day1_Puzzle2()
        {
            //Arrange
            var expenseReportService = _serviceProvider.GetService<IExpenseReportService>();

            //Act
            var result = expenseReportService.MultiplyAddends(numberOfAddends: 3);

            //Assert
            result.Should().Be(82660352);
        }
    }
}
