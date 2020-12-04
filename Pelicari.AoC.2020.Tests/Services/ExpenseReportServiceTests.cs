using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2020.Services;
using System.Collections.Generic;

namespace Pelicari.AoC._2020.Tests.Services
{
    [TestClass]
    public class ExpenseReportServiceTests
    {
        private ExpenseReportService _expenseReportService;

        [TestInitialize]
        public void OnInitialize()
        {
            _expenseReportService = new ExpenseReportService();
        }

        [DataTestMethod, DataRow(new[] { 1721, 979, 366, 299, 675, 1456 })]
        public void FindAddendsOfYear_WhenAskedForTwoAddends_ThenTwoCorrectAddendsAreReturned(IEnumerable<int> inputs)
        {
            //Act
            var result = _expenseReportService.FindAddendsOfYear(inputs, numberOfAddends: 2);

            //Assert
            result.Should().HaveCount(2);
            result.Should().Contain(new int[] { 1721, 299 });
        }

        [DataTestMethod, DataRow(new[] { "1721", "979", "366", "299", "675", "1456" })]
        public void MultiplyAddends_WhenAskedForTwoAddends_ThenReturnMultiplicationResult(string[] inputs)
        {
            //Act
            var result = _expenseReportService.MultiplyAddends(inputs, numberOfAddends: 2);

            //Assert
            result.Should().Be(514579);
        }

        [DataTestMethod, DataRow(new[] { 1721, 979, 366, 299, 675, 1456 })]
        public void FindAddendsOfYear_WhenAskedForThreeAddends_ThenThreeCorrectAddendsAreReturned(int[] inputs)
        {
            //Act
            var result = _expenseReportService.FindAddendsOfYear(inputs, numberOfAddends: 3);

            //Assert
            result.Should().HaveCount(3);
            result.Should().Contain(new int[] { 979, 366, 675 });
        }

        [DataTestMethod, DataRow(new[] { "1721", "979", "366", "299", "675", "1456" })]
        public void MultiplyAddends_WhenAskedForThreeAddends_ThenReturnMultiplicationResult(string [] inputs)
        {
            //Act
            var result = _expenseReportService.MultiplyAddends(inputs, numberOfAddends: 3);

            //Assert
            result.Should().Be(241861950);
        }
    }
}
